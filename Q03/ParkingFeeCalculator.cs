using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03
{
    /// <summary>計算停車費的類別</summary>
    public class ParkingFeeCalculator
    {
        /// <summary>計算停車的分鐘數</summary>
        private int GetMinutesFromDate(DateTime start_time, DateTime end_time)
        {
            int hours = end_time.Hour - start_time.Hour;
            int minutes = end_time.Minute - start_time.Minute;

            return 60 * hours + minutes;
        }

        /// <summary>計算單日停車的費用</summary>
        /// <param name="start_time">停車開始時間</param>
        /// <param name="end_time">停車結束時間</param>
        public int GetFeeFromOneDate(DateTime start_time, DateTime end_time)
        {
            if (end_time < start_time)
            {
                throw new Exception("結束時間必須在開始時間之後");
            }

            if (end_time.Date > start_time.Date)
            {
                throw new Exception("結束時間跟開始時間必須是同一天");
            }

            //先取得分鐘數
            int minutes = GetMinutesFromDate(start_time, end_time);

            //計算小時和分鐘數
            int hours = minutes / 60;
            minutes = minutes % 60;

            int maxFee = 50; //停車費上限
            int hourFee = 10; //每小時停車費
            int halfHourFee = 7; //半小時停車費

            int fee = 0;
            if (hours == 0 && minutes <= 10)
            { }
            else if (minutes > 0 && minutes <= 30)
            {
                fee = hours * hourFee + halfHourFee;
            }
            else
            {
                fee = minutes > 0 ? (hours + 1) * hourFee : hours * hourFee;
            }

            return fee > maxFee ? maxFee : fee;
        }

        /// <summary>
        /// 取得停車美日資料列表
        /// </summary>
        /// <param name="start_time">停車開始時間</param>
        /// <param name="end_time">停車結束時間</param>
        /// <returns></returns>
        public IEnumerable<SingleDayFee> GetFeeItemsFromManyDate(DateTime start_time, DateTime end_time)
        {
            if (end_time < start_time)
            {
                throw new Exception("結束時間必須在開始時間之後");
            }

            IEnumerable<SingleDayFee> feeList = new List<SingleDayFee>();

            SingleDayFee feeData = null;
            while (end_time.Date > start_time.Date)
            {
                feeData = new SingleDayFee();
                feeData.StartTime = Convert.ToDateTime($"{end_time.ToString("yyyy/MM/dd")} 00:00:00");
                feeData.EndTime = end_time;
                yield return feeData;
                end_time = Convert.ToDateTime($"{end_time.AddDays(-1).ToString("yyyy/MM/dd")} 23:59:59");
            }

            feeData = new SingleDayFee();
            feeData.StartTime = start_time;
            feeData.EndTime = end_time;
            yield return feeData;
        }

        /// <summary>
        /// 取得多日停車總費用
        /// </summary>
        /// <param name="start_time">停車開始時間</param>
        /// <param name="end_time">停車結束時間</param>
        /// <returns></returns>
        public ParkingFee CalcParkingFee(DateTime start_time, DateTime end_time)

        {
            IEnumerable<SingleDayFee> feeList = GetFeeItemsFromManyDate(start_time, end_time);

            int totalFee = 0;
            int days = feeList.Count();

            foreach (SingleDayFee data in feeList)
            {
                totalFee += GetFeeFromOneDate(data.StartTime, data.EndTime);
            }

            ParkingFee feeData = new ParkingFee(feeList, totalFee);

            return feeData;
        }
    }
}
