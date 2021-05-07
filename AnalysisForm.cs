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
    public partial class AnalysisForm : Form
    {
        public AnalysisForm()
        {
            InitializeComponent();
        }
        DataTable dt = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string beginTime = dateTimePicker1.Value.ToString("s");
            string endTime= dateTimePicker2.Value.ToString("s");
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select SellNo,Gname, SellNum, Unit, GoodsPrice, Discount, SellNum*GoodsPrice*Discount Total, SellTime from SellRecord where SellTime between '{beginTime}' and '{endTime}'";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    string sql1 = $"select sum(SellNum*GoodsPrice*Discount) from SellRecord where SellTime between N'{beginTime}' and N'{endTime}'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    decimal dr1 = decimal.Parse(cmd1.ExecuteScalar().ToString());
                    textBox1.Text = dr1.ToString();

                    string sql2 = $"select sum(SellNum*GoodsPrice*Discount)-sum(SellNum*CostPrice) from SellRecord,StockDetail where SellTime between '{beginTime}' and '{endTime}' and SellRecord.StNo=StockDetail.StNo";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    decimal dr2 = decimal.Parse(cmd2.ExecuteScalar().ToString());
                    textBox2.Text = dr2.ToString();

                    decimal rate = dr2 / dr1*100;
                    string rateString = rate.ToString("#0.00")+"%";
                    textBox3.Text = rateString;

                    dataGridView1.Columns[0].HeaderText = "销售编号";
                    dataGridView1.Columns[1].HeaderText = "商品名称";
                    dataGridView1.Columns[2].HeaderText = "销售数量";
                    dataGridView1.Columns[3].HeaderText = "单位";
                    dataGridView1.Columns[5].HeaderText = "折扣率";
                    dataGridView1.Columns[6].HeaderText = "总金额";
                    dataGridView1.Columns[4].HeaderText = "单价";
                    dataGridView1.Columns[7].HeaderText = "售出时间";


                    dataGridView1.ReadOnly = true;
                    //不允许添加行
                    dataGridView1.AllowUserToAddRows = false;
                    //背景为白色
                    dataGridView1.BackgroundColor = Color.White;
                    //只允许选中单行
                    dataGridView1.MultiSelect = false;
                    //整行选中
                    //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //自动填充
                    this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
            }
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
        }
    }
}
