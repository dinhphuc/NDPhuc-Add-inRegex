namespace RegEx_FindData
{
    partial class frmFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFind));
            this.rdEmail = new System.Windows.Forms.RadioButton();
            this.rdPhone = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.rdURL = new System.Windows.Forms.RadioButton();
            this.rdDate = new System.Windows.Forms.RadioButton();
            this.grpFind = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputLoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLoc = new System.Windows.Forms.ComboBox();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.radTienTe = new System.Windows.Forms.RadioButton();
            this.radIP = new System.Windows.Forms.RadioButton();
            this.radFile = new System.Windows.Forms.RadioButton();
            this.radCard = new System.Windows.Forms.RadioButton();
            this.dtgvKQ = new System.Windows.Forms.DataGridView();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFind.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKQ)).BeginInit();
            this.SuspendLayout();
            // 
            // rdEmail
            // 
            this.rdEmail.AutoSize = true;
            this.rdEmail.Checked = true;
            this.rdEmail.Location = new System.Drawing.Point(28, 19);
            this.rdEmail.Name = "rdEmail";
            this.rdEmail.Size = new System.Drawing.Size(65, 17);
            this.rdEmail.TabIndex = 10;
            this.rdEmail.TabStop = true;
            this.rdEmail.Text = "Hòm thư";
            this.rdEmail.UseVisualStyleBackColor = true;
            this.rdEmail.CheckedChanged += new System.EventHandler(this.rdEmail_CheckedChanged);
            // 
            // rdPhone
            // 
            this.rdPhone.AutoSize = true;
            this.rdPhone.Location = new System.Drawing.Point(131, 42);
            this.rdPhone.Name = "rdPhone";
            this.rdPhone.Size = new System.Drawing.Size(73, 17);
            this.rdPhone.TabIndex = 20;
            this.rdPhone.Text = "Điện thoại";
            this.rdPhone.UseVisualStyleBackColor = true;
            this.rdPhone.CheckedChanged += new System.EventHandler(this.rdPhone_CheckedChanged);
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Location = new System.Drawing.Point(28, 42);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(70, 17);
            this.rdName.TabIndex = 30;
            this.rdName.Text = "Tên riêng";
            this.rdName.UseVisualStyleBackColor = true;
            this.rdName.CheckedChanged += new System.EventHandler(this.rdName_CheckedChanged);
            // 
            // rdURL
            // 
            this.rdURL.AutoSize = true;
            this.rdURL.Location = new System.Drawing.Point(131, 19);
            this.rdURL.Name = "rdURL";
            this.rdURL.Size = new System.Drawing.Size(83, 17);
            this.rdURL.TabIndex = 40;
            this.rdURL.Text = "Địa chỉ URL";
            this.rdURL.UseVisualStyleBackColor = true;
            this.rdURL.CheckedChanged += new System.EventHandler(this.rdURL_CheckedChanged);
            // 
            // rdDate
            // 
            this.rdDate.AutoSize = true;
            this.rdDate.Location = new System.Drawing.Point(28, 65);
            this.rdDate.Name = "rdDate";
            this.rdDate.Size = new System.Drawing.Size(80, 17);
            this.rdDate.TabIndex = 50;
            this.rdDate.TabStop = true;
            this.rdDate.Text = "Ngày tháng";
            this.rdDate.UseVisualStyleBackColor = true;
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add(this.groupBox2);
            this.grpFind.Controls.Add(this.btnXuatFile);
            this.grpFind.Controls.Add(this.btnFind);
            this.grpFind.Controls.Add(this.rdDate);
            this.grpFind.Controls.Add(this.radTienTe);
            this.grpFind.Controls.Add(this.radIP);
            this.grpFind.Controls.Add(this.radFile);
            this.grpFind.Controls.Add(this.rdURL);
            this.grpFind.Controls.Add(this.rdName);
            this.grpFind.Controls.Add(this.radCard);
            this.grpFind.Controls.Add(this.rdPhone);
            this.grpFind.Controls.Add(this.rdEmail);
            this.grpFind.ForeColor = System.Drawing.Color.MidnightBlue;
            this.grpFind.Location = new System.Drawing.Point(12, 12);
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size(741, 125);
            this.grpFind.TabIndex = 1;
            this.grpFind.TabStop = false;
            this.grpFind.Text = "Lựa chọn thông tin tìm kiếm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inputLoc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbLoc);
            this.groupBox2.Location = new System.Drawing.Point(338, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 107);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc";
            // 
            // inputLoc
            // 
            this.inputLoc.Location = new System.Drawing.Point(161, 63);
            this.inputLoc.Name = "inputLoc";
            this.inputLoc.Size = new System.Drawing.Size(121, 20);
            this.inputLoc.TabIndex = 2;
            this.inputLoc.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thêm điều kiên lọc";
            // 
            // cbLoc
            // 
            this.cbLoc.FormattingEnabled = true;
            this.cbLoc.Location = new System.Drawing.Point(161, 19);
            this.cbLoc.Name = "cbLoc";
            this.cbLoc.Size = new System.Drawing.Size(121, 21);
            this.cbLoc.TabIndex = 0;
            this.cbLoc.SelectedIndexChanged += new System.EventHandler(this.cbLoc_SelectedIndexChanged);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnXuatFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXuatFile.Location = new System.Drawing.Point(658, 71);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(75, 23);
            this.btnXuatFile.TabIndex = 60;
            this.btnXuatFile.Text = "Lưu KQ";
            this.btnXuatFile.UseVisualStyleBackColor = false;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Lime;
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnFind.Location = new System.Drawing.Point(658, 32);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 60;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // radTienTe
            // 
            this.radTienTe.AutoSize = true;
            this.radTienTe.Location = new System.Drawing.Point(233, 42);
            this.radTienTe.Name = "radTienTe";
            this.radTienTe.Size = new System.Drawing.Size(58, 17);
            this.radTienTe.TabIndex = 40;
            this.radTienTe.Text = "Tiền tệ";
            this.radTienTe.UseVisualStyleBackColor = true;
            this.radTienTe.CheckedChanged += new System.EventHandler(this.radTienTe_CheckedChanged);
            // 
            // radIP
            // 
            this.radIP.AutoSize = true;
            this.radIP.Location = new System.Drawing.Point(233, 19);
            this.radIP.Name = "radIP";
            this.radIP.Size = new System.Drawing.Size(35, 17);
            this.radIP.TabIndex = 40;
            this.radIP.Text = "IP";
            this.radIP.UseVisualStyleBackColor = true;
            this.radIP.CheckedChanged += new System.EventHandler(this.radIP_CheckedChanged);
            // 
            // radFile
            // 
            this.radFile.AutoSize = true;
            this.radFile.Location = new System.Drawing.Point(233, 65);
            this.radFile.Name = "radFile";
            this.radFile.Size = new System.Drawing.Size(66, 17);
            this.radFile.TabIndex = 40;
            this.radFile.Text = "Đuôi File";
            this.radFile.UseVisualStyleBackColor = true;
            this.radFile.CheckedChanged += new System.EventHandler(this.radFile_CheckedChanged);
            // 
            // radCard
            // 
            this.radCard.AutoSize = true;
            this.radCard.Location = new System.Drawing.Point(131, 65);
            this.radCard.Name = "radCard";
            this.radCard.Size = new System.Drawing.Size(87, 17);
            this.radCard.TabIndex = 20;
            this.radCard.Text = "Thẻ tín dụng";
            this.radCard.UseVisualStyleBackColor = true;
            this.radCard.CheckedChanged += new System.EventHandler(this.radCard_CheckedChanged);
            // 
            // dtgvKQ
            // 
            this.dtgvKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKQ.Location = new System.Drawing.Point(12, 143);
            this.dtgvKQ.Name = "dtgvKQ";
            this.dtgvKQ.Size = new System.Drawing.Size(741, 428);
            this.dtgvKQ.TabIndex = 2;
            this.dtgvKQ.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKQ_CellClick);
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(552, 592);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(192, 20);
            this.txtLoc.TabIndex = 3;
            this.txtLoc.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lọc kết quả";
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 627);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.dtgvKQ);
            this.Controls.Add(this.grpFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFind";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdEmail;
        private System.Windows.Forms.RadioButton rdPhone;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.RadioButton rdURL;
        private System.Windows.Forms.RadioButton rdDate;
        private System.Windows.Forms.GroupBox grpFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox inputLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLoc;
        private System.Windows.Forms.RadioButton radCard;
        private System.Windows.Forms.RadioButton radIP;
        private System.Windows.Forms.RadioButton radTienTe;
        private System.Windows.Forms.RadioButton radFile;
        private System.Windows.Forms.DataGridView dtgvKQ;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label label1;
    }
}