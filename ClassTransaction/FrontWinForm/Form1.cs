using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace FrontWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string baseUrl = "http://10.0.49.253:5270";
            Client apiClient = new Client(baseUrl,httpClient);

            var tempData=apiClient.StocksAllAsync().Result;


            button1.Text = "loaded！";

            dataGridView1.DataSource = tempData;

        }
    }
}
