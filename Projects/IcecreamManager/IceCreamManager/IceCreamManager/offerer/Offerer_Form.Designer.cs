﻿namespace IceCreamManager
{
    partial class Offerer_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Offerer_Form));
            this.dgvOfferer = new System.Windows.Forms.DataGridView();
            this.cmsOfferer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.상세정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.cmsMat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProduct = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblmatName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblmatMoney = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblmat_Each = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOffererName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblmatType = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbbSearchType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbbfilter1 = new System.Windows.Forms.ComboBox();
            this.cbbfilter2 = new System.Windows.Forms.ComboBox();
            this.btnSearch2 = new System.Windows.Forms.Button();
            this.ptbRefresh = new System.Windows.Forms.PictureBox();
            this.picOrder = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferer)).BeginInit();
            this.cmsOfferer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.cmsMat.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOfferer
            // 
            this.dgvOfferer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOfferer.BackgroundColor = System.Drawing.Color.White;
            this.dgvOfferer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfferer.ContextMenuStrip = this.cmsOfferer;
            this.dgvOfferer.Location = new System.Drawing.Point(9, 50);
            this.dgvOfferer.Name = "dgvOfferer";
            this.dgvOfferer.RowHeadersWidth = 51;
            this.dgvOfferer.RowTemplate.Height = 23;
            this.dgvOfferer.Size = new System.Drawing.Size(294, 598);
            this.dgvOfferer.TabIndex = 0;
            this.dgvOfferer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfferer_CellDoubleClick);
            // 
            // cmsOfferer
            // 
            this.cmsOfferer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상세정보ToolStripMenuItem});
            this.cmsOfferer.Name = "cmsOfferer";
            this.cmsOfferer.Size = new System.Drawing.Size(123, 26);
            // 
            // 상세정보ToolStripMenuItem
            // 
            this.상세정보ToolStripMenuItem.Name = "상세정보ToolStripMenuItem";
            this.상세정보ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.상세정보ToolStripMenuItem.Text = "상세정보";
            this.상세정보ToolStripMenuItem.Click += new System.EventHandler(this.상세정보ToolStripMenuItem_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.ContextMenuStrip = this.cmsMat;
            this.dgvProduct.Location = new System.Drawing.Point(304, 50);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.Size = new System.Drawing.Size(540, 361);
            this.dgvProduct.TabIndex = 2;
            this.dgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellDoubleClick);
            // 
            // cmsMat
            // 
            this.cmsMat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.수정ToolStripMenuItem,
            this.삭제ToolStripMenuItem});
            this.cmsMat.Name = "cmsMat";
            this.cmsMat.Size = new System.Drawing.Size(99, 48);
            // 
            // 수정ToolStripMenuItem
            // 
            this.수정ToolStripMenuItem.Name = "수정ToolStripMenuItem";
            this.수정ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.수정ToolStripMenuItem.Text = "수정";
            this.수정ToolStripMenuItem.Click += new System.EventHandler(this.수정ToolStripMenuItem_Click);
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.삭제ToolStripMenuItem.Text = "삭제";
            this.삭제ToolStripMenuItem.Click += new System.EventHandler(this.삭제ToolStripMenuItem_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnProduct.Location = new System.Drawing.Point(769, 645);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(75, 23);
            this.btnProduct.TabIndex = 6;
            this.btnProduct.Text = "제품등록";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(740, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "코드";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(330, 602);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "개수";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(330, 534);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "가격";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(327, 500);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "자재이름";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(327, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "거래처명";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(330, 568);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 44;
            this.label8.Text = "자재타입";
            // 
            // lblCode
            // 
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCode.AutoSize = true;
            this.lblCode.ForeColor = System.Drawing.Color.White;
            this.lblCode.Location = new System.Drawing.Point(775, 426);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(0, 12);
            this.lblCode.TabIndex = 47;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblmatName);
            this.panel2.Location = new System.Drawing.Point(406, 492);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 28);
            this.panel2.TabIndex = 47;
            // 
            // lblmatName
            // 
            this.lblmatName.AutoSize = true;
            this.lblmatName.ForeColor = System.Drawing.Color.White;
            this.lblmatName.Location = new System.Drawing.Point(3, 7);
            this.lblmatName.Name = "lblmatName";
            this.lblmatName.Size = new System.Drawing.Size(0, 12);
            this.lblmatName.TabIndex = 47;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblmatMoney);
            this.panel3.Location = new System.Drawing.Point(406, 526);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 28);
            this.panel3.TabIndex = 48;
            // 
            // lblmatMoney
            // 
            this.lblmatMoney.AutoSize = true;
            this.lblmatMoney.ForeColor = System.Drawing.Color.White;
            this.lblmatMoney.Location = new System.Drawing.Point(3, 7);
            this.lblmatMoney.Name = "lblmatMoney";
            this.lblmatMoney.Size = new System.Drawing.Size(0, 12);
            this.lblmatMoney.TabIndex = 47;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblmat_Each);
            this.panel4.Location = new System.Drawing.Point(406, 594);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(328, 28);
            this.panel4.TabIndex = 49;
            // 
            // lblmat_Each
            // 
            this.lblmat_Each.AutoSize = true;
            this.lblmat_Each.ForeColor = System.Drawing.Color.White;
            this.lblmat_Each.Location = new System.Drawing.Point(3, 7);
            this.lblmat_Each.Name = "lblmat_Each";
            this.lblmat_Each.Size = new System.Drawing.Size(0, 12);
            this.lblmat_Each.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(740, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 50;
            this.label10.Text = "원";
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(740, 602);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 12);
            this.lblType.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblOffererName);
            this.panel1.Location = new System.Drawing.Point(406, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 28);
            this.panel1.TabIndex = 52;
            // 
            // lblOffererName
            // 
            this.lblOffererName.AutoSize = true;
            this.lblOffererName.ForeColor = System.Drawing.Color.White;
            this.lblOffererName.Location = new System.Drawing.Point(3, 7);
            this.lblOffererName.Name = "lblOffererName";
            this.lblOffererName.Size = new System.Drawing.Size(0, 12);
            this.lblOffererName.TabIndex = 47;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblmatType);
            this.panel5.Location = new System.Drawing.Point(406, 560);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(328, 28);
            this.panel5.TabIndex = 53;
            // 
            // lblmatType
            // 
            this.lblmatType.AutoSize = true;
            this.lblmatType.ForeColor = System.Drawing.Color.White;
            this.lblmatType.Location = new System.Drawing.Point(3, 7);
            this.lblmatType.Name = "lblmatType";
            this.lblmatType.Size = new System.Drawing.Size(0, 12);
            this.lblmatType.TabIndex = 47;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtSearch.Location = new System.Drawing.Point(583, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 21);
            this.txtSearch.TabIndex = 57;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            // 
            // cbbSearchType
            // 
            this.cbbSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSearchType.FormattingEnabled = true;
            this.cbbSearchType.Items.AddRange(new object[] {
            "제품",
            "제조사"});
            this.cbbSearchType.Location = new System.Drawing.Point(456, 24);
            this.cbbSearchType.Name = "cbbSearchType";
            this.cbbSearchType.Size = new System.Drawing.Size(121, 20);
            this.cbbSearchType.TabIndex = 58;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSearch.Location = new System.Drawing.Point(689, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 59;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cbbfilter1
            // 
            this.cbbfilter1.FormattingEnabled = true;
            this.cbbfilter1.Location = new System.Drawing.Point(9, 21);
            this.cbbfilter1.Name = "cbbfilter1";
            this.cbbfilter1.Size = new System.Drawing.Size(121, 20);
            this.cbbfilter1.TabIndex = 62;
            this.cbbfilter1.SelectedIndexChanged += new System.EventHandler(this.Cbbfilter1_SelectedIndexChanged);
            // 
            // cbbfilter2
            // 
            this.cbbfilter2.FormattingEnabled = true;
            this.cbbfilter2.Items.AddRange(new object[] {
            "제품",
            "제조사"});
            this.cbbfilter2.Location = new System.Drawing.Point(136, 21);
            this.cbbfilter2.Name = "cbbfilter2";
            this.cbbfilter2.Size = new System.Drawing.Size(121, 20);
            this.cbbfilter2.TabIndex = 63;
            // 
            // btnSearch2
            // 
            this.btnSearch2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSearch2.Location = new System.Drawing.Point(263, 18);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(75, 23);
            this.btnSearch2.TabIndex = 67;
            this.btnSearch2.Text = "검색";
            this.btnSearch2.UseVisualStyleBackColor = false;
            this.btnSearch2.Click += new System.EventHandler(this.BtnSearch2_Click);
            // 
            // ptbRefresh
            // 
            this.ptbRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ptbRefresh.Image")));
            this.ptbRefresh.Location = new System.Drawing.Point(770, 9);
            this.ptbRefresh.Name = "ptbRefresh";
            this.ptbRefresh.Size = new System.Drawing.Size(33, 35);
            this.ptbRefresh.TabIndex = 61;
            this.ptbRefresh.TabStop = false;
            this.ptbRefresh.Click += new System.EventHandler(this.PtbRefresh_Click);
            // 
            // picOrder
            // 
            this.picOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picOrder.Image = ((System.Drawing.Image)(resources.GetObject("picOrder.Image")));
            this.picOrder.Location = new System.Drawing.Point(809, 9);
            this.picOrder.Name = "picOrder";
            this.picOrder.Size = new System.Drawing.Size(31, 35);
            this.picOrder.TabIndex = 71;
            this.picOrder.TabStop = false;
            this.picOrder.Click += new System.EventHandler(this.picOrder_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Offerer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(852, 689);
            this.Controls.Add(this.picOrder);
            this.Controls.Add(this.btnSearch2);
            this.Controls.Add(this.cbbfilter2);
            this.Controls.Add(this.cbbfilter1);
            this.Controls.Add(this.ptbRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbbSearchType);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.dgvOfferer);
            this.Name = "Offerer_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "거래처자재목록";
            this.Load += new System.EventHandler(this.Offerer_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferer)).EndInit();
            this.cmsOfferer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.cmsMat.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOfferer;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblmatName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblmatMoney;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblmat_Each;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOffererName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblmatType;
        private System.Windows.Forms.ContextMenuStrip cmsOfferer;
        private System.Windows.Forms.ToolStripMenuItem 상세정보ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMat;
        private System.Windows.Forms.ToolStripMenuItem 수정ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbbSearchType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox ptbRefresh;
        private System.Windows.Forms.ComboBox cbbfilter1;
        private System.Windows.Forms.ComboBox cbbfilter2;
        private System.Windows.Forms.Button btnSearch2;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
        private System.Windows.Forms.PictureBox picOrder;
        private System.Windows.Forms.Timer timer1;
    }
}