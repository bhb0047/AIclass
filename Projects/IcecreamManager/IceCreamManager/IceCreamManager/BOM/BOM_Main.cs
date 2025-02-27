﻿using IceCreamManager.Service;
using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class BOM_Main : Form
    {
        List<MaterialsVO> materialList;
        List<BOMVO> bomList;
        BOMService service = new BOMService();
        MaterialsService mservice = new MaterialsService();

        public BOM_Main()
        {
            InitializeComponent();
        }

        #region 탭 컨트롤 설정
        private void TbcMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tbcMain.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tbcMain.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.LightCoral);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("맑은 고딕", 17.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
        #endregion

        #region 메인폼 로드 이벤트
        private void BOM_Main_Load(object sender, EventArgs e)
        {
            InitCotrols();
            SearchGridBinding();
            materialList = mservice.SelectAll();
            bomList = service.SelectBomAll();
            dgvMain.DataSource = materialList;
        }
        #endregion

        #region 메인화면 바인딩
        private void InitCotrols()
        {
            Rdo_Explosion.Checked = true;

            DatagridviewDesigns.SetDesign(dgvMain);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvMain, "자재번호", "mat_No", true, 60);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvMain, "자재명", "mat_Name", true, 200,default,true);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvMain, "자재단계", "mtt_Name", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvMain, "자재량", "mat_Each", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvMain, "단위", "mat_Unit", true, 50);

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "관리";
            btn.Text = "조회";
            btn.Name = "btnSearch";
            btn.Width = 100;
            btn.UseColumnTextForButtonValue = true;
            dgvMain.Columns.Add(btn);
        }
        #endregion

        #region 탭인덱스 변경
        private void TbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cho = tbcMain.SelectedIndex;

            switch (cho)
            {
                case 0:
                    dgvMain.DataSource = materialList;
                    dgvSearch.DataSource = "";
                    break;
                case 1:
                    List<MaterialsVO> wanjeList = materialList.FindAll((elem) => elem.mtt_No == 1);
                    //List<MaterialsVO> wanjeList = (from item in allList
                    //                               where item.mtt_No == 1
                    //                               select item).ToList();
                    dgvMain.DataSource = wanjeList;
                    dgvSearch.DataSource = "";
                    break;
                case 2:
                    List<MaterialsVO> banjeList = materialList.FindAll((elem) => elem.mtt_No == 2);
                    //List<MaterialsVO> banjeList = (from item in allList
                    //                               where item.mtt_No == 2
                    //                               select item).ToList();
                    dgvMain.DataSource = banjeList;
                    dgvSearch.DataSource = "";
                    break;
                case 3:
                    List<MaterialsVO> matList = materialList.FindAll((elem) => elem.mtt_No == 3);
                    //List<MaterialsVO> materialList = (from item in allList
                    //                                  where item.mtt_No == 3
                    //                                  select item).ToList();
                    dgvMain.DataSource = matList;
                    dgvSearch.DataSource = "";
                    break;
            }
        }
        #endregion

        #region 데이터그리드뷰 버튼 클릭
        private void DgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) < 0)
            {
                return;
            }
            BOMDetailListBinding(Convert.ToInt32(dgvMain.Rows[e.RowIndex].Cells[0].Value), e.ColumnIndex);
        }

        private void SearchGridBinding()
        {
            DatagridviewDesigns.SetDesign(dgvSearch);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvSearch, "자재번호", "mat_No", true, 60);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvSearch, "자재명", "mat_Name", true, 120);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvSearch, "자재단계", "mtt_Name", true, 60);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvSearch, "개수", "bom_ChildEach", true, 50);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvSearch, "단위", "bom_ChildUnit", true, 50);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvSearch, "부모번호", "mat_ParentNo", false, 60);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvSearch, "자식번호", "mat_ChildNo", false, 60);
        }

        private void BOMDetailListBinding(int materialsNo, int colIndex)
        {
           
            lblNoList.Text = "";
            int MaterialsNo = materialsNo;

            if (colIndex == dgvMain.Columns["btnSearch"].Index)
            {
                if (Rdo_Explosion.Checked)
                {
                    var ExplosionList = (from bom in bomList
                                         join material in materialList on bom.mat_ChildNo equals material.mat_No
                                         where bom.mat_ParentNo == MaterialsNo
                                         select new { mat_No = material.mat_No, mat_Name = material.mat_Name, mtt_Name = material.mtt_Name, bom_ChildEach = bom.bom_ChildEach, mat_ParentNo = bom.mat_ParentNo, mat_ChildNo = bom.mat_ChildNo, bom_ChildUnit = bom.bom_ChildUnit }).ToList();

                    if (ExplosionList.Count < 1)
                    {
                        dgvSearch.DataSource = "";
                        lblNoList.Text = "조회할 목록이 없습니다.";
                    }
                    else
                    {
                        dgvSearch.DataSource = ExplosionList;
                    }
                }
                else if (Rdo_Implosion.Checked)
                {
                    var ImplosionList = (from bom in bomList
                                         join material in materialList on bom.mat_ParentNo equals material.mat_No
                                         where bom.mat_ChildNo == MaterialsNo
                                         select new { mat_No = material.mat_No, mat_Name = material.mat_Name, mtt_Name = material.mtt_Name, bom_ChildEach = bom.bom_ChildEach, mat_ParentNo = bom.mat_ParentNo, mat_ChildNo = bom.mat_ChildNo, bom_ChildUnit = bom.bom_ChildUnit }).ToList();
                    if (ImplosionList.Count < 1)
                    {
                        dgvSearch.DataSource = "";
                        lblNoList.Text = "조회할 목록이 없습니다.";
                    }
                    else
                    {
                        dgvSearch.DataSource = ImplosionList;
                    }
                }
                else
                {
                    MessageBox.Show("조건을 선택해 주세요.","BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 검색버튼클릭
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string query = txtKeyword.Text.Trim();
            List<MaterialsVO> searchList = null;

            if (query.Length < 1)
            {
                dgvMain.DataSource = materialList;
            }
            else
            {
                searchList = (from material in materialList
                              where material.mat_Name.Contains(query)
                              select material).ToList();
                dgvMain.DataSource = searchList;
            }
        }
        #endregion

        #region 수정버튼클릭
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (dgvSearch.DataSource == null)
                return;

            BOMupdateVO bom = new BOMupdateVO();
            if (Rdo_Explosion.Checked)
            {
                bom.mat_No = Convert.ToInt32(dgvSearch[0, dgvSearch.CurrentRow.Index].Value);
                bom.mat_Name = dgvSearch[1, dgvSearch.CurrentRow.Index].Value.ToString();
                bom.bom_ChildEach = Convert.ToInt32(dgvSearch[3, dgvSearch.CurrentRow.Index].Value);
                bom.mat_ParentNo = Convert.ToInt32(dgvSearch[5, dgvSearch.CurrentRow.Index].Value);

                BOM_SearchUP frm = new BOM_SearchUP(bom.mat_No, bom.mat_Name, bom.bom_ChildEach, bom.mat_ParentNo);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    bomList = service.SelectBomAll();

                    BOMDetailListBinding(bom.mat_ParentNo, 5);
                }
            }
            else if (Rdo_Implosion.Checked)
            {
                MessageBox.Show("완제품은 수정할 수 없습니다.","BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("조회 조건을 확인해 주세요.","BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 삭제버튼클릭
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgvSearch.DataSource == null)
                return;
            if (dgvSearch.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 자재를 선택하여 주십시오.","BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mat_Name = dgvSearch[1, dgvSearch.CurrentRow.Index].Value.ToString();
            int mat_ChildNo = Convert.ToInt32(dgvSearch[6, dgvSearch.CurrentRow.Index].Value);
            int mat_ParentNo = Convert.ToInt32(dgvSearch[5, dgvSearch.CurrentRow.Index].Value);

            try
            {
                BOMVO bom = new BOMVO();
                bom.mat_ParentNo = mat_ParentNo;
                bom.mat_ChildNo = mat_ChildNo;

                if (MessageBox.Show($"{mat_Name}을 정말로 삭제하시겠습니까?","BOM 관리",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BOMService service = new BOMService();
                    bool bResult = service.Delete(bom);
                    if (bResult)
                    {
                        MessageBox.Show("BOM 목록 삭제 성공", "BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bomList = service.SelectBomAll();
                        if (Rdo_Explosion.Checked)
                        {
                            BOMDetailListBinding(bom.mat_ParentNo, 5);
                        }
                        else
                        {
                            BOMDetailListBinding(bom.mat_ChildNo, 5);
                        }
                    }
                    else
                    {
                        MessageBox.Show("BOM 목록 삭제 실패", "BOM 관리", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region textbox 이벤트

        private void TxtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch.PerformClick();
            }
        }

        private void TxtKeyword_Enter(object sender, EventArgs e)
        {
            dgvSearch.DataSource = "";
        }
        #endregion

     
    }
}