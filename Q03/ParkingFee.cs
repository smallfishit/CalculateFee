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

        /// <summary>
        /// 帶入參數的建構子
        /// </summary>
        /// <param name="Items">取得多日的停車資料物件</param>
        /// <param name="TotalFee">應收取總費用</param>
        public ParkingFee(IEnumerable<SingleDayFee> Items, int TotalFee)
        {
            this.Items = Items;
            this.TotalFee = TotalFee;
        }
    }
}
