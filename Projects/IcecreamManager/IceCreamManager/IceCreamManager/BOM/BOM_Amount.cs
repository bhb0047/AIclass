﻿using IceCreamManager.Service;
using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class BOM_Amount : Form
    {
        List<MaterialsBOMConnectVO> mlist;
        List<MaterialsVO> allist;
        List<int> parentValues;
        List<AmountVO> amountList = new List<AmountVO>();
        List<AmountVO> parentList = new List<AmountVO>();

        // 엑셀 제일 윗줄 완제품, 아래는 재료들
        public BOM_Amount()
        {
            InitializeComponent();
        }

        private void InitControls()
        { // m.[mat_No], mt.[mtt_No], m.[off_No], m.[mat_Name], m.[mat_Cost], m.[mat_Each], m.[mat_MinSize], m.[mat_Unit], mt.mtt_Name

            DatagridviewDesigns.SetDesign(dgvAmountParent);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "자재번호", "mat_No", true, 100);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "자재명", "mat_Name", true, 210, default, true);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "자재단계", "mtt_Name", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "자재개수", "mat_Each", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "안전재고량", "mat_MinSize", true, 90);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "단위", "mat_Unit", true, 60);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "자재단가", "mat_Cost", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountParent, "소요원가", "total_Cost", true, 80);

            DatagridviewDesigns.SetDesign(dgvAmountChild);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "자재번호", "mat_No", true, 100);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "자재명", "mat_Name", true, 210, default, true);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "자재단계", "mtt_Name", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "자식자재량", "total_each", true, 100);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "총재고량", "mat_Each", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "단위", "mat_Unit", true, 75);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "자재단가", "mat_Cost", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "소요원가", "total_Cost", true, 80);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvAmountChild, "제조사코드", "off_No", true, 80);

        }
        
        private void BtnFind_Click(object sender, EventArgs e)
        {
            BOM_AmountSearch frm = new BOM_AmountSearch();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 선택한 Materials List를 가져온다
                parentValues = frm.SelectedValues;
                MaterialsService service = new MaterialsService();
                allist = service.SelectAll();
                var parList  = ( from mat in allist where parentValues.Contains(mat.mat_No)
                    select new { mat.mat_No, mat.mat_Name, mat.mtt_Name, mat.mat_Each, mat.mat_MinSize, mat.mat_Unit, mat.mat_Cost, total_Cost = mat.mat_Cost, mat.off_No }).ToList();

                for (int i = 0; i < parList.Count; i++)
                {
                    AmountVO am = new AmountVO();
                    am.mat_No = parList[i].mat_No;
                    am.mat_Name = parList[i].mat_Name;
                    am.mtt_Name = parList[i].mtt_Name;
                    am.mat_Each = parList[i].mat_Each;
                    am.mat_MinSize = parList[i].mat_MinSize;
                    am.mat_Unit = parList[i].mat_Unit;
                    am.mat_Cost = parList[i].mat_Cost;
                    am.total_Cost = parList[i].total_Cost;
                    am.off_No = parList[i].off_No;

                    parentList.Add(am);
                }
                dgvAmountParent.DataSource = parList.ToList();

                // Search에서 선택된 Parents의 자식
                mlist = service.SelectAllChilds(parentValues);

                var totallist = (from mat in mlist
                                          group mat by mat.mat_No into g
                                          select new { mat_No = g.Key, mat_Each = g.Sum((m) => m.mat_Each), bom_ChildEach = g.Sum((m) => m.bom_ChildEach), mat_Cost = g.Sum((m) => m.mat_Cost) }).ToList();

              
                var childList = (from mat in allist join clo in totallist on mat.mat_No equals clo.mat_No
                    select new {mat.mat_No, total_Cost = clo.mat_Cost, mat.mat_Each, mat.mat_MinSize, mat.mat_Name, mat.mat_Unit, mat.mtt_No, mat.mtt_Name, mat.off_No, total_each = clo.bom_ChildEach, mat.mat_Cost }).ToList();

                for(int i = 0; i< childList.Count; i++)
                {
                    AmountVO am = new AmountVO();
                    am.mat_No = childList[i].mat_No;
                    am.mat_Each = childList[i].mat_Each;
                    am.mat_MinSize = childList[i].mat_MinSize;
                    am.mat_Name = childList[i].mat_Name;
                    am.mat_Unit = childList[i].mat_Unit;
                    am.mtt_No = childList[i].mtt_No;
                    am.mtt_Name = childList[i].mtt_Name;
                    am.off_No = childList[i].off_No;
                    am.total_each = childList[i].total_each;
                    am.mat_Cost = childList[i].mat_Cost;
                    am.total_Cost = childList[i].total_Cost;
                    amountList.Add(am);
                }
                dgvAmountChild.DataSource = childList.ToList();
            }
        }
        private void BOM_Amount_Load(object sender, EventArgs e)
        {
            InitControls();
            _Index_List = new List<int>();
        }
        private void btnEcxel_Click(object sender, EventArgs e)
        {
            if (dgvAmountParent.Rows.Count < 1 && dgvAmountChild.Rows.Count < 1)
            {
                MessageBox.Show("제품을 선택해주세요", "소요량 관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Helper.ExcelExportFromDGVByColumns(new DataGridView[] { dgvAmountParent, dgvAmountChild }, sfdExcelExport);
        }

        private void DgvAmountChild_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool cFlag = false;
            if (dgvAmountChild.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
            {
                if (MessageBox.Show("현재 재고량이 부족합니다. 발주 하시겠습니까", "소요량 관리", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    cFlag = true;
                    List<OffererOrderForDgvVO> ofodgvlist = new List<OffererOrderForDgvVO>();
                    foreach (var item in _Index_List)
                    {
                        DataGridViewRow row = dgvAmountChild.Rows[item];
                        OffererOrderForDgvVO tmpvo = new OffererOrderForDgvVO()
                        {
                            mat_No = Convert.ToInt32(row.Cells[0].Value)
                        ,
                            off_No = Convert.ToInt32(row.Cells[8].Value)
                        ,
                            ofo_Each = (Convert.ToInt32(row.Cells[3].Value) - Convert.ToInt32(row.Cells[4].Value)) * 1000
                        ,
                            cmt_No = 3
                        ,
                            ofo_Price = Convert.ToInt32(row.Cells[6].Value) * (Convert.ToInt32(row.Cells[3].Value) - Convert.ToInt32(row.Cells[4].Value)) * 1000
                        ,
                            ofo_DateTime = DateTime.Now
                        };
                        ofodgvlist.Add(tmpvo);
                    }

                    OffererOder_Form frm = new OffererOder_Form(cFlag, ofodgvlist);
                    frm.ShowDialog();
                }
                else
                {
                    return;
                }
            }
        }

        private void NumQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (numQuantity.Value >= 1)
                {
                    btnCalc.PerformClick();
                }
                else
                {
                    return;
                }
            }
        }

        List<int> _Index_List;
        private void BtnCalc_Click(object sender, EventArgs e)
        {
            if (dgvAmountParent.DataSource == null)
            {
                MessageBox.Show("제품을 먼저 선택해 주세요.", "소요량 관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numQuantity.Value < 1)
            {
                MessageBox.Show("개수를 지정해 주세요.", "소요량 관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<AmountVO> seParentList = parentList.Select(p => new AmountVO(p.mat_No, p.mat_Name, p.mtt_Name, p.mat_Each, p.mat_MinSize, p.mat_Unit, p.mat_Cost, p.total_Cost)).ToList();
            List<AmountVO> seAmountList = amountList.Select(p => new AmountVO(p.mat_Name, p.mat_No, p.mtt_Name, p.total_each, p.mat_Each, p.mat_Unit, p.mat_Cost, p.total_Cost, p.off_No)).ToList();

            int index = parentValues.Count;
            int toCost = 0;

            for (int i = 0; i < index; i++)
            {
                seParentList[i].mat_Each = Convert.ToInt32(numQuantity.Value);
                seParentList[i].total_Cost = parentList[i].total_Cost * Convert.ToInt32(numQuantity.Value);
                toCost += seParentList[i].total_Cost;
            }

            lbltotalcost.Text = string.Format("총 합계 금액 : {0:#,##0} 원", toCost);
            dgvAmountParent.DataSource = null;
            dgvAmountParent.DataSource = seParentList;

            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.BackColor = Color.Red;
            cs.ForeColor = Color.White;

            _Index_List.Clear();
            index = amountList.Count;
            for (int i = 0; i < index; i++)
            {
                seAmountList[i].total_each = amountList[i].total_each * Convert.ToInt32(numQuantity.Value);
                seAmountList[i].total_Cost = amountList[i].total_Cost * Convert.ToInt32(numQuantity.Value);

                if (seAmountList[i].total_each > seAmountList[i].mat_Each)
                {
                    _Index_List.Add(i);
                }
            }
            dgvAmountChild.DataSource = null;
            dgvAmountChild.DataSource = seAmountList;

            for (int i = 0; i < _Index_List.Count; i++)
            {
                dgvAmountChild.Rows[_Index_List[i]].DefaultCellStyle.ApplyStyle(cs);
            }
            dgvAmountChild.ClearSelection();
        }
    }
}