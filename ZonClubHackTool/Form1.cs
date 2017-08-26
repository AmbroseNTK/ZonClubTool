using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace ZonClubHackTool
{
    public partial class Form1 : Form
    {
        Gecko.GeckoWebBrowser webBrowser;
        Regex regex;
        string regGetBlock= @" <ul class=""dices"" id=""gamehisId"">(.*?)<\/ul>";
        string regGetTai = @"Tip\('#(.*?)\'";
        int currentX;
        int currentY;
        List<TaiXiu> listTaiXiu;
        public Form1()
        {
            InitializeComponent();
           
        }
        int elapsedTime;
        private void Form1_Load(object sender, EventArgs e)
        {
            Gecko.Xpcom.Initialize(Application.StartupPath + "\\Firefox");
            webBrowser = new Gecko.GeckoWebBrowser();
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            webBrowser.NavigationError += WebBrowser_NavigationError;
            elapsedTime = 0;
            timer1.Start();
            listTaiXiu = new List<TaiXiu>();
            getData();
        }

        private void WebBrowser_NavigationError(object sender, Gecko.Events.GeckoNavigationErrorEventArgs e)
        {
            MessageBox.Show("Failed to connect", "Internet error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            Text = "ZonClub Hack Tool - Nguyen Tuan Kiet - Disconnected";
        }

        private void WebBrowser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            Text = "ZonClub Hack Tool - Nguyen Tuan Kiet - Connected";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            webBrowser.Dispose();
            Gecko.Xpcom.Shutdown();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            if (elapsedTime > 90)
            {
                elapsedTime = 0;
            }
            if (elapsedTime == 50)  //Timeout conditional
            {
                getData();
            }
            progressBar1.Value = elapsedTime;
        }
        public void getData()
        {
            webBrowser.Navigate("http://zon.club/#/");
            regex = new Regex(regGetBlock);
            string listTai = regex.Match(webBrowser.Document.Body.InnerHtml).Value;
            regex = new Regex(regGetTai);
            MatchCollection collection = regex.Matches(listTai);
            if (collection.Count != 0)
            {
                TaiXiu newbie = new TaiXiu();
                newbie.setData(collection[collection.Count - 1].Groups[0].Value);
                newbie.Location = new Point(currentX, currentY);
                listTaiXiu.Add(newbie);
                panel1.Controls.Add(newbie);
                currentX += 100;
                if (currentX == 800)
                {
                    currentY += 90;
                    currentX = 0;
                }
            }

        }

        private void btExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export to...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string data = "";
                foreach(TaiXiu t in listTaiXiu)
                {
                    data += t.Data+"\n";
                }
                File.WriteAllText(saveFileDialog.FileName, data);

            }
        }
    }
}
