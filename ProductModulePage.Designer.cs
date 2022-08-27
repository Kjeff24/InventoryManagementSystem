namespace InventoryManagementSystem
{
    partial class ProductModulePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductModulePage));
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupd = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtprodDes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtprodPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtprodQuan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtprodName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboQty = new System.Windows.Forms.ComboBox();
            this.lblpid = new System.Windows.Forms.Label();
            this.pboxbarcode = new System.Windows.Forms.PictureBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bntgenerate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxbarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Cyan;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(508, 384);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(84, 30);
            this.btnsave.TabIndex = 29;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupd
            // 
            this.btnupd.BackColor = System.Drawing.Color.Red;
            this.btnupd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupd.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupd.Location = new System.Drawing.Point(598, 384);
            this.btnupd.Name = "btnupd";
            this.btnupd.Size = new System.Drawing.Size(75, 30);
            this.btnupd.TabIndex = 28;
            this.btnupd.Text = "Update";
            this.btnupd.UseVisualStyleBackColor = false;
            this.btnupd.Click += new System.EventHandler(this.btnupd_Click);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclear.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(679, 384);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 30);
            this.btnclear.TabIndex = 27;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Category";
            // 
            // txtprodDes
            // 
            this.txtprodDes.Location = new System.Drawing.Point(175, 202);
            this.txtprodDes.Name = "txtprodDes";
            this.txtprodDes.Size = new System.Drawing.Size(289, 22);
            this.txtprodDes.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Description:";
            // 
            // txtprodPrice
            // 
            this.txtprodPrice.Location = new System.Drawing.Point(175, 160);
            this.txtprodPrice.Name = "txtprodPrice";
            this.txtprodPrice.Size = new System.Drawing.Size(289, 22);
            this.txtprodPrice.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Price:";
            // 
            // txtprodQuan
            // 
            this.txtprodQuan.Location = new System.Drawing.Point(175, 118);
            this.txtprodQuan.Name = "txtprodQuan";
            this.txtprodQuan.Size = new System.Drawing.Size(289, 22);
            this.txtprodQuan.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Quantity";
            // 
            // txtprodName
            // 
            this.txtprodName.Location = new System.Drawing.Point(175, 76);
            this.txtprodName.Name = "txtprodName";
            this.txtprodName.Size = new System.Drawing.Size(289, 22);
            this.txtprodName.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Product Name:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 56);
            this.panel1.TabIndex = 16;
            // 
            // closebtn
            // 
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.Image = ((System.Drawing.Image)(resources.GetObject("closebtn.Image")));
            this.closebtn.Location = new System.Drawing.Point(748, 0);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(22, 30);
            this.closebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closebtn.TabIndex = 8;
            this.closebtn.TabStop = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Module";
            // 
            // comboQty
            // 
            this.comboQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQty.FormattingEnabled = true;
            this.comboQty.Location = new System.Drawing.Point(175, 242);
            this.comboQty.Name = "comboQty";
            this.comboQty.Size = new System.Drawing.Size(289, 25);
            this.comboQty.TabIndex = 30;
            // 
            // lblpid
            // 
            this.lblpid.AutoSize = true;
            this.lblpid.Location = new System.Drawing.Point(33, 391);
            this.lblpid.Name = "lblpid";
            this.lblpid.Size = new System.Drawing.Size(69, 17);
            this.lblpid.TabIndex = 31;
            this.lblpid.Text = "Product Id";
            this.lblpid.Visible = false;
            // 
            // pboxbarcode
            // 
            this.pboxbarcode.Location = new System.Drawing.Point(488, 76);
            this.pboxbarcode.Name = "pboxbarcode";
            this.pboxbarcode.Size = new System.Drawing.Size(266, 234);
            this.pboxbarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxbarcode.TabIndex = 32;
            this.pboxbarcode.TabStop = false;
            // 
            // txtbarcode
            // 
            this.txtbarcode.Location = new System.Drawing.Point(175, 288);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(289, 22);
            this.txtbarcode.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "BarCode:";
            // 
            // bntgenerate
            // 
            this.bntgenerate.BackColor = System.Drawing.Color.Black;
            this.bntgenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntgenerate.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntgenerate.ForeColor = System.Drawing.Color.White;
            this.bntgenerate.Location = new System.Drawing.Point(380, 316);
            this.bntgenerate.Name = "bntgenerate";
            this.bntgenerate.Size = new System.Drawing.Size(84, 30);
            this.bntgenerate.TabIndex = 35;
            this.bntgenerate.Text = "Generate";
            this.bntgenerate.UseVisualStyleBackColor = false;
            this.bntgenerate.Click += new System.EventHandler(this.bntgenerate_Click);
            // 
            // ProductModulePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 443);
            this.Controls.Add(this.bntgenerate);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pboxbarcode);
            this.Controls.Add(this.lblpid);
            this.Controls.Add(this.comboQty);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnupd);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtprodDes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtprodPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtprodQuan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtprodName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductModulePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxbarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnsave;
        public System.Windows.Forms.Button btnupd;
        public System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtprodDes;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtprodPrice;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtprodQuan;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtprodName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox closebtn;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboQty;
        public System.Windows.Forms.Label lblpid;
        private System.Windows.Forms.PictureBox pboxbarcode;
        public System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button bntgenerate;
    }
}