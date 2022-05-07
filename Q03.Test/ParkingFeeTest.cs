using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03.Test
{
    public class ParkingFeeTest
    {
        /// <summary>
        /// 確認停車費計算結果
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        private void CheckFeeValue(DateTime start_time, DateTime end_time, int fee)
        {
            //建立停車費計算物件
            ParkingFeeCalculator parkFee = new ParkingFeeCalculator();
            //計算停車時間
            int result = parkFee.GetFeeFromDate(start_time, end_time);
            //驗證結果是否正確
            Assert.AreEqual(fee, result);
        }

        /// <summary>
        /// 確認停車費計算結果(單日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:00", "9:00:00", 0)]
        [TestCase("9:00:00", "9:10:59", 0)]
        [TestCase("9:00:59", "9:11:00", 7)]
        [TestCase("9:00:00", "9:30:59", 7)]
        [TestCase("9:00:59", "9:31:00", 10)]
        [TestCase("9:00:00", "10:00:59", 10)]
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeSingle(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeValue(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果(跨單日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("2022/5/1 23:49:00", "2022/5/2 00:10:59", 0)]
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeOneDay(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeValue(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果(跨單日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("2022/5/1 23:48:00", "2022/5/2 00:00:00", 7)] // 跨一天,收費  
        [TestCase("2022/5/1 23:48:00", "2022/5/2 00:11:59", 14)] // 跨一天,收費
        [TestCase("2022/5/1 00:00:00", "2022/5/2 00:11:59", 57)] // 跨一天,收費
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeOneDay2(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeValue(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果(跨多日)
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("2022/5/1 23:49:00", "2022/5/3 00:11:59", 57)] // 跨2天,收費
        [TestCase("2022/5/1 22:59:00", "2022/5/3 00:11:59", 67)] // 跨2天,收費
        [TestCase("2022/5/1 00:00:00", "2022/5/3 00:11:59", 107)] // 跨2天,收費
        [Test]
        public void GetFeeFromDate_InputDateTime_ReturnFeeMoreDay(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeValue(start_time, end_time, fee);
        }
    }
}
