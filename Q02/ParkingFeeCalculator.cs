using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02
{
    /// <summary>計算停車費的類別</summary>
    public class ParkingFeeCalculator
    {
        /// <summary>計算停車的分鐘數</summary>
        public int GetMinutesFromDate(DateTime start_time, DateTime end_time)
        {
            if(end_time < start_time)
            {
                throw new Exception("結束時間必須在開始時間之後");
            }

            if(end_time.Date > start_time.Date)
            {
                throw new Exception("結束時間跟開始時間必須是同一天");
            }

            int hours = end_time.Hour - start_time.Hour;
            int minutes = end_time.Minute - start_time.Minute;

            return 60 * hours + minutes;
        }

        /// <summary>計算停車的費用</summary>
        public int GetFeeFromDate(DateTime start_time, DateTime end_time)
        {
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
            else if(minutes > 0 && minutes <= 30)
            {
                fee = hours * hourFee + halfHourFee;
            }
            else
            {
                fee = minutes > 0 ? (hours + 1) * hourFee : hours * hourFee;
            }

            return fee > maxFee ? maxFee : fee;
        }
    }
}
