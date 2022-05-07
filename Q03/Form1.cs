using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy/MM/dd HH:mm:ss";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ParkingFeeCalculator parkFee = new ParkingFeeCalculator();
                //計算停車總分鐘數
                var results = parkFee.CalcParkingFee(dateTimePicker1.Value, dateTimePicker2.Value);
                richTextBox1.Text = $"總日數 = {results.Items.Count()}{Environment.NewLine}總停車費 = {results.TotalFee}{Environment.NewLine}";
            }
            catch (Exception ex)
            {
                richTextBox1.Text = string.Empty;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
