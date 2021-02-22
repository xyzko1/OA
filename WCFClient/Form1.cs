using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Model;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInfoServiceClient client = new UserInfoServiceClient();

            UserInfo userInfo = client.GetUserById(4);

            MessageBox.Show("Age:"+userInfo.Age+ ";Id:" + userInfo.Id);
        }
    }
}
