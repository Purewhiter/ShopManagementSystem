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
    public partial class ReturnGoodsForm : Form
    {
        public ReturnGoodsForm()
        {
            InitializeComponent();
        }
        public DataTable dt = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string SellNo = textBox1.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select SellNo, Gno, StNo, Gname, SellNum, Unit, GoodsPrice, Discount, SellTime, EmpID, Remark from SellRecord where SellNo='{SellNo}'";
                    
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    sda.Fill(dt);

                    if(dt.Rows.Count == 0||dt==null)
                    {
                        MessageBox.Show("输入的单号有误！");
                        return;
                    }
                    dataGridView1.DataSource = dt;


                    dataGridView1.Columns[0].HeaderText = "销售编号";
                    dataGridView1.Columns[1].HeaderText = "商品编号";
                    dataGridView1.Columns[2].HeaderText = "库存编号";
                    dataGridView1.Columns[3].HeaderText = "商品名称";
                    dataGridView1.Columns[4].HeaderText = "销售数量";
                    dataGridView1.Columns[5].HeaderText = "单位";
                    dataGridView1.Columns[6].HeaderText = "单价";
                    dataGridView1.Columns[7].HeaderText = "折扣率";
                    dataGridView1.Columns[8].HeaderText = "售出时间";
                    dataGridView1.Columns[9].HeaderText = "销售人ID";
                    dataGridView1.Columns[10].HeaderText = "备注";

                    dataGridView1.ReadOnly = true;
                    //不允许添加行
                    dataGridView1.AllowUserToAddRows = false;
                    //背景为白色
                    dataGridView1.BackgroundColor = Color.White;
                    //只允许选中单行
                    dataGridView1.MultiSelect = false;
                    //整行选中
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string RtState = null;
            if (radioButton1.Checked)
                RtState = "能";
            else if (radioButton2.Checked)
                RtState = "不能";
            if (textBox1.Text == "" || RtState == null || textBox2.Text == "" || textBox3.Text == "" || dt.Rows.Count == 0 || dt == null|| dataGridView1.SelectedRows.Count!=1)
            {
                MessageBox.Show("请输入正确完整信息！");
                return;
            }

            //string SellNo = textBox1.Text;

            //string RtNum = textBox3.Text;
            //string Reason = textBox2.Text;
            //string EmpID = null;
            //string RtID = "RT" + DateTime.Now.ToString("yyMMddhhmmss");
            //string Gno = dt.Rows[0][1].ToString();
            //string GoodsPrice = dt.Rows[0][6].ToString();
            //string RtTime = DateTime.Now.ToString();
            //string Discount = dt.Rows[0][7].ToString();
            //string StNo = dt.Rows[0][2].ToString();


            string SellNo = textBox1.Text;

            string RtNum = textBox3.Text;
            string Reason = textBox2.Text;
            string EmpID = null;
            string RtID = "RT" + DateTime.Now.ToString("yyMMddhhmmss");
            string Gno = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string GoodsPrice = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string RtTime = DateTime.Now.ToString();
            string Discount = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            string StNo = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            string SellNum = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            if (int.Parse(RtNum)>int.Parse(SellNum))
            {
                MessageBox.Show("请输入正确的退货数量！");
                return;
            }
            
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    //打开数据库
                    conn.Open();

                    string sql1 = $"select EmpID from EmployInfo where UserName='{Program.LoginID}'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        EmpID = dr1[0].ToString();
                    }

                    string sql = $"Insert into GoodsReturn values('{RtID}',N'{SellNo}',N'{Gno}',N'{RtNum}',N'{RtTime}','{EmpID}',N'{RtState}',N'{Reason}')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    if (RtState == "能")
                    {
                        string sql2 = $"Update GoodsStock set StockNum=StockNum+{RtNum} where StNo='{StNo}'";
                        SqlCommand cmd2 = new SqlCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("退货成功！");

                    string sql3 = $"Update SellRecord set SellNum=SellNum-{RtNum} where SellNo='{SellNo}' and Gno='{Gno}'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    cmd3.ExecuteNonQuery();

                    dt = null;
                    dataGridView1.DataSource = dt;
                    DataHandle.ClearControl(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("退货失败！" + ex.Message);
            }
        }

        private void 查看退货记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var returnrecord = new ReturnRecordForm();
            returnrecord.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataHandle.ClearControl(this.Controls);
            dt = null;
        }
    }
}
