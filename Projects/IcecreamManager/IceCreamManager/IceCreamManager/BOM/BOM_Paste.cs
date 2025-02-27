﻿using IceCreamManager.Service;
using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class BOM_Paste : Form
    {
        List<MaterialsVO> bomParentList = new List<MaterialsVO>();
        List<MaterialsBOMConnectVO> bomChildList = new List<MaterialsBOMConnectVO>();

        BOMService service = new BOMService();

        List<BOMVO> SelectedList = new List<BOMVO>();
        List<TreeNode> Treebom = new List<TreeNode>();
        public List<BOMVO> TreeList { get; set; }
        public List<TreeNode> TreeBOM { get; set; }
        
        public BOM_Paste()
        {
            InitializeComponent();
        }
        private void BOM_Paste_Load(object sender, EventArgs e)
        {
            bomParentList = service.SelectAllBOMExistingList();

            // soyeon
            InitialConrol();
            dgvBOMList.DataSource = bomParentList;
            //
        }

        private void InitialConrol()
        {
            DatagridviewDesigns.SetDesign(dgvBOMList);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvBOMList, "자재명", "mat_Name", true, 210, default, true);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvBOMList, "자재번호", "mat_No", false, 210);
        }
        private void DgvBOMList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tvBOM.Nodes.Clear();
            Treebom.Clear();
            int bomNo = Convert.ToInt32(dgvBOMList[1, dgvBOMList.CurrentRow.Index].Value);

            TreeNode parentnode = new TreeNode();
            parentnode.Tag = bomNo;
            parentnode.Text = dgvBOMList[0, dgvBOMList.CurrentRow.Index].Value.ToString();
            this.tvBOM.Nodes.Add(parentnode);
            //Treebom.Add(parentnode);
            bomChildList = service.GetAllBOMMaterialsByParentNo(bomNo);

            int childNo = 0;
            int quantity = 0;
            string unit = string.Empty;
            foreach (var item in bomChildList)
            {
                TreeNode childnode = new TreeNode();
                childnode.Text = item.mat_Name;
                tvBOM.TopNode.Nodes.Add(childnode);
                Treebom.Add(childnode);

                childNo = item.mat_ChildNo;
                unit = item.bom_ChildUnit;
                quantity = item.bom_ChildEach;

                BOMVO bom = new BOMVO
                {
                    //mat_ParentNo = bomNo,
                    mat_ChildNo = childNo,
                    bom_ChildEach = quantity,
                    bom_ChildUnit = unit
                };
                SelectedList.Add(bom);
            }
            tvBOM.TopNode.ExpandAll();
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if(tvBOM.Nodes.Count < 1)
            {
                MessageBox.Show("복사할 제품을 선택해 주세요.","BOM 관리",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            TreeList = SelectedList;
            TreeBOM = Treebom;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
