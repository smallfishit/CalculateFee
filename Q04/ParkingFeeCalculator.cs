using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04
{
    /// <summary>計算停車費的類別</summary>
    public class ParkingFeeCalculator
    {
        /// <summary>停車費的參數</summary>
        public ParkingFeeParameter feePara { get; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="feePara">停車費的參數</param>
        /// <param name="checkHalf">是否需要判斷半小時</param>
        /// <param name="hourFee">平日的每小時費率</param>
        /// <param name="halfFee">平日的半小時費率</param>
        /// <param name="maxFee">平日的最高費率</param>
        /// <param name="holidayHourFee">假日的每小時費率</param>
        /// <param name="holidayHalfFee">假日的半小時費率</param>
        /// <param name="holidayMaxFee">假日的最高費率</param>
        public ParkingFeeCalculator(ParkingFeeParameter feePara)
        {
            this.feePara = feePara;
        }

        /// <summary>計算停車的分鐘數</summary>
        private bool isHoliday(DateTime date)
        {
            bool holiday = false;
            //先用六日判斷
            DayOfWeek day = date.DayOfWeek;
            switch (day)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    holiday = true;
                    break;
            }
            return holiday;
        }

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
            int totalMinutes = GetMinutesFromDate(start_time, end_time);

            //計算小時和分鐘數
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            /*
            int maxFee = 50; //停車費上限
            int hourFee = 10; //每小時停車費
            int halfHourFee = 7; //半小時停車費
            //*/

            int freeMinutes = 0; //免費分鐘數
            int maxFee = 0; //停車費上限
            int hourFee = 0; //每小時停車費
            int halfHourFee = 0; //半小時停車費
            int progressFee = 0; //累進費率

            bool holiday = false;
            if(feePara.checkHoliday && isHoliday(start_time))
            {
                holiday = true;
            }

            if (holiday)
            {
                freeMinutes = feePara.holidayFreeMinutes; //免費分鐘數
                maxFee = feePara.holidayMaxFee; //停車費上限
                hourFee = feePara.holidayHourFee; //每小時停車費
                progressFee = feePara.holidayProgressFee; //累進費率
                halfHourFee = feePara.holidayHalfFee; //半小時停車費
            }
            else
            {
                freeMinutes = feePara.freeMinutes; //免費分鐘數
                maxFee = feePara.maxFee; //停車費上限
                hourFee = feePara.hourFee; //每小時停車費
                progressFee = feePara.progressFee; //累進費率
                halfHourFee = feePara.halfFee; //半小時停車費
            }

            int fee = 0;
            if (totalMinutes <= freeMinutes)
            { }
            else if (minutes > 0 && minutes <= 30)
            {
                if(feePara.checkProgress)
                {
                    if(hours == 0)
                    {
                        fee = halfHourFee;
                    }
                    else
                    {
                        //累進費率沒有半小時
                        fee = hourFee + hours * progressFee; 
                    }
                }
                else
                {
                    fee = hours * hourFee + halfHourFee;
                }
            }
            else
            {
                if (feePara.checkProgress)
                {
                    if (hours == 0)
                    {
                        fee = hourFee;
                    }
                    else
                    {
                        fee = hourFee;
                        fee += minutes > 0 ? hours * progressFee : (hours - 1) * progressFee;
                    }
                }
                else
                {
                    fee = minutes > 0 ? (hours + 1) * hourFee : hours * hourFee;
                }
            }

            return fee > maxFee ? maxFee : fee;
        }

        /// <summary>
        /// 取得停車美日資料列表
        /// </summary>
        /// <param name="start_time">停車開始時間</param>
        /// <param name="end_time">停車結束時間</param>
        /// <returns></returns>
        public IEnumerable<SingleDayFee> CalcFeeForMultiDays(DateTime start_time, DateTime end_time)
        {
            if (end_time < start_time)
            {
                throw new Exception("結束時間必須在開始時間之後");
            }

            IEnumerable<SingleDayFee> feeList = new List<SingleDayFee>();

            SingleDayFee feeData = null;
            while (end_time.Date > start_time.Date)
            {
                DateTime startTime = Convert.ToDateTime($"{end_time.ToString("yyyy/MM/dd")} 00:00:00");
                feeData = new SingleDayFee(startTime, end_time, GetFeeFromOneDate(startTime, end_time));
                yield return feeData;
                end_time = Convert.ToDateTime($"{end_time.AddDays(-1).ToString("yyyy/MM/dd")} 23:59:59");
            }

            feeData = new SingleDayFee(start_time, end_time, GetFeeFromOneDate(start_time, end_time));
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
            IEnumerable<SingleDayFee> feeList = CalcFeeForMultiDays(start_time, end_time);

            int days = feeList.Count();

            ParkingFee feeData = new ParkingFee(feeList, feePara);

            return feeData;
        }
    }
}
