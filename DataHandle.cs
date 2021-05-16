using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ShopManagementSystem
{
    class DataHandle
    {
        public SqlConnection conn=null;
        public static string connStr = "Data Source=8.129.32.23;Initial Catalog=Shop;User ID=ShopOwner;Password=shoppassw0rd!;MultipleActiveResultSets=true";
        public static void ClearControl(Control.ControlCollection Con)
        {
            foreach (Control C in Con)
            { //遍历可视化组件中的所有控件
                if (C.GetType().Name == "TextBox")  //判断是否为TextBox控件
                    if (((TextBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((TextBox)C).Clear();   //清空当前控件
                if (C.GetType().Name == "MaskedTextBox")  //判断是否为MaskedTextBox控件
                    if (((MaskedTextBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((MaskedTextBox)C).Clear();   //清空当前控件
                if (C.GetType().Name == "ComboBox")  //判断是否为ComboBox控件
                    if (((ComboBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((ComboBox)C).Text = "";   //清空当前控件的Text属性值
                if (C.GetType().Name == "radioButton")  //判断是否为ComboBox控件
                    if (((RadioButton)C).Visible == true)   //判断当前控件是否为显示状态
                        ((RadioButton)C).Checked = false;   //清空当前控件的Text属性值
            }
        }
        public static void Permission()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataHandle.connStr))
                {
                    conn.Open();
                    string sql1 = $"select EmpPost from EmployInfo where UserName='{Program.LoginID}'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        Program.Post = dr1[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库失败！" + ex.Message);
            }

        }
    }
}
