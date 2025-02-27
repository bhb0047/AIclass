﻿using IceCreamManager.Service;
using IceCreamManager.VO;
using System;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class BOM_SearchUP : Form
    {
        
        public BOM_SearchUP()
        {
            InitializeComponent();
        }

        public BOM_SearchUP(int mat_No, string mat_Name, int bom_ChildEach, int mat_ParentNo) : this()
        {
            BOMupdateVO bom = new BOMupdateVO();
            bom.mat_No = mat_No;
            bom.mat_Name = mat_Name;
            bom.bom_ChildEach = bom_ChildEach;
            bom.mat_ParentNo = mat_ParentNo;
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtNumber.Text = bom.mat_No.ToString();
            txtName.Text = bom.mat_Name;
            txtQuantity.Text = bom.bom_ChildEach.ToString();
            lblParent.Text = bom.mat_ParentNo.ToString();
            //lblParent.Visible = false;
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BOMVO bom = new BOMVO();
                bom.mat_ChildNo = Convert.ToInt32(txtNumber.Text);
                bom.bom_ChildEach = Convert.ToInt32(txtQuantity.Text);
                bom.mat_ParentNo = Convert.ToInt32(lblParent.Text);

                BOMService service = new BOMService();
                bool result = service.Update(bom);
                if(result)
                {
                    MessageBox.Show("BOM 목록 수정 성공","BOM 관리",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("BOM 목록 수정 실패", "BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) 
            {
                e.Handled = true;
            }
        }
    }
}
