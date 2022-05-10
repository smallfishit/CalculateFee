﻿using NUnit.Framework;
using Q04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04.Test
{
    public class ParkingFeeTest3
    {
        /// <summary>
        /// 確認停車費計算結果
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="totalFee">預期停車費</param>
        /// <param name="days">預期總日數</param>
        private void CheckFeeValue(DateTime start_time, DateTime end_time, int totalFee, int days)
        {
            //建立停車費計算物件
            ParkingFeeParameter parkPara = new ParkingFeeParameter(true, true, 0, 20, 20, 30, 300, 1440, 0, 0, 0, 0);
            ParkingFeeCalculator parkFee = new ParkingFeeCalculator(parkPara);
            //計算停車時間
            ParkingFee results = parkFee.CalcParkingFee(start_time, end_time);
            //驗證結果是否正確
            Assert.AreEqual(totalFee, results.TotalFee);
            Assert.AreEqual(days, results.Items.Count());
        }

        /// <summary>
        /// 確認停車費計算結果(單日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="totalFee">預期停車費</param>
        /// <param name="days">預期總日數</param>
        [TestCase("2022/5/10 9:00:00", "2022/5/10 9:10:59", 20, 1)]
        [TestCase("2022/5/10 9:00:59", "2022/5/10 9:11:00", 20, 1)]
        [TestCase("2022/5/10 9:00:00", "2022/5/10 9:30:59", 20, 1)]
        [TestCase("2022/5/10 9:00:59", "2022/5/10 9:31:00", 20, 1)]
        [TestCase("2022/5/10 9:00:00", "2022/5/10 10:00:59", 20, 1)]
        [TestCase("2022/5/10 9:00:59", "2022/5/10 10:01:00", 50, 1)]
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeSingle(DateTime start_time, DateTime end_time, int totalFee, int days)
        {
            CheckFeeValue(start_time, end_time, totalFee, days);
        }

        /// <summary>
        /// 確認停車費計算結果(假日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="totalFee">預期停車費</param>
        /// <param name="days">預期總日數</param>
        [TestCase("2022/5/14 9:00:00", "2022/5/14 9:10:59", 0, 1)]
        [TestCase("2022/5/14 9:00:59", "2022/5/14 9:11:00", 0, 1)]
        [TestCase("2022/5/14 9:00:00", "2022/5/14 9:30:59", 0, 1)]
        [TestCase("2022/5/14 9:00:59", "2022/5/14 9:31:00", 0, 1)]
        [TestCase("2022/5/14 9:00:00", "2022/5/14 10:00:59", 0, 1)]
        [TestCase("2022/5/14 9:00:59", "2022/5/14 10:01:00", 0, 1)]
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeSingleHoliday(DateTime start_time, DateTime end_time, int totalFee, int days)
        {
            CheckFeeValue(start_time, end_time, totalFee, days);
        }

        /// <summary>
        /// 確認停車費計算結果(跨單日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="totalFee">預期停車費</param>
        /// <param name="days">預期總日數</param>
        [TestCase("2022/5/1 23:49:00", "2022/5/2 00:10:59", 20, 2)]
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeOneDay(DateTime start_time, DateTime end_time, int totalFee, int days)
        {
            CheckFeeValue(start_time, end_time, totalFee, days);
        }

        /// <summary>
        /// 確認停車費計算結果(跨單日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="totalFee">預期停車費</param>
        /// <param name="days">預期總日數</param>
        [TestCase("2022/5/1 23:48:00", "2022/5/2 00:00:00", 0, 2)] // 跨一天,收費  
        [TestCase("2022/5/1 23:48:00", "2022/5/2 00:11:59", 20, 2)] // 跨一天,收費
        [TestCase("2022/5/1 00:00:00", "2022/5/2 00:11:59", 20, 2)] // 跨一天,收費
        [TestCase("2022/5/1 00:00:00", "2022/5/2 01:11:59", 50, 2)] // 跨一天,收費
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeOneDay2(DateTime start_time, DateTime end_time, int totalFee, int days)
        {
            CheckFeeValue(start_time, end_time, totalFee, days);
        }

        /// <summary>
        /// 確認停車費計算結果(跨多日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="totalFee">預期停車費</param>
        /// <param name="days">預期總日數</param>
        [TestCase("2022/5/1 23:49:00", "2022/5/3 00:11:59", 320, 3)] // 跨2天,收費
        [TestCase("2022/5/1 22:59:00", "2022/5/3 00:11:59", 320, 3)] // 跨2天,收費
        [TestCase("2022/5/1 00:00:00", "2022/5/3 00:11:59", 320, 3)] // 跨2天,收費
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeMoreDay(DateTime start_time, DateTime end_time, int totalFee, int days)
        {
            CheckFeeValue(start_time, end_time, totalFee, days);
        }
    }
}
