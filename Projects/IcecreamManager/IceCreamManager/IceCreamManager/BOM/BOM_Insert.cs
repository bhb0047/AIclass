﻿using IceCreamManager.DAC;
using IceCreamManager.Service;
using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class BOM_Insert : Form
    {
        List<MaterialsVO> allList;
        List<MaterialsBOMConnectVO> childList;
        List<BOMVO> bomtree = new List<BOMVO>();
        bool cFlag = false;
        bool isParentNewMaterial=false;
        int parentNo = 0;

        public BOM_Insert()
        {
            InitializeComponent();
        }

        private void BOM_Insert_Load(object sender, EventArgs e)
        {
            MaterialsService service = new MaterialsService();
            allList = service.SelectAll();
            InitControl();
            LoadComboData();
        } // 로드 

        private void MbtnFind_Click(object sender, EventArgs e)
        {
            List<MaterialsVO> parentList = (from item in allList
                                            where item.mtt_No != 3
                                            select item).ToList();
            dgvInsert.DataSource = parentList;
            cFlag = false;
            
        } // 모품목 찾기

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if(cbomLevel.Text == "반제품")
            {
                List<MaterialsVO> childList = (from item in allList
                                               where item.mtt_No == 3
                                               select item).ToList();
                dgvInsert.DataSource = childList;
            }
            else
            {
                var childList = (from item in allList
                                 where item.mtt_No != 1
                                 select item).ToList();
                dgvInsert.DataSource = childList;
            }
            
            cFlag = true;
        } // 자품목 찾기

        private void DgvInsert_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInsert.SelectedRows.Count < 1)
            {
                return;
            }
            int matNo = Convert.ToInt32(dgvInsert.SelectedRows[0].Cells[0].Value);
            MaterialsVO matFind = allList.Find(p => p.mat_No == matNo);

            if (!cFlag)
            {
                if (matFind != null)
                {
                    cbomLevel.Enabled = false;
                    mtxtName.Text = matFind.mat_Name;
                    cbomLevel.Text = matFind.mtt_Name;
                    mlblNumber.Text = matFind.mat_No.ToString();
                    foreach (var item in this.panel2.Controls)
                    {
                        if (item is RadioButton rdo)
                        {
                            if (rdo.Text == matFind.mat_Unit)
                            {
                                rdo.Checked = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (matFind != null)
                {
                    txtName.Text = matFind.mat_Name;
                    cboLevel.Text = matFind.mtt_Name;
                    lblNumber.Text = matFind.mat_No.ToString();
                    foreach (var item in this.panel1.Controls)
                    {
                        if (item is RadioButton rdo)
                        {
                            if (rdo.Text == matFind.mat_Unit)
                            {
                                rdo.Checked = true;
                            }
                        }
                    }
                }
            }
        } // 모품목이거나 자품목을 찾기했을 때 위 그룹박스에 보여줌

        private void LoadComboData()
        {
            MaterialTypeService service = new MaterialTypeService();
            List<MaterialsTypeVO> typelist = service.Materials_Type();

            if (cbomLevel.Enabled)
            {
                cbomLevel.DataSource = (
                from type in typelist
                where type.mtt_No != 3
                select type).ToList();
                cbomLevel.DisplayMember = "mtt_Name";
                cbomLevel.ValueMember = "mtt_No";
            }
            else
            {
                return;
            }

            if(cbomLevel.Text == "반제품")
            {
                cboLevel.DataSource = (
                from type in typelist
                where type.mtt_No == 3
                select type).ToList();
                cboLevel.DisplayMember = "mtt_Name";
                cboLevel.ValueMember = "mtt_No";
            }
            else
            {
                cboLevel.DataSource = (
                from type in typelist
                where type.mtt_No != 1
                select type).ToList();
                cboLevel.DisplayMember = "mtt_Name";
                cboLevel.ValueMember = "mtt_No";
            }
            
        }//콤보박스 데이터바인딩

        private void InitControl()
        {
            DatagridviewDesigns.SetDesign(dgvInsert);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvInsert, "자재번호", "mat_No", true, 120);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvInsert, "자재단계", "mtt_Name", true, 110);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvInsert, "자재명", "mat_Name", true, 400, default, true);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvInsert, "자재량", "mat_Each", true, 80, default, true);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvInsert, "자재단위", "mat_Unit", true, 100);
        } // 컨트롤 설정

        private void MbtnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtName.Text))
            {
                MessageBox.Show("모품목을 설정해 주세요.","BOM 관리", MessageBoxButtons.OK);
                return;
            }

            if(cbomLevel.Text == "반제품")
            {
                LoadComboData();
            }

            isParentNewMaterial = false;
            bomtree.Clear();
            TreeNode parentNode = new TreeNode();
            parentNode.Name = "BOMparent";
            parentNode.Text = mtxtName.Text;
            this.tvInsert.Nodes.Add(parentNode);
            mbtnApply.Enabled = false;

            string rdoname = string.Empty;
            foreach (var item in this.panel1.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rdo = item as RadioButton;
                    if (rdo.Checked)
                    {
                        rdoname = rdo.Text;
                    }
                }
            }

            if (mlblNumber.Text == "")
            {
                MaterialsService service = new MaterialsService();
                MaterialsVO vo = new MaterialsVO();

                vo.mat_Name = mtxtName.Text; //이름
                vo.mtt_No = Convert.ToInt32(cbomLevel.SelectedValue);  //자제타입      
                vo.mat_Unit = rdoname;

                mlblNumber.Text = service.Insert_Update_GetID(vo).ToString();
                isParentNewMaterial = true;
            }
            parentNo = Convert.ToInt32(mlblNumber.Text);

            BOMService bservice = new BOMService();
            childList = bservice.GetAllBOMMaterialsByParentNo(parentNo);

            foreach (var item in childList)
            {
                TreeNode childnode = new TreeNode();
                childnode.Text = item.mat_Name;
                tvInsert.TopNode.Nodes.Add(childnode);
                
                BOMVO bom = new BOMVO
                {
                    mat_ParentNo = parentNo,
                    mat_ChildNo = item.mat_ChildNo,
                    bom_ChildEach = item.bom_ChildEach,
                    bom_ChildUnit = item.bom_ChildUnit
                };
                bomtree.Add(bom);
            }
            tvInsert.TopNode.ExpandAll();
        } // 모품목을 트리에 추가하는 버튼

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("자품목을 선택해 주세요.", "BOM 관리", MessageBoxButtons.OK);
                return;
            }

            if(string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("수량을 설정해 주세요.","BOM 관리", MessageBoxButtons.OK);
                return;
            }

            string rdoname = string.Empty;
            foreach (var item in this.panel1.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rdo = item as RadioButton;
                    if(rdo.Checked)
                    {
                        rdoname = rdo.Text;
                    }
                }
            }

            try
            {
                TreeNode childNode = new TreeNode();
                childNode.Name = "BOMchild";
                childNode.Text = txtName.Text;
                this.tvInsert.TopNode.Nodes.Add(childNode);
                BOMVO bom = new BOMVO
                {
                    mat_ParentNo = parentNo,
                    mat_ChildNo = Convert.ToInt32(lblNumber.Text),
                    bom_ChildEach = Convert.ToInt32(txtQuantity.Text),
                    bom_ChildUnit = rdoname
                };
                bomtree.Add(bom);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
            tvInsert.TopNode.ExpandAll();
            txtQuantity.Text = "";
        } // 자품목을 트리에 추가 + 리스트에 추가

        private void 모든목록삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvInsert.Nodes.Clear();
            bomtree.Clear();
            mbtnApply.Enabled = true;
            cbomLevel.Enabled = true;
            // 부모가 새로 만들어진 자재일 경우 db에서 제거한다.
            if (isParentNewMaterial)
            {
                ProductDAC dac = new ProductDAC();
                dac.delete(parentNo);
            }
        } // 트리의 모든 노드 삭제

        private void 선택목록삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO - service.Insert_Update_GetID후 트리뷰에서 완제품을 제거할때 Delete하는 부분이 부족함
            if(tvInsert.SelectedNode == null)
            {
                return;
            }
            if (tvInsert.SelectedNode.Index == 0)
            {
                tvInsert.SelectedNode.Remove();
                parentNo = 0;
                mbtnApply.Enabled = true;
                cbomLevel.Enabled = true;
            }
            else
            {
                bomtree.RemoveAt(tvInsert.SelectedNode.Index);
                tvInsert.SelectedNode.Remove();
            }
            // 부모가 새로 만들어진 자재일 경우 db에서 제거한다.
            if (isParentNewMaterial)
            {
                ProductDAC dac = new ProductDAC();
                dac.delete(parentNo);
            }
        } // 선택된 노드 삭제

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (tvInsert.Nodes.Count < 1)
                return;

            try
            {
                BOMService service = new BOMService();
                service.TreeDelete(parentNo);
                
                if (service.Insert(bomtree))
                {
                    MessageBox.Show("BOM 등록 완료", "BOM 관리", MessageBoxButtons.OK);
                    tvInsert.Nodes.Clear();
                }
                else
                {
                    MessageBox.Show("BOM 등록 실패", "BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            mtxtName.Text = "";
            txtName.Text = "";
            mbtnApply.Enabled = true;
        } //등록버튼 클릭

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            if(tvInsert.Nodes.Count < 1)
            {
                MessageBox.Show("모제품을 등록해 주세요.");
                return;
            }
            
            BOM_Paste frm = new BOM_Paste();
            if (frm.ShowDialog() ==DialogResult.OK)
            {
                foreach (var item in frm.TreeList)
                {
                    BOMVO bom = new BOMVO
                    {
                        mat_ParentNo = Convert.ToInt32(mlblNumber.Text),
                        mat_ChildNo = item.mat_ChildNo,
                        bom_ChildEach = item.bom_ChildEach,
                        bom_ChildUnit = item.bom_ChildUnit
                    };
                    bomtree.Add(bom);
                }
                foreach (var item in frm.TreeBOM)
                {
                    tvInsert.TopNode.Nodes.Add(item.Text);
                    tvInsert.TopNode.ExpandAll();
                }
            }
        } //BOM불러오기버튼 클릭

        private void mtxtName_TextChanged(object sender, EventArgs e)
        {
            mlblNumber.Text = "";
        } //모품목이름 변경

        private void cbomLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            mlblNumber.Text = "";
        } //모품목 레벨 변경

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        } //취소버튼 클릭

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        } //수량 text 숫자만 입력
    }
}