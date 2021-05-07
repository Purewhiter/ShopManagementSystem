using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    public partial class AddItems : Form
    {
        public AddItems()
        {
            InitializeComponent();
        }

        private void AddItems_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“goodsCategory._GoodsCategory”中。您可以根据需要移动或删除它。
            this.goodsCategoryTableAdapter.Fill(this.goodsCategory._GoodsCategory);
            // TODO: 这行代码将数据加载到表“shopDataSet2.GoodsList”中。您可以根据需要移动或删除它。
            this.goodsListTableAdapter.Fill(this.shopDataSet2.GoodsList);

        }
    }
}
