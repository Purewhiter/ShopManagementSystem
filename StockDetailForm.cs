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
    public partial class StockDetailForm : Form
    {
        public StockDetailForm()
        {
            InitializeComponent();
            QueryAllInfo();
        }
        public DataTable dt = null;
        public void QueryAllInfo()
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select * from StockDetail";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "库存编号";
                    dataGridView1.Columns[1].HeaderText = "商品编号";
                    dataGridView1.Columns[2].HeaderText = "商品名称";
                    dataGridView1.Columns[3].HeaderText = "库存数量";
                    dataGridView1.Columns[4].HeaderText = "成本单价";
                    dataGridView1.Columns[5].HeaderText = "过期时间";
                    dataGridView1.Columns[6].HeaderText = "进货编号";

                    dataGridView1.ReadOnly = true;
                    //不允许添加行
                    dataGridView1.AllowUserToAddRows = false;
                    //背景为白色
                    dataGridView1.BackgroundColor = Color.White;
                    //只允许选中单行
                    dataGridView1.MultiSelect = false;
                    //整行选中
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
            }
        }
        private void StockDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
