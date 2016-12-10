namespace XuLyAnhFinal
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picInput = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbImageMode = new System.Windows.Forms.ComboBox();
            this.btnProccess = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.picLogo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1149, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giới thiệu";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(1035, 16);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(108, 104);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1143, 107);
            this.label1.TabIndex = 0;
            this.label1.Text = "Công cụ phân đoạn ảnh sử dụng thuật toán đồ thị.\r\n\r\nNhóm sinh viên thực hiện:\r\n+ " +
    "Ngô Xuân Bách\r\n+ Đào Quang Thắng\r\n\r\nGiảng viên\r\nTS Nguyễn Hữu Quỳnh";
            // 
            // picInput
            // 
            this.picInput.BackColor = System.Drawing.Color.Gainsboro;
            this.picInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picInput.Location = new System.Drawing.Point(3, 16);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(494, 481);
            this.picInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInput.TabIndex = 0;
            this.picInput.TabStop = false;
            this.picInput.Click += new System.EventHandler(this.picInput_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kiểu hiển thị";
            // 
            // cbImageMode
            // 
            this.cbImageMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbImageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageMode.FormattingEnabled = true;
            this.cbImageMode.Items.AddRange(new object[] {
            "Normal",
            "Center",
            "Stretch"});
            this.cbImageMode.Location = new System.Drawing.Point(6, 32);
            this.cbImageMode.Name = "cbImageMode";
            this.cbImageMode.Size = new System.Drawing.Size(125, 21);
            this.cbImageMode.TabIndex = 3;
            this.cbImageMode.SelectedIndexChanged += new System.EventHandler(this.cbImageMode_SelectedIndexChanged);
            // 
            // btnProccess
            // 
            this.btnProccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProccess.Image = ((System.Drawing.Image)(resources.GetObject("btnProccess.Image")));
            this.btnProccess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProccess.Location = new System.Drawing.Point(6, 143);
            this.btnProccess.Name = "btnProccess";
            this.btnProccess.Padding = new System.Windows.Forms.Padding(10);
            this.btnProccess.Size = new System.Drawing.Size(125, 52);
            this.btnProccess.TabIndex = 2;
            this.btnProccess.Text = "Thực thi";
            this.btnProccess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProccess.UseVisualStyleBackColor = true;
            this.btnProccess.Click += new System.EventHandler(this.btnProccess_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnProccess);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbImageMode);
            this.groupBox2.Controls.Add(this.txtN);
            this.groupBox2.Controls.Add(this.txtThreshold);
            this.groupBox2.Location = new System.Drawing.Point(1019, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 201);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tùy chọn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Vùng tối thiểu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngưỡng [0 - 50]";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(6, 117);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(125, 20);
            this.txtN.TabIndex = 1;
            this.txtN.Text = "5";
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(7, 78);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(125, 20);
            this.txtThreshold.TabIndex = 1;
            this.txtThreshold.Text = "5";
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.Gainsboro;
            this.picResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picResult.Location = new System.Drawing.Point(3, 16);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(494, 481);
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picInput);
            this.groupBox3.Location = new System.Drawing.Point(7, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 500);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Click vào để chọn ảnh nguồn";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.picResult);
            this.groupBox4.Location = new System.Drawing.Point(513, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(500, 500);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ảnh sản phẩm";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 641);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xây dựng công cụ phân đoạn ảnh sử dụng thuật toán đồ thị";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnProccess;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.ComboBox cbImageMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

