using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02.Test
{
    public class ParkingFeeTest
    {
        /// <summary>
        /// 確認停車費計算結果
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        private void CheckFeeMinutes(DateTime start_time, DateTime end_time, int fee)
        {
            //建立停車費計算物件
            ParkingFeeCalculator parkFee = new ParkingFeeCalculator();
            //計算停車時間
            int result = parkFee.GetFeeFromDate(start_time, end_time);
            //驗證結果是否正確
            Assert.AreEqual(fee, result);
        }

        /// <summary>
        /// 確認停車費計算結果0
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:00", "9:00:00", 0)]
        [TestCase("9:00:00", "9:10:59", 0)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee0(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果7
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:59", "9:11:00", 7)]
        [TestCase("9:00:00", "9:30:59", 7)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee7(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果10
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:59", "9:31:00", 10)]
        [TestCase("9:00:00", "10:00:59", 10)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee10(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果17
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:59", "10:01:00", 17)]
        [TestCase("9:00:00", "10:30:59", 17)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee17(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果27
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:59", "11:01:00", 27)]
        [TestCase("9:00:00", "11:30:59", 27)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee27(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果37
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:59", "12:01:00", 37)]
        [TestCase("9:00:00", "12:30:59", 37)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee37(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果47
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:59", "13:01:00", 47)]
        [TestCase("9:00:00", "13:30:59", 47)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee47(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }

        /// <summary>
        /// 確認停車費計算結果50
        /// </summary>
        /// <param name="start_time">開始時間</param>
        /// <param name="end_time">結束時間</param>
        /// <param name="fee">預期停車費</param>
        [TestCase("9:00:59", "13:31:00", 50)]
        [TestCase("9:00:00", "23:59:59", 50)]
        [Test]
        public void GetMinutesFromDate_InputDateTime_ReturnFee50(DateTime start_time, DateTime end_time, int fee)
        {
            CheckFeeMinutes(start_time, end_time, fee);
        }
    }
}
