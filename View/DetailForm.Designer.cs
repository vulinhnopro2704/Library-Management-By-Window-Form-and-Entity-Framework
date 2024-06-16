namespace LibraryManagement.View
{
    partial class DetailForm
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rbCanBorrow = new System.Windows.Forms.RadioButton();
            this.rbReadonly = new System.Windows.Forms.RadioButton();
            this.dtpPublish = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNS = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(351, 335);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(70, 31);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(179, 335);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 31);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rbCanBorrow);
            this.gbType.Controls.Add(this.rbReadonly);
            this.gbType.Location = new System.Drawing.Point(424, 179);
            this.gbType.Margin = new System.Windows.Forms.Padding(2);
            this.gbType.Name = "gbType";
            this.gbType.Padding = new System.Windows.Forms.Padding(2);
            this.gbType.Size = new System.Drawing.Size(200, 121);
            this.gbType.TabIndex = 15;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // rbCanBorrow
            // 
            this.rbCanBorrow.AutoSize = true;
            this.rbCanBorrow.Location = new System.Drawing.Point(110, 51);
            this.rbCanBorrow.Margin = new System.Windows.Forms.Padding(2);
            this.rbCanBorrow.Name = "rbCanBorrow";
            this.rbCanBorrow.Size = new System.Drawing.Size(80, 17);
            this.rbCanBorrow.TabIndex = 0;
            this.rbCanBorrow.TabStop = true;
            this.rbCanBorrow.Text = "Can Borrow";
            this.rbCanBorrow.UseVisualStyleBackColor = true;
            // 
            // rbReadonly
            // 
            this.rbReadonly.AutoSize = true;
            this.rbReadonly.Location = new System.Drawing.Point(20, 51);
            this.rbReadonly.Margin = new System.Windows.Forms.Padding(2);
            this.rbReadonly.Name = "rbReadonly";
            this.rbReadonly.Size = new System.Drawing.Size(70, 17);
            this.rbReadonly.TabIndex = 0;
            this.rbReadonly.TabStop = true;
            this.rbReadonly.Text = "Readonly";
            this.rbReadonly.UseVisualStyleBackColor = true;
            // 
            // dtpPublish
            // 
            this.dtpPublish.Location = new System.Drawing.Point(510, 146);
            this.dtpPublish.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPublish.Name = "dtpPublish";
            this.dtpPublish.Size = new System.Drawing.Size(151, 20);
            this.dtpPublish.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // lbNS
            // 
            this.lbNS.AutoSize = true;
            this.lbNS.Location = new System.Drawing.Point(421, 148);
            this.lbNS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNS.Name = "lbNS";
            this.lbNS.Size = new System.Drawing.Size(63, 13);
            this.lbNS.TabIndex = 12;
            this.lbNS.Text = "Publish Day";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(176, 111);
            this.lbId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(18, 13);
            this.lbId.TabIndex = 13;
            this.lbId.Text = "ID";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(252, 231);
            this.txtQty.Margin = new System.Windows.Forms.Padding(2);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(141, 20);
            this.txtQty.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(252, 148);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 20);
            this.txtName.TabIndex = 7;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(252, 111);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(141, 20);
            this.txtID.TabIndex = 8;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(252, 187);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(141, 20);
            this.txtCategory.TabIndex = 6;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(252, 271);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(141, 20);
            this.txtTotal.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 274);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(499, 111);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(141, 20);
            this.txtAuthor.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Author";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(353, 45);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(108, 25);
            this.title.TabIndex = 20;
            this.title.Text = "Information";
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.title);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.dtpPublish);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtID);
            this.Name = "DetailForm";
            this.Text = "DetailForm";
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rbCanBorrow;
        private System.Windows.Forms.RadioButton rbReadonly;
        private System.Windows.Forms.DateTimePicker dtpPublish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNS;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label title;
    }
}