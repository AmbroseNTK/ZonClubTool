using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZonClubHackTool
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }
        private List<string> dataMatchCollection;
        private DataTable data;

        public List<string> DataMatchCollection { get => dataMatchCollection; set => dataMatchCollection = value; }

        private void btSearch_Click(object sender, EventArgs e)
        {
            data = new DataTable();
            data.Columns.Add("Point");
            data.Columns.Add("Before");
            data.Columns.Add("After");
            for(int i = 0; i < dataMatchCollection.Count; i++)
            {
                if(dataMatchCollection[i].Contains("- "+tbSearch.Text+" ("))
                {
                    DataRow row = data.NewRow();
                    row.SetField<string>(0, dataMatchCollection[i]);
                    if (check(i - 1))
                        row.SetField<string>(1, dataMatchCollection[i - 1]);
                    if (check(i + 1))
                        row.SetField<string>(2, dataMatchCollection[i + 1]);
                    data.Rows.Add(row);
                }
            }
            dataGridView1.DataSource = data;
            
        }
        private bool check(int num)
        {
            return (num >= 0 && num < dataMatchCollection.Count);
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            string text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                text = File.ReadAllText(ofd.FileName);
            }
            List<string> lines = text.Split('\n').ToList<string>();
            DataMatchCollection = lines;
        }
    }
}
