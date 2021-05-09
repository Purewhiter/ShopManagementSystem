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
    public partial class SaleForm : Form
    {
        public SaleForm()
        {
            InitializeComponent();
        }

        private void 查看商品清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var goodslist = new GoodsListForm();
            goodslist.Show();
        }

        private void 查看库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stockform = new StockForm();
            stockform.Show();
        }
        public DataTable dt = null;//创建数据表，存放待售商品清单
        public decimal Total = 0;//总计
        public string SellNo = null;
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("信息不完整！");
                return;
            }
            if (decimal.Parse(textBox4.Text) > 1)
            {
                MessageBox.Show("折扣异常！");
                return;
            }
            string Gno = textBox1.Text;
            string GoodsPrice = textBox2.Text;
            string SellNum = textBox3.Text;
            string Discount = textBox4.Text;
            string Remark = textBox8.Text;
            string EmpID = null;
            string EmpName;
            if (SellNo == null)
                SellNo = "XS" + DateTime.Now.ToString("yyMMddhhmmss");
            string StNo = null;
            string Gname = null;
            string Unit = null;
            string SellTime = DateTime.Now.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql1 = $"select EmpID,EmpName from EmployInfo where UserName='{Program.LoginID}'";
                    string sql2 = $"select GoodsPrice,Gname,Unit from GoodsList where Gno='{Gno}'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr1.Read())
                    {
                        EmpID = dr1[0].ToString();
                        EmpName = dr1[1].ToString();
                    }
                    if (dr2.Read())
                    {
                        GoodsPrice = dr2[0].ToString();
                        Gname = dr2[1].ToString();
                        Unit = dr2[2].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加-连接数据库失败！" + ex.Message);
            }

            try
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("SellNo", typeof(string));
                    dt.Columns.Add("Gno", typeof(string));
                    dt.Columns.Add("StNo", typeof(string));
                    dt.Columns.Add("Gname", typeof(string));
                    dt.Columns.Add("SellNum", typeof(string));
                    dt.Columns.Add("Unit", typeof(string));
                    dt.Columns.Add("GoodsPrice", typeof(string));
                    dt.Columns.Add("Discount", typeof(string));
                    dt.Columns.Add("SellTime", typeof(string));
                    dt.Columns.Add("EmpID", typeof(string));
                    dt.Columns.Add("Remark", typeof(string));
                }
                dt.Rows.Add(SellNo, Gno, StNo, Gname, SellNum, Unit, GoodsPrice, Discount, SellTime, EmpID, Remark);
                //设置dataGridView
                Total += decimal.Parse(textBox5.Text);
                textBox7.Text = Total.ToString();
                dataGridView1.DataSource = dt;

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox5.Text = null;
                textBox8.Text = null;
                //设置数据表格上显示的列标题
                dataGridView1.Columns[0].HeaderText = "销售编号";
                dataGridView1.Columns[3].HeaderText = "商品名称";
                dataGridView1.Columns[4].HeaderText = "销售数量";
                dataGridView1.Columns[5].HeaderText = "单位";
                dataGridView1.Columns[6].HeaderText = "单价";
                dataGridView1.Columns[7].HeaderText = "折扣率";
                dataGridView1.Columns[10].HeaderText = "备注";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
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
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Gno = textBox1.Text;
            try
            {
                using (SqlConnection conn1 = new SqlConnection(DataHandle.connStr))
                {
                    conn1.Open();
                    string sql3 = $"select GoodsPrice,Gname,Unit from GoodsList where Gno='{Gno}'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn1);
                    SqlDataReader dr3 = cmd3.ExecuteReader();

                    if (dr3.Read())
                    {
                        textBox2.Text = dr3[0].ToString();
                    }
                    conn1.Close();
                    if (textBox3.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                        textBox5.Text = (decimal.Parse(textBox3.Text) * decimal.Parse(textBox2.Text) * decimal.Parse(textBox4.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库失败！" + ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                textBox5.Text = (decimal.Parse(textBox3.Text) * decimal.Parse(textBox2.Text) * decimal.Parse(textBox4.Text)).ToString();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //DataRowView drv = dataGridView2.SelectedRows[0].DataBoundItem as DataRowView;
                //drv.Row.Table.Rows.Remove(drv.Row); // 将要删除的行移除，更新时不影响数据库。
                //drv.Row.Delete(); // 对绑定的DataTable的选中行做删除标记，向DB更新时，DB的对应行也被删除。
                string gno = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                var dr1 = dt.Select($"Gno='{gno}'"); //注意加单引号
                if (dr1 != null && dr1.Count() > 0)
                {
                    foreach (DataRow row in dr1)
                    {
                        Total -= decimal.Parse(row[4].ToString()) * decimal.Parse(row[6].ToString()) * decimal.Parse(row[7].ToString());
                        textBox7.Text = Total.ToString();
                        dt.Rows.Remove(row);
                    }
                }
                MessageBox.Show("删除成功！");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！" + ex.Message);
            }
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt = null;
            dataGridView1.DataSource = dt;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox5.Text = null;
            textBox8.Text = null;
            Total = 0;
            textBox4.Text = "1";
            textBox7.Text = null;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dt==null||dt.Rows.Count==0)
            {
                MessageBox.Show("信息有误！");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();

                    foreach (DataRow row in dt.Rows)
                    {
                        string Gno = row[1].ToString();
                        string num = row[4].ToString();
                        string sql3 = $"set rowcount 1;select StNo from GoodsStock where Gno='{Gno}' and StockNum>={num};set rowcount 0";
                        SqlCommand cmd3 = new SqlCommand(sql3, conn);
                        SqlDataReader dr = cmd3.ExecuteReader();
                        if (dr.Read())
                        {
                            row.BeginEdit();
                            row["StNo"] = dr[0].ToString();
                            row.EndEdit();
                        }
                        else
                        {
                            MessageBox.Show("库存不足！");
                            return;
                        }
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        string Gno = row[1].ToString();
                        string num = row[4].ToString();
                        string sql2 = $"set rowcount 1;update GoodsStock set StockNum=StockNum-{num} where Gno='{Gno}' and StockNum>={num};set rowcount 0";
                        SqlCommand cmd2 = new SqlCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                    }

                    string sql1 = "select * from SellRecord";
                    SqlDataAdapter sda1 = new SqlDataAdapter(sql1, conn);
                    DataTable dtNew = new DataTable();
                    sda1.Fill(dtNew);
                    SqlCommandBuilder cmdBuilder1 = new SqlCommandBuilder(sda1);
                    foreach (DataRow row in dt.Rows)
                    //dtNew.ImportRow(row);
                    {
                        string SellNo = row[0].ToString();
                        string Gno= row[1].ToString();
                        string StNo= row[2].ToString();
                        string SellNum= row[4].ToString();
                        string Discount= row[7].ToString();
                        string SellTime= row[8].ToString();
                        string EmpID= row[9].ToString();
                        string Remark= row[10].ToString();
                        string GoodsPrice= row[6].ToString();
                        string sql4 = $"Insert into SellRecord values('{SellNo}','{Gno}','{StNo}','{GoodsPrice}','{SellNum}',{Discount},'{SellTime}','{EmpID}','{Remark}')";
                        SqlCommand cmd4 = new SqlCommand(sql4, conn);
                        cmd4.ExecuteNonQuery();
                    }
                    sda1.Update(dtNew);

                    MessageBox.Show("结算成功！");
                    dt = null;
                    dataGridView1.DataSource = dt;
                    Total = 0;
                    DataHandle.ClearControl(this.Controls);
                    textBox4.Text = "1";
                    SellNo = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("结算失败！" + ex.Message);
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataHandle.ClearControl(this.Controls);
            textBox4.Text = "1";
            SellNo = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            添加ToolStripMenuItem_Click(this, e);
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            string EmpName = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    //打开数据库
                    conn.Open();
                    string sql1 = $"select EmpName from EmployInfo where UserName='{Program.LoginID}'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        EmpName = dr1[0].ToString();
                        textBox6.Text = EmpName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("退货失败！" + ex.Message);
            }
        }
    }
}
