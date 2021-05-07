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
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
            QueryAllInfo();
        }
        private void QueryAllInfo()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select * from GoodsNumber";
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
                    dataGridView1.Columns[2].HeaderText = "商品种类";
                    dataGridView1.Columns[3].HeaderText = "商品总存量";
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
        private void StockForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“goodsNumber._GoodsNumber”中。您可以根据需要移动或删除它。
            this.goodsNumberTableAdapter.Fill(this.goodsNumber._GoodsNumber);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择查找项！");
                return;
            }
            if (textBox1.Text != "")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                    {
                        conn.Open();
                        string sql = "";
                        if (comboBox1.Text == "商品名称")
                        { 
                            sql = $"select * from GoodsNumber where Gname like N'%{name}%'";
                        }
                        else if (comboBox1.Text == "商品种类")
                        {
                            sql = $"select * from GoodsNumber where Category like N'%{name}%'";
                        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            QueryAllInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var stockdetail = new StockDetailForm();
            stockdetail.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
