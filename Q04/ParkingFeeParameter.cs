using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04
{
    /// <summary>停車費的參數</summary>
    public class ParkingFeeParameter
    {
        /// <summary>是否需要判斷假日</summary>
        public bool checkHoliday { get; }
        /// <summary>是否是累進費率</summary>
        public bool checkProgress { get; }

        /// <summary>平日的免費分鐘數</summary>
        public int freeMinutes { get; }
        /// <summary>平日的每小時費率</summary>
        public int hourFee { get; }
        /// <summary>平日的半小時費率</summary>
        public int halfFee { get; }
        /// <summary>平日的累進費率</summary>
        public int progressFee { get; }
        /// <summary>平日的最高費率</summary>
        public int maxFee { get; }
        /// <summary>假日的免費分鐘數</summary>
        public int holidayFreeMinutes { get; }
        /// <summary>假日的每小時費率</summary>
        public int holidayHourFee { get; }
        /// <summary>假日的半小時費率</summary>
        public int holidayHalfFee { get; }
        /// <summary>假日的累進費率</summary>
        public int holidayProgressFee { get; }
        /// <summary>假日的最高費率</summary>
        public int holidayMaxFee { get; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="checkHoliday">是否需要判斷假日</param>
        /// <param name="checkProgress">是否是累進費率</param>
        /// <param name="freeMinutes">平日的免費分鐘數</param>
        /// <param name="hourFee">平日的每小時費率</param>
        /// <param name="halfFee">平日的半小時費率</param>
        /// <param name="progressFee">平日的累進費率</param>
        /// <param name="maxFee">平日的最高費率</param>
        /// <param name="holidayFreeMinutes">假日的免費分鐘數</param>
        /// <param name="holidayHourFee">假日的每小時費率</param>
        /// <param name="holidayHalfFee">假日的半小時費率</param>
        /// <param name="holidayProgressFee">假日的累進費率</param>
        /// <param name="holidayMaxFee">假日的最高費率</param>
        public ParkingFeeParameter(bool checkHoliday, bool checkProgress, int freeMinutes, int hourFee, int halfFee, int progressFee, int maxFee, int holidayFreeMinutes, int holidayHourFee, int holidayHalfFee, int holidayProgressFee, int holidayMaxFee)
        {
            this.checkHoliday = checkHoliday;
            this.checkProgress = checkProgress;
            this.freeMinutes = freeMinutes;
            this.hourFee = hourFee;
            this.halfFee = halfFee;
            this.progressFee = progressFee;
            this.maxFee = maxFee;
            this.holidayFreeMinutes = holidayFreeMinutes;
            this.holidayHourFee = holidayHourFee;
            this.holidayHalfFee = holidayHalfFee;
            this.holidayProgressFee = holidayProgressFee;
            this.holidayMaxFee = holidayMaxFee;
        }
    }
}
