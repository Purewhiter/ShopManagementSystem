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
    public partial class ReplenishForm : Form
    {
        public ReplenishForm()
        {
            InitializeComponent();
        }
        private void QueryAllInfo1()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select * from Supplier";
                    //创建SqlDataAdapter类的对象
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView1.DataSource = ds.Tables[0];
                    //设置数据表格上显示的列标题
                    dataGridView1.Columns[0].HeaderText = "供应商ID";
                    dataGridView1.Columns[1].HeaderText = "供应商名称";
                    dataGridView1.Columns[2].HeaderText = "联系人";
                    dataGridView1.Columns[3].HeaderText = "联系电话";
                    dataGridView1.Columns[4].HeaderText = "地址";
                    dataGridView1.Columns[5].HeaderText = "备注";
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
        private void QueryAllInfo2()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"select * from ReplenishDetail";
                    //创建SqlDataAdapter类的对象
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    //设置表格控件的DataSource属性
                    dataGridView3.DataSource = ds.Tables[0];
                    //设置数据表格上显示的列标题
                    dataGridView3.Columns[0].HeaderText = "进货编号";
                    dataGridView3.Columns[1].HeaderText = "商品编号";
                    dataGridView3.Columns[2].HeaderText = "商品名称";
                    dataGridView3.Columns[3].HeaderText = "供应商名称";
                    dataGridView3.Columns[4].HeaderText = "成本单价";
                    dataGridView3.Columns[5].HeaderText = "进货数量";
                    dataGridView3.Columns[1].HeaderText = "金额";
                    dataGridView3.Columns[2].HeaderText = "进货时间";
                    dataGridView3.Columns[3].HeaderText = "过期时间";
                    dataGridView3.Columns[4].HeaderText = "进货人姓名";
                    dataGridView3.Columns[5].HeaderText = "备注";
                    //设置数据表格为只读
                    dataGridView3.ReadOnly = true;
                    //不允许添加行
                    dataGridView3.AllowUserToAddRows = false;
                    //背景为白色
                    dataGridView3.BackgroundColor = Color.White;
                    //只允许选中单行
                    dataGridView3.MultiSelect = false;
                    //整行选中
                    dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
            }
        }
        string EmpID = null;
        private void ReplenishForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“shopDataSet3.Supplier”中。您可以根据需要移动或删除它。
            this.supplierTableAdapter1.Fill(this.shopDataSet3.Supplier);
            // TODO: 这行代码将数据加载到表“replenishDetail._ReplenishDetail”中。您可以根据需要移动或删除它。
            this.replenishDetailTableAdapter.Fill(this.replenishDetail._ReplenishDetail);
            // TODO: 这行代码将数据加载到表“shopDataSet2.ReplenishGoods”中。您可以根据需要移动或删除它。
            this.replenishGoodsTableAdapter.Fill(this.shopDataSet2.ReplenishGoods);
            // TODO: 这行代码将数据加载到表“shopDataSet2.GoodsList”中。您可以根据需要移动或删除它。
            this.goodsListTableAdapter.Fill(this.shopDataSet2.GoodsList);
            // TODO: 这行代码将数据加载到表“shopDataSet2.Supplier”中。您可以根据需要移动或删除它。
            this.supplierTableAdapter.Fill(this.shopDataSet2.Supplier);
            QueryAllInfo1();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("退货失败！" + ex.Message);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryAllInfo1();
            QueryAllInfo2();
        }

        private void 查看已有商品清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var goodslist = new GoodsListForm();
            goodslist.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string spname = textBox2.Text;
            string dirname = textBox3.Text;
            string phone = textBox4.Text;
            string address = textBox5.Text;
            string remark = textBox6.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"Insert into Supplier values('{ID}',N'{spname}',N'{dirname}',N'{phone}',N'{address}',N'{remark}')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功！"+Program.LoginID);
                    QueryAllInfo1();
                    DataHandle.ClearControl(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！" + ex.Message);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//ID
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//供应商名称
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//联系人
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//联系电话
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();//地址
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();//备注
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string spname = textBox2.Text;
            string dirname = textBox3.Text;
            string phone = textBox4.Text;
            string address = textBox5.Text;
            string remark = textBox6.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql = $"Update Supplier set SpID='{ID}',SpName=N'{spname}',SpDirector=N'{dirname}',SpPhone=N'{phone}',SpAddress=N'{address}',SpRemark=N'{remark}' where SpID=N'{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功！");
                    QueryAllInfo1();
                    DataHandle.ClearControl(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！" + ex.Message);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void 查看库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stockform = new StockForm();
            stockform.Show();
        }

        public DataTable dt = null;//创建数据表，存放进货商品清单
        public DataTable dtStock = null;//创建数据表，存放待加入库存商品清单
        public string Rpno = null;
        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox7.Text==""|| textBox8.Text == "" || textBox11.Text == "" ||comboBox1.Text=="")
            {
                MessageBox.Show("请输入完整信息！");
            }
            if (Rpno == null)
                Rpno = "JH" + DateTime.Now.ToString("yyMMddhhmmss");
            string Gno = textBox11.Text;
            string SpName = comboBox1.Text;
            string SpID = null;
            string CostPrice = textBox8.Text;
            string RpNum = textBox7.Text;
            string RpTime = dateTimePicker1.Value.ToString();
            string ExpirDate = dateTimePicker2.Value.ToString();
            string RpRemark = textBox15.Text;

            string StNo= "KC"+Rpno+Gno;
            string StockNum = RpNum;
            try
            {
                using (SqlConnection conn1 = new SqlConnection(DataHandle.connStr))
                {
                    conn1.Open();
                    string sql3 = $"select SpID from Supplier where SpName=N'{SpName}'";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn1);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {
                        SpID = dr3[0].ToString();
                    }
                    conn1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库失败！" + ex.Message);
            }
            try
            {
                if(dt==null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("Rpno", typeof(string));
                    dt.Columns.Add("Gno", typeof(string));
                    dt.Columns.Add("EmpID", typeof(string));
                    dt.Columns.Add("SpID", typeof(string));
                    dt.Columns.Add("CostPrice", typeof(string));
                    dt.Columns.Add("RpNum", typeof(string));
                    dt.Columns.Add("RpTime", typeof(string));
                    dt.Columns.Add("ExpirDate", typeof(string));
                    dt.Columns.Add("RpRemark", typeof(string));
                }
                if (dtStock == null)
                {
                    dtStock = new DataTable();
                    dtStock.Columns.Add("StNo", typeof(string));
                    dtStock.Columns.Add("Gno", typeof(string));
                    dtStock.Columns.Add("StockNum", typeof(string));
                    dtStock.Columns.Add("ExpirDate", typeof(string));
                    dtStock.Columns.Add("Rpno", typeof(string));
                }
                //DataRow dr = dt.NewRow();
                //dr["Rpno"] = Rpno;
                //dr["Gno"] = Gno;
                //dr["EmpID"] = EmpID;
                //dr["SpID"] = SpID;
                //dr["CostPrice"] = CostPrice;
                //dr["RpNum"] = RpNum;
                //dr["RpTime"] = RpTime;
                //dr["ExpirDate"] = ExpirDate;
                //dr["RpRemark"] = RpRemark;
                //dr[0] = Rpno;
                //dr[1] = Gno;
                //dr[2] = EmpID;
                //dr[3] = SpID;
                //dr[4] = CostPrice;
                //dr[5] = RpNum;
                //dr[6] = RpTime;
                //dr[7] = ExpirDate;
                //dr[8] = RpRemark;

                dt.Rows.Add(Rpno, Gno, EmpID, SpID, CostPrice, RpNum, RpTime, ExpirDate, RpRemark);
                dtStock.Rows.Add(StNo, Gno, StockNum, ExpirDate,Rpno);
                //设置dataGridView
                dataGridView2.DataSource = dt;
                //设置数据表格上显示的列标题
                dataGridView2.Columns[0].HeaderText = "进货编号";
                dataGridView2.Columns[1].HeaderText = "商品编号";
                dataGridView2.Columns[2].HeaderText = "进货人ID";
                dataGridView2.Columns[3].HeaderText = "供应商ID";
                dataGridView2.Columns[4].HeaderText = "进货单价";
                dataGridView2.Columns[5].HeaderText = "进货数量";
                dataGridView2.Columns[6].HeaderText = "进货时间";
                dataGridView2.Columns[7].HeaderText = "过期时间";
                dataGridView2.Columns[8].HeaderText = "备注";
                //设置数据表格为只读
                dataGridView2.ReadOnly = true;
                //不允许添加行
                dataGridView2.AllowUserToAddRows = false;
                //背景为白色
                dataGridView2.BackgroundColor = Color.White;
                //只允许选中单行
                dataGridView2.MultiSelect = false;
                //整行选中
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！" + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //DataRowView drv = dataGridView2.SelectedRows[0].DataBoundItem as DataRowView;
                //drv.Row.Table.Rows.Remove(drv.Row); // 将要删除的行移除，更新时不影响数据库。
                //drv.Row.Delete(); // 对绑定的DataTable的选中行做删除标记，向DB更新时，DB的对应行也被删除。
                string gno = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();

                var dr1 = dt.Select($"Gno='{gno}'"); //注意加单引号
                if (dr1 != null && dr1.Count() > 0)
                {
                    foreach (DataRow row in dr1)
                    {
                        dt.Rows.Remove(row);
                    }
                }
                var dr2 = dtStock.Select($"Gno='{gno}'"); //注意加单引号
                if (dr2 != null && dr2.Count() > 0)
                {
                    foreach (DataRow row in dr2)
                    {
                        dtStock.Rows.Remove(row);
                    }
                }
                MessageBox.Show("删除成功！");
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！" + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataHandle.ClearControl(this.tabControl1.TabPages[2].Controls);
            dt = null;
            dataGridView2.DataSource = dt;
            Rpno = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();

                    string sql1 = "select * from ReplenishGoods";
                    SqlDataAdapter sda1 = new SqlDataAdapter(sql1, conn);
                    DataTable dtNew = new DataTable();
                    sda1.Fill(dtNew);
                    SqlCommandBuilder cmdBuilder1 = new SqlCommandBuilder(sda1);
                    foreach (DataRow row in dt.Rows)
                        dtNew.ImportRow(row);
                    sda1.Update(dtNew);
                
                    string sql2 = "select * from GoodsStock";
                    SqlDataAdapter sda2 = new SqlDataAdapter(sql2, conn);
                    DataTable dtNewStock = new DataTable();
                    sda2.Fill(dtNewStock);
                    SqlCommandBuilder cmdBuilder2 = new SqlCommandBuilder(sda2);
                    foreach (DataRow row in dtStock.Rows)
                        dtNewStock.ImportRow(row);
                    sda2.Update(dtNewStock);

                    MessageBox.Show("进货成功！");
                    dt = null;
                    dtStock = null;
                    Rpno = null;
                    dataGridView2.DataSource = dt;
                    DataHandle.ClearControl(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("进货失败！" + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //textBox12.Text = "JH" + DateTime.Now.ToString("yyMMddhhmmss");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
