using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ShopManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pwd = textBox2.Text;
            Program.LoginID = name;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"Select count(*) from EmployInfo where UserName='{name}' and Password='{pwd}'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int returnValue = (int)cmd.ExecuteScalar();
                    if (returnValue != 0)
                    {
                        MessageBox.Show("登录成功！");
                        var mainform = new MainForm();
                        this.Hide();
                        mainform.Show();
                    }
                    else
                        MessageBox.Show("登录失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败！" + ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                button1.Focus();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                button1_Click(this, e);
        }
    }
}
