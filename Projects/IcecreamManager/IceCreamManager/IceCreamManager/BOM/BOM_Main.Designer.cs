﻿namespace IceCreamManager
{
    partial class BOM_Main
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.Rdo_Explosion = new System.Windows.Forms.RadioButton();
            this.Rdo_Implosion = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoList = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tbcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(109, 127);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(600, 555);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMain_CellContentClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSearch.Location = new System.Drawing.Point(330, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 40);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("굴림", 11F);
            this.txtKeyword.Location = new System.Drawing.Point(113, 91);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(211, 24);
            this.txtKeyword.TabIndex = 2;
            this.txtKeyword.Enter += new System.EventHandler(this.TxtKeyword_Enter);
            this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyword_KeyPress);
            // 
            // tbcMain
            // 
            this.tbcMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tbcMain.Controls.Add(this.tabPage1);
            this.tbcMain.Controls.Add(this.tabPage2);
            this.tbcMain.Controls.Add(this.tabPage3);
            this.tbcMain.Controls.Add(this.tabPage4);
            this.tbcMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbcMain.HotTrack = true;
            this.tbcMain.ItemSize = new System.Drawing.Size(100, 100);
            this.tbcMain.Location = new System.Drawing.Point(8, 127);
            this.tbcMain.Multiline = true;
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(100, 197);
            this.tbcMain.TabIndex = 4;
            this.tbcMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TbcMain_DrawItem);
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.TbcMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(0, 189);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "전체";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 189);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "완제품";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(0, 189);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "반제품";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(104, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(0, 189);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "재료";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvSearch
            // 
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(724, 127);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RowHeadersWidth = 51;
            this.dgvSearch.RowTemplate.Height = 23;
            this.dgvSearch.Size = new System.Drawing.Size(339, 555);
            this.dgvSearch.TabIndex = 5;
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Btn_Delete.Location = new System.Drawing.Point(904, 688);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(89, 40);
            this.Btn_Delete.TabIndex = 7;
            this.Btn_Delete.Text = "삭제";
            this.Btn_Delete.UseVisualStyleBackColor = false;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Update
            // 
            this.Btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Btn_Update.Location = new System.Drawing.Point(795, 688);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(89, 40);
            this.Btn_Update.TabIndex = 8;
            this.Btn_Update.Text = "수정";
            this.Btn_Update.UseVisualStyleBackColor = false;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // Rdo_Explosion
            // 
            this.Rdo_Explosion.AutoSize = true;
            this.Rdo_Explosion.ForeColor = System.Drawing.Color.White;
            this.Rdo_Explosion.Location = new System.Drawing.Point(3, 7);
            this.Rdo_Explosion.Name = "Rdo_Explosion";
            this.Rdo_Explosion.Size = new System.Drawing.Size(59, 16);
            this.Rdo_Explosion.TabIndex = 0;
            this.Rdo_Explosion.TabStop = true;
            this.Rdo_Explosion.Text = "정전개";
            this.Rdo_Explosion.UseVisualStyleBackColor = true;
            // 
            // Rdo_Implosion
            // 
            this.Rdo_Implosion.AutoSize = true;
            this.Rdo_Implosion.ForeColor = System.Drawing.Color.White;
            this.Rdo_Implosion.Location = new System.Drawing.Point(86, 7);
            this.Rdo_Implosion.Name = "Rdo_Implosion";
            this.Rdo_Implosion.Size = new System.Drawing.Size(59, 16);
            this.Rdo_Implosion.TabIndex = 0;
            this.Rdo_Implosion.TabStop = true;
            this.Rdo_Implosion.Text = "역전개";
            this.Rdo_Implosion.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Rdo_Implosion);
            this.panel1.Controls.Add(this.Rdo_Explosion);
            this.panel1.Location = new System.Drawing.Point(549, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 30);
            this.panel1.TabIndex = 9;
            // 
            // lblNoList
            // 
            this.lblNoList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoList.AutoSize = true;
            this.lblNoList.BackColor = System.Drawing.Color.White;
            this.lblNoList.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoList.Location = new System.Drawing.Point(740, 180);
            this.lblNoList.Name = "lblNoList";
            this.lblNoList.Size = new System.Drawing.Size(0, 24);
            this.lblNoList.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(111, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "* 제품명을 검색하세요";
            // 
            // BOM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1084, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNoList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.dgvSearch);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvMain);
            this.Name = "BOM_Main";
            this.Text = "BOM 메인";
            this.Load += new System.EventHandler(this.BOM_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tbcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.RadioButton Rdo_Explosion;
        private System.Windows.Forms.RadioButton Rdo_Implosion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNoList;
        private System.Windows.Forms.Label label1;
    }
}