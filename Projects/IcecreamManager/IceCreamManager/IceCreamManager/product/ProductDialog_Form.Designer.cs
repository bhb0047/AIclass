﻿namespace IceCreamManager
{
    partial class ProductDialog_Form
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
            this.ptbProduct = new System.Windows.Forms.PictureBox();
            this.btnInsertProduct = new System.Windows.Forms.Button();
            this.btnFindImg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.npdProductPrice = new System.Windows.Forms.NumericUpDown();
            this.ofdFindImg = new System.Windows.Forms.OpenFileDialog();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnDeleteProducts = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBOMParentList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.nudMagin = new System.Windows.Forms.NumericUpDown();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.lblMatNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdProductPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMParentList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagin)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbProduct
            // 
            this.ptbProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbProduct.Image = global::IceCreamManager.Properties.Resources.Default;
            this.ptbProduct.Location = new System.Drawing.Point(11, 82);
            this.ptbProduct.Name = "ptbProduct";
            this.ptbProduct.Size = new System.Drawing.Size(200, 145);
            this.ptbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbProduct.TabIndex = 51;
            this.ptbProduct.TabStop = false;
            // 
            // btnInsertProduct
            // 
            this.btnInsertProduct.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnInsertProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnInsertProduct.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInsertProduct.Location = new System.Drawing.Point(553, 203);
            this.btnInsertProduct.Name = "btnInsertProduct";
            this.btnInsertProduct.Size = new System.Drawing.Size(75, 23);
            this.btnInsertProduct.TabIndex = 48;
            this.btnInsertProduct.Text = ">";
            this.btnInsertProduct.UseVisualStyleBackColor = false;
            this.btnInsertProduct.Click += new System.EventHandler(this.btnInsertProduct_Click);
            // 
            // btnFindImg
            // 
            this.btnFindImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFindImg.Location = new System.Drawing.Point(217, 196);
            this.btnFindImg.Name = "btnFindImg";
            this.btnFindImg.Size = new System.Drawing.Size(75, 23);
            this.btnFindImg.TabIndex = 52;
            this.btnFindImg.Text = "불러오기";
            this.btnFindImg.UseVisualStyleBackColor = false;
            this.btnFindImg.Click += new System.EventHandler(this.btnFindImg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 53;
            this.label4.Text = "가격";
            // 
            // npdProductPrice
            // 
            this.npdProductPrice.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.npdProductPrice.Location = new System.Drawing.Point(44, 54);
            this.npdProductPrice.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.npdProductPrice.Name = "npdProductPrice";
            this.npdProductPrice.Size = new System.Drawing.Size(131, 21);
            this.npdProductPrice.TabIndex = 54;
            // 
            // ofdFindImg
            // 
            this.ofdFindImg.FileName = "openFileDialog1";
            // 
            // dgvProductList
            // 
            this.dgvProductList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Location = new System.Drawing.Point(634, 35);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowTemplate.Height = 23;
            this.dgvProductList.Size = new System.Drawing.Size(278, 438);
            this.dgvProductList.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(631, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "상품 목록";
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeleteProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteProduct.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteProduct.Location = new System.Drawing.Point(553, 232);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProduct.TabIndex = 59;
            this.btnDeleteProduct.Text = "<";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnDeleteProducts
            // 
            this.btnDeleteProducts.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeleteProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteProducts.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteProducts.Location = new System.Drawing.Point(553, 261);
            this.btnDeleteProducts.Name = "btnDeleteProducts";
            this.btnDeleteProducts.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProducts.TabIndex = 60;
            this.btnDeleteProducts.Text = "<<";
            this.btnDeleteProducts.UseVisualStyleBackColor = false;
            this.btnDeleteProducts.Click += new System.EventHandler(this.btnDeleteProducts_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "설정";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "완제품 목록";
            // 
            // dgvBOMParentList
            // 
            this.dgvBOMParentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBOMParentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOMParentList.Location = new System.Drawing.Point(10, 35);
            this.dgvBOMParentList.Name = "dgvBOMParentList";
            this.dgvBOMParentList.RowTemplate.Height = 23;
            this.dgvBOMParentList.Size = new System.Drawing.Size(228, 438);
            this.dgvBOMParentList.TabIndex = 62;
            this.dgvBOMParentList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOMParentList_CellClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nudMagin);
            this.panel1.Controls.Add(this.lblMaterialName);
            this.panel1.Controls.Add(this.lblMatNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ptbProduct);
            this.panel1.Controls.Add(this.btnFindImg);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.npdProductPrice);
            this.panel1.Location = new System.Drawing.Point(244, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 438);
            this.panel1.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(181, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 65;
            this.label6.Text = "마진";
            // 
            // nudMagin
            // 
            this.nudMagin.DecimalPlaces = 1;
            this.nudMagin.Location = new System.Drawing.Point(216, 54);
            this.nudMagin.Name = "nudMagin";
            this.nudMagin.Size = new System.Drawing.Size(71, 21);
            this.nudMagin.TabIndex = 64;
            this.nudMagin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMaterialName.ForeColor = System.Drawing.Color.White;
            this.lblMaterialName.Location = new System.Drawing.Point(8, 10);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(167, 16);
            this.lblMaterialName.TabIndex = 63;
            this.lblMaterialName.Text = "제품을 선택해주세요";
            // 
            // lblMatNo
            // 
            this.lblMatNo.AutoSize = true;
            this.lblMatNo.ForeColor = System.Drawing.Color.White;
            this.lblMatNo.Location = new System.Drawing.Point(9, 247);
            this.lblMatNo.Name = "lblMatNo";
            this.lblMatNo.Size = new System.Drawing.Size(48, 12);
            this.lblMatNo.TabIndex = 62;
            this.lblMatNo.Text = "mat_No";
            this.lblMatNo.Visible = false;
            // 
            // ProductDialog_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(925, 518);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBOMParentList);
            this.Controls.Add(this.btnDeleteProducts);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvProductList);
            this.Controls.Add(this.btnInsertProduct);
            this.MinimumSize = new System.Drawing.Size(941, 557);
            this.Name = "ProductDialog_Form";
            this.Text = "ProductDialog_Form";
            this.Load += new System.EventHandler(this.ProductDialog_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdProductPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMParentList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbProduct;
        private System.Windows.Forms.Button btnInsertProduct;
        private System.Windows.Forms.Button btnFindImg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown npdProductPrice;
        private System.Windows.Forms.OpenFileDialog ofdFindImg;
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnDeleteProducts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBOMParentList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMatNo;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudMagin;
    }
}