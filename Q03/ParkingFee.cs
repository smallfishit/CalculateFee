using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03
{
    public class ParkingFee
    {
        /// <summary>取得多日的停車資料物件</summary>
        public IEnumerable<SingleDayFee> Items { get; private set; }
        /// <summary>應收取總費用</summary>
        public int TotalFee { get; }

        /// <summary>基本的建構子</summary>
        public ParkingFee()
        {
            Items = null;
            TotalFee = 0;
        }

        public ParkingFee(IEnumerable<SingleDayFee> Items)
        {
            this.Items = Items;
            ParkingFeeCalculator feeCalc = new ParkingFeeCalculator();
            TotalFee = 0;
            foreach(SingleDayFee data in Items)
            {
                TotalFee += feeCalc.GetFeeFromOneDate(data.StartTime, data.EndTime);
            }
        }
    }
}
