using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03
{
    public class SingleDayFee
    {
        /// <summary>精確到分鐘的入場時間</summary>
        public DateTime StartTime { get; }
        /// <summary>精確到分鐘的離場時間</summary>
        public DateTime EndTime { get; }
        /// <summary>本日應收取費用</summary>
        public int Fee { get; }

        /// <summary>基本的建構子</summary>
        public SingleDayFee()
        {
            StartTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
            Fee = 0;
        }

        /// <summary>
        /// 帶入參數的建構子
        /// </summary>
        /// <param name="StartTime">精確到分鐘的入場時間</param>
        /// <param name="EndTime">精確到分鐘的離場時間</param>
        /// <param name="Fee">本日應收取費用</param>
        public SingleDayFee(DateTime StartTime, DateTime EndTime, int Fee)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Fee = Fee;
        }
    }
}
