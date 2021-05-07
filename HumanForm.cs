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
    public partial class HumanForm : Form
    {
        public HumanForm()
        {
            InitializeComponent();
        }

        private void QueryAllInfo()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select EmpID,EmpName,EmpSex,EmpBirth,EmpOnboard,EmpPost,EmpPhone,EmpAddress,EmpRemark from EmployInfo";
                    //创建SqlDataAdapter类的对象
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView1.DataSource = ds.Tables[0];
                    //设置数据表格上显示的列标题
                    dataGridView1.Columns[0].HeaderText = "员工ID";
                    dataGridView1.Columns[1].HeaderText = "员工姓名";
                    dataGridView1.Columns[2].HeaderText = "性别";
                    dataGridView1.Columns[3].HeaderText = "出生日期";
                    dataGridView1.Columns[4].HeaderText = "入职日期";
                    dataGridView1.Columns[5].HeaderText = "职位";
                    dataGridView1.Columns[6].HeaderText = "联系电话";
                    dataGridView1.Columns[7].HeaderText = "住址";
                    dataGridView1.Columns[8].HeaderText = "备注";
                    //设置数据表格为只读
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
        private void 修改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }
            string name = textBox1.Text;
            string sex = "";
            if (radioButton1.Checked)
                sex = "男";
            else if (radioButton2.Checked)
                sex = "女";
            string ID = textBox2.Text;
            string address = textBox4.Text;
            string remark = textBox12.Text;
            string phone = textBox5.Text;
            string position = comboBox1.Text;
            string hiredate = dateTimePicker2.Value.ToString();
            string birth = dateTimePicker1.Value.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    //打开数据库
                    conn.Open();
                    string sql = $"Update EmployInfo set EmpName=N'{name}',EmpSex=N'{sex}',EmpPost=N'{position}',EmpPhone='{phone}',EmpAddress=N'{address}',EmpRemark=N'{remark}',EmpBirth='{birth}',EmpOnboard='{hiredate}' where EmpID='{ID}'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行修改操作的SQL
                    cmd.ExecuteNonQuery();
                    //弹出成功提示
                    MessageBox.Show("修改成功！");
                    QueryAllInfo();
                    DataHandle.ClearControl(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！" + ex.Message);
            }
        }

        private void HumanForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“shopDataSet1.EmployInfo”中。您可以根据需要移动或删除它。
            this.employInfoTableAdapter1.Fill(this.shopDataSet1.EmployInfo);
            // TODO: 这行代码将数据加载到表“shopDataSet.EmployInfo”中。您可以根据需要移动或删除它。
            QueryAllInfo();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 删除员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count==0)
                {
                    MessageBox.Show("请选择要删除的一行记录！");
                    return;
                }
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"delete from EmployInfo where EmpID='{id}'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("删除成功！");
                    QueryAllInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！" + ex.Message);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string name = toolStripTextBox1.Text;
            if (toolStripTextBox1.Text != "")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                    {
                        conn.Open();
                        string sql = $"select EmpID,EmpName,EmpSex,EmpBirth,EmpOnboard,EmpPost,EmpPhone,EmpAddress,EmpRemark from EmployInfo where EmpName like N'%{name}%'";
                        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误！" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请输入要查找的姓名！");
            }
        }

        private void 刷新F5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryAllInfo();
        }

        private void 添加员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }
            string name = textBox1.Text;
            string sex="";
            if (radioButton1.Checked)
                sex = "男";
            else if (radioButton2.Checked)
                sex = "女";
            string ID= textBox2.Text;
            string address= textBox4.Text;
            string remark= textBox12.Text;
            string phone= textBox5.Text;
            string username = ID;
            string password = ID;
            string position = comboBox1.Text;
            string hiredate = dateTimePicker2.Value.ToString();
            string birth = dateTimePicker1.Value.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    //打开数据库
                    conn.Open();
                    string sql = $"Insert into EmployInfo values('{ID}',N'{name}',N'{username}','{password}',N'{sex}',N'{position}','{phone}',N'{address}',N'{remark}','{birth}','{hiredate}')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行修改操作的SQL
                    cmd.ExecuteNonQuery();
                    //弹出成功提示
                    MessageBox.Show("添加成功！");
                    QueryAllInfo();
                    DataHandle.ClearControl(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！" + ex.Message);
            }
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 清空PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataHandle.ClearControl(this.Controls);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//姓名
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "男")
                radioButton1.Checked = true;
            else if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "女")
                radioButton2.Checked = true;
            textBox2.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//ID
            textBox4.Text= dataGridView1.SelectedRows[0].Cells[7].Value.ToString();//地址
            textBox12.Text= dataGridView1.SelectedRows[0].Cells[8].Value.ToString();//备注
            textBox5.Text= dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//电话
            comboBox1.Text= dataGridView1.SelectedRows[0].Cells[5].Value.ToString();//职位
            dateTimePicker2.Value= Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//入职日期
            dateTimePicker1.Value= Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());//出生日期
        }
    }
}

