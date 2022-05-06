using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01.Test
{
    public class ParkingFeeTest
    {
        /// <summary>
        /// 確認停車時間計算結果
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="minutes">預期總分鐘</param>
        private void CheckFeeMinutes(DateTime start_time, DateTime end_time, int minutes)
        {
            //建立停車費計算物件
            ParkingFeeCalculator parkFee = new ParkingFeeCalculator();
            //計算停車時間
            int result = parkFee.GetMinutesFromDate(start_time, end_time);
            //驗證結果是否正確
            Assert.AreEqual(minutes, result);
        }

        /// <summary>
        /// 確認停車時間計算結果
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="minutes">預期總分鐘</param>
        [TestCase("9:00:00", "9:00:59", 0)]
        [TestCase("9:00:00", "9:01:59", 1)]
        [TestCase("9:00:59", "9:01:00", 1)]
        [TestCase("9:59:00", "10:00:01", 1)]
        [TestCase("9:00:00", "10:00:59", 60)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnMinutes(DateTime start_time, DateTime end_time, int minutes)
        {
            CheckFeeMinutes(start_time, end_time, minutes);
        }
    }
}
