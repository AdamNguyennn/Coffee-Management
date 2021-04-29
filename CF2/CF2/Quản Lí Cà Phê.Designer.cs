namespace CF2
{
    partial class fTablbeManager
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.numDrink = new System.Windows.Forms.NumericUpDown();
            this.bttnAdd = new System.Windows.Forms.Button();
            this.cbDrinks = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.bttnDiscount = new System.Windows.Forms.Button();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.bttnCheckOut = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrink)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(388, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 276);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(1, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(364, 276);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "idDrink";
            this.columnHeader1.Width = 76;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá Tiền";
            this.columnHeader3.Width = 84;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng Giá";
            this.columnHeader4.Width = 131;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.numDrink);
            this.panel5.Controls.Add(this.bttnAdd);
            this.panel5.Controls.Add(this.cbDrinks);
            this.panel5.Controls.Add(this.cbCategory);
            this.panel5.Location = new System.Drawing.Point(388, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(364, 56);
            this.panel5.TabIndex = 4;
            // 
            // numDrink
            // 
            this.numDrink.Location = new System.Drawing.Point(210, 27);
            this.numDrink.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numDrink.Name = "numDrink";
            this.numDrink.Size = new System.Drawing.Size(58, 20);
            this.numDrink.TabIndex = 2;
            this.numDrink.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bttnAdd
            // 
            this.bttnAdd.Location = new System.Drawing.Point(288, 3);
            this.bttnAdd.Name = "bttnAdd";
            this.bttnAdd.Size = new System.Drawing.Size(75, 44);
            this.bttnAdd.TabIndex = 1;
            this.bttnAdd.Text = "Thêm món";
            this.bttnAdd.UseVisualStyleBackColor = true;
            this.bttnAdd.Click += new System.EventHandler(this.bttnAdd_Click);
            // 
            // cbDrinks
            // 
            this.cbDrinks.FormattingEnabled = true;
            this.cbDrinks.Location = new System.Drawing.Point(1, 27);
            this.cbDrinks.Name = "cbDrinks";
            this.cbDrinks.Size = new System.Drawing.Size(203, 21);
            this.cbDrinks.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(0, 0);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(203, 21);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txbTotalPrice);
            this.panel7.Controls.Add(this.bttnDiscount);
            this.panel7.Controls.Add(this.numDiscount);
            this.panel7.Controls.Add(this.bttnCheckOut);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(389, 66);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(363, 48);
            this.panel7.TabIndex = 5;
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txbTotalPrice.Location = new System.Drawing.Point(140, 14);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(127, 22);
            this.txbTotalPrice.TabIndex = 7;
            this.txbTotalPrice.Text = "0";
            this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bttnDiscount
            // 
            this.bttnDiscount.Location = new System.Drawing.Point(36, 0);
            this.bttnDiscount.Name = "bttnDiscount";
            this.bttnDiscount.Size = new System.Drawing.Size(70, 23);
            this.bttnDiscount.TabIndex = 5;
            this.bttnDiscount.Text = "Giảm giá";
            this.bttnDiscount.UseVisualStyleBackColor = true;
            // 
            // numDiscount
            // 
            this.numDiscount.Location = new System.Drawing.Point(36, 28);
            this.numDiscount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(70, 20);
            this.numDiscount.TabIndex = 4;
            // 
            // bttnCheckOut
            // 
            this.bttnCheckOut.Location = new System.Drawing.Point(287, 3);
            this.bttnCheckOut.Name = "bttnCheckOut";
            this.bttnCheckOut.Size = new System.Drawing.Size(75, 44);
            this.bttnCheckOut.TabIndex = 3;
            this.bttnCheckOut.Text = "Thanh toán";
            this.bttnCheckOut.UseVisualStyleBackColor = true;
            this.bttnCheckOut.Click += new System.EventHandler(this.bttnCheckOut_Click);
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(0, -103);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(347, 97);
            this.panel8.TabIndex = 3;
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(12, 39);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(370, 405);
            this.flpTable.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.thôngTinToolStripMenuItem.Text = "Thông Tin";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // fTablbeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "fTablbeManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản_Lí_Cà_Phê";
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDrink)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown numDrink;
        private System.Windows.Forms.Button bttnAdd;
        private System.Windows.Forms.ComboBox cbDrinks;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button bttnDiscount;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Button bttnCheckOut;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbTotalPrice;
    }
}