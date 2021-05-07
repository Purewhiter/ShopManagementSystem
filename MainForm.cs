using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch (Program.Post)
            {
                case "店长":
                case "管理员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var humanform = new HumanForm();
            humanform.Show();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Gray;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Transparent;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch(Program.Post)
            {
                case "进货员":
                case "店长":
                case "管理员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var repform = new ReplenishForm();
            repform.Show();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Gray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Gray;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Gray;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch (Program.Post)
            {
                case "店长":
                case "管理员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var analysisform = new AnalysisForm();
            analysisform.Show();
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Gray;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Gray;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch (Program.Post)
            {
                case "进货员":
                case "店长":
                case "管理员":
                case "售货员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var stockform = new StockForm();
            stockform.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch (Program.Post)
            {
                case "收银员":
                case "售货员":
                case "店长":
                case "管理员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var saleform = new SaleForm();
            saleform.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch (Program.Post)
            {
                case "管理员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var settingform = new SettingForm();
            settingform.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch (Program.Post)
            {
                case "售货员":
                case "收银员":
                case "店长":
                case "管理员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var returnform = new ReturnGoodsForm();
            returnform.Show();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Gray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            DataHandle.Permission();
            switch (Program.Post)
            {
                case "进货员":
                case "店长":
                case "管理员":
                    break;
                default:
                    {
                        MessageBox.Show("无权限！");
                        return;
                    }
            }
            var goodslist1 = new GoodsListForm();
            goodslist1.Show();
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Gray;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss dddd");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
