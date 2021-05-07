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
    public partial class ReturnRecordForm : Form
    {
        public ReturnRecordForm()
        {
            InitializeComponent();
            QueryAllInfo();
        }
        public void QueryAllInfo()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select * from ReturnDetail";
                    //创建SqlDataAdapter类的对象
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView1.DataSource = ds.Tables[0];
                    //设置数据表格上显示的列标题
                    dataGridView1.Columns[0].HeaderText = "退货编号";
                    dataGridView1.Columns[1].HeaderText = "销售编号";
                    dataGridView1.Columns[2].HeaderText = "商品编号";
                    dataGridView1.Columns[3].HeaderText = "商品名称";
                    dataGridView1.Columns[4].HeaderText = "商品单价";
                    dataGridView1.Columns[5].HeaderText = "折扣率";
                    dataGridView1.Columns[6].HeaderText = "退货数量";
                    dataGridView1.Columns[7].HeaderText = "退货时间";
                    dataGridView1.Columns[8].HeaderText = "员工ID";
                    dataGridView1.Columns[9].HeaderText = "能否再次销售";
                    dataGridView1.Columns[10].HeaderText = "退货原因";

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
        private void ReturnRecordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
