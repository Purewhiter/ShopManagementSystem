
namespace ShopManagementSystem
{
    partial class HumanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HumanForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加员工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除员工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新F5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopDataSet = new ShopManagementSystem.ShopDataSet();
            this.employInfoTableAdapter = new ShopManagementSystem.ShopDataSetTableAdapters.EmployInfoTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.shopDataSet1 = new ShopManagementSystem.ShopDataSet1();
            this.employInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employInfoTableAdapter1 = new ShopManagementSystem.ShopDataSet1TableAdapters.EmployInfoTableAdapter();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加员工ToolStripMenuItem,
            this.修改信息ToolStripMenuItem,
            this.删除员工ToolStripMenuItem,
            this.刷新F5ToolStripMenuItem,
            this.清空PToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripTextBox1,
            this.toolStripMenuItem2,
            this.退出QToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1119, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加员工ToolStripMenuItem
            // 
            this.添加员工ToolStripMenuItem.Name = "添加员工ToolStripMenuItem";
            this.添加员工ToolStripMenuItem.Size = new System.Drawing.Size(104, 27);
            this.添加员工ToolStripMenuItem.Text = "添加员工(&A)";
            this.添加员工ToolStripMenuItem.Click += new System.EventHandler(this.添加员工ToolStripMenuItem_Click);
            // 
            // 修改信息ToolStripMenuItem
            // 
            this.修改信息ToolStripMenuItem.Name = "修改信息ToolStripMenuItem";
            this.修改信息ToolStripMenuItem.Size = new System.Drawing.Size(133, 27);
            this.修改信息ToolStripMenuItem.Text = "修改员工信息(&C)";
            this.修改信息ToolStripMenuItem.Click += new System.EventHandler(this.修改信息ToolStripMenuItem_Click);
            // 
            // 删除员工ToolStripMenuItem
            // 
            this.删除员工ToolStripMenuItem.Name = "删除员工ToolStripMenuItem";
            this.删除员工ToolStripMenuItem.Size = new System.Drawing.Size(104, 27);
            this.删除员工ToolStripMenuItem.Text = "删除员工(&D)";
            this.删除员工ToolStripMenuItem.Click += new System.EventHandler(this.删除员工ToolStripMenuItem_Click);
            // 
            // 刷新F5ToolStripMenuItem
            // 
            this.刷新F5ToolStripMenuItem.Name = "刷新F5ToolStripMenuItem";
            this.刷新F5ToolStripMenuItem.Size = new System.Drawing.Size(71, 27);
            this.刷新F5ToolStripMenuItem.Text = "刷新(&F)";
            this.刷新F5ToolStripMenuItem.Click += new System.EventHandler(this.刷新F5ToolStripMenuItem_Click);
            // 
            // 清空PToolStripMenuItem
            // 
            this.清空PToolStripMenuItem.Name = "清空PToolStripMenuItem";
            this.清空PToolStripMenuItem.Size = new System.Drawing.Size(72, 27);
            this.清空PToolStripMenuItem.Text = "清空(&P)";
            this.清空PToolStripMenuItem.Click += new System.EventHandler(this.清空PToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 27);
            this.toolStripMenuItem1.Text = "输入查询姓名：";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(53, 27);
            this.toolStripMenuItem2.Text = "查找";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 退出QToolStripMenuItem
            // 
            this.退出QToolStripMenuItem.Name = "退出QToolStripMenuItem";
            this.退出QToolStripMenuItem.Size = new System.Drawing.Size(75, 27);
            this.退出QToolStripMenuItem.Text = "退出(&Q)";
            this.退出QToolStripMenuItem.Click += new System.EventHandler(this.退出QToolStripMenuItem_Click);
            // 
            // shopDataSet
            // 
            this.shopDataSet.DataSetName = "ShopDataSet";
            this.shopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employInfoTableAdapter
            // 
            this.employInfoTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "姓名：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 34);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 25);
            this.textBox1.TabIndex = 32;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(99, 77);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 19);
            this.radioButton1.TabIndex = 35;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "男";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(188, 77);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 19);
            this.radioButton2.TabIndex = 36;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "女";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(604, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "住址：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(667, 35);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(130, 25);
            this.textBox4.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 213);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 43;
            this.label6.Text = "联系电话：";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(99, 209);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(132, 25);
            this.textBox5.TabIndex = 44;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "管理员",
            "店长",
            "收银员",
            "售货员",
            "进货员"});
            this.comboBox1.Location = new System.Drawing.Point(392, 213);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 23);
            this.comboBox1.TabIndex = 60;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 216);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 53;
            this.label11.Text = "职位：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(604, 139);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 58;
            this.label13.Text = "备注：";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(667, 139);
            this.textBox12.Margin = new System.Windows.Forms.Padding(4);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(202, 112);
            this.textBox12.TabIndex = 59;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(392, 37);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 25);
            this.dateTimePicker1.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "出生日期：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 271);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1119, 216);
            this.dataGridView1.TabIndex = 61;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // shopDataSet1
            // 
            this.shopDataSet1.DataSetName = "ShopDataSet1";
            this.shopDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employInfoBindingSource
            // 
            this.employInfoBindingSource.DataMember = "EmployInfo";
            this.employInfoBindingSource.DataSource = this.shopDataSet1;
            // 
            // employInfoTableAdapter1
            // 
            this.employInfoTableAdapter1.ClearBeforeFill = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(392, 136);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(132, 25);
            this.dateTimePicker2.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 62;
            this.label2.Text = "入职日期：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(99, 136);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 25);
            this.textBox2.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 64;
            this.label3.Text = "员工ID：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(918, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 59);
            this.button1.TabIndex = 66;
            this.button1.Text = "读取选中行数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HumanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 485);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HumanForm";
            this.Text = "人事管理";
            this.Load += new System.EventHandler(this.HumanForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加员工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除员工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新F5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出QToolStripMenuItem;
        private ShopDataSet shopDataSet;
        private ShopDataSetTableAdapters.EmployInfoTableAdapter employInfoTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem 清空PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ShopDataSet1 shopDataSet1;
        private System.Windows.Forms.BindingSource employInfoBindingSource;
        private ShopDataSet1TableAdapters.EmployInfoTableAdapter employInfoTableAdapter1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}