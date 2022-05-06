using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01
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
    }
}
