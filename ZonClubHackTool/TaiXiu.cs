using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZonClubHackTool
{
    public partial class TaiXiu : UserControl
    {
        public TaiXiu()
        {
            InitializeComponent();
        }
        private string data;

        public string Data { get => data; set => data = value; }

        public void setData(string data)
        {
            tbData.Text = data;
            Data = data;
            if (data.Contains("Xỉu"))
                tbData.BackColor = Color.White;
            else
                tbData.BackColor = Color.Black;
        }
    }
}
