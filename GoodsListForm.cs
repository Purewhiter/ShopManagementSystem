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
    public partial class GoodsListForm : Form
    {
        public GoodsListForm()
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
                    string sql = $"select * from GoodsList";
                    //创建SqlDataAdapter类的对象
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView1.DataSource = ds.Tables[0];
                    //设置数据表格上显示的列标题
                    dataGridView1.Columns[0].HeaderText = "商品编号";
                    dataGridView1.Columns[1].HeaderText = "商品名称";
                    dataGridView1.Columns[2].HeaderText = "条形码";
                    dataGridView1.Columns[3].HeaderText = "种类";
                    dataGridView1.Columns[4].HeaderText = "单位";
                    dataGridView1.Columns[5].HeaderText = "规格型号";
                    dataGridView1.Columns[6].HeaderText = "预设单价";
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
        private void GoodsListForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“goodsCategory._GoodsCategory”中。您可以根据需要移动或删除它。
            this.goodsCategoryTableAdapter.Fill(this.goodsCategory._GoodsCategory);
            // TODO: 这行代码将数据加载到表“shopDataSet2.GoodsList”中。您可以根据需要移动或删除它。
            this.goodsListTableAdapter.Fill(this.shopDataSet2.GoodsList);
            QueryAllInfo();
        }

        private void 添加商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string name = textBox2.Text;
            string barcode = textBox3.Text;
            string cate = comboBox1.Text;
            string unit = textBox5.Text;
            string spec = textBox6.Text;
            string price = textBox7.Text;
            if(textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("请输入完整商品信息！");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"Insert into GoodsList values('{ID}',N'{name}','{barcode}',N'{cate}',N'{unit}',N'{spec}',N'{price}')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
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

        private void 删除商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"delete from GoodsList where Gno='{id}'";
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

        private void 刷新F5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryAllInfo();
        }

        private void 清空PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataHandle.ClearControl(this.Controls);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

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
                        string sql = $"select * from GoodsList where Gname like N'%{name}%'";
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
                MessageBox.Show("请输入要查找的商品名称！");
            }
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 修改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string name = textBox2.Text;
            string barcode = textBox3.Text;
            string cate = comboBox1.Text;
            string unit = textBox5.Text;
            string spec = textBox6.Text;
            string price = textBox7.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"Update GoodsList set Gno='{ID}',Gname=N'{name}',BarCode='{barcode}',Category=N'{cate}',Unit=N'{unit}',Specification=N'{spec}',GoodsPrice=N'{price}' where Gno='{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//ID
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//名称
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//条形码
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//种类
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();//单位
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();//规格
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//预设单价
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            添加商品ToolStripMenuItem_Click(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            清空PToolStripMenuItem_Click(this, e);
        }
    }
}
