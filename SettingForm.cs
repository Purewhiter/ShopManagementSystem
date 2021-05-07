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
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }
        public DataTable dt = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string EmpName = textBox1.Text;
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入要查找的姓名！");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select EmpID,EmpName, UserName,Password from EmployInfo where EmpName=N'{EmpName}'";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("该员工不存在！");
                        dt = null;
                        return;
                    }
                    dataGridView1.Columns[0].HeaderText = "员工编号";
                    dataGridView1.Columns[1].HeaderText = "员工姓名";
                    dataGridView1.Columns[2].HeaderText = "账户名";
                    dataGridView1.Columns[3].HeaderText = "密码";

                    dataGridView1.ReadOnly = true;
                    //不允许添加行
                    dataGridView1.AllowUserToAddRows = false;
                    //背景为白色
                    dataGridView1.BackgroundColor = Color.White;
                    //只允许选中单行
                    dataGridView1.MultiSelect = false;
                    //整行选中
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dt == null || dt.Rows.Count != 1)
            {
                MessageBox.Show("输入信息错误或不完整！");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
     
                    conn.Open();

                    string sql = $"select EmpID,EmpName, UserName,Password from EmployInfo where EmpName=N'{textBox1.Text}'";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    sda.Fill(dt);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(sda);
                    DataRow dr = dt.Rows[0];
                    dr["UserName"] = textBox2.Text;
                    dr["Password"] = textBox3.Text;
                    sda.Update(dt);
                    dt.AcceptChanges();
                    MessageBox.Show("修改成功！");

                    dt = null;
                    dataGridView1.DataSource = dt;
                    DataHandle.ClearControl(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！" + ex.Message);
            }
        }
    }
}
