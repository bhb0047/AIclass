﻿using System.Windows.Forms;
using IceCreamManager.VO;
using IceCreamManager.Service;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace IceCreamManager
{
    public partial class OffererOderDialogue : Form
    {

        List<OrderSubVO> Sublist; //자재번호 자재이름,제조사번호 제조사이름 
        private List<OffererOrderForDgvVO> ofodgvlist;
        int sumprice = 0;
        public OffererOderDialogue()
        {
            InitializeComponent();
        }

        public OffererOderDialogue(List<OffererOrderForDgvVO> ofodgvlist) : this()
        {
            this.ofodgvlist = ofodgvlist;
        }

        private void OffererOderDialogue_Load(object sender, System.EventArgs e)
        {
            DatagridviewDesigns.SetDesign(dgvOrder);

            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "발주개수", "", true, 120); //제조사이름
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "발주코드", "", true, 100); //제조사전화번호      
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "제조사코드", "", true, 80); //담당자이름
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "주문타입코드", "", true, 100); //제조사주소
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "발주가격", "", true, 100); //제조사주소
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "발주날짜", "", true, 100); //제조사주소


            DataLoad();

            Dictionary<int, string> mnlist = Sublist.ToDictionary( item => item.mat_No, item => item.mat_Name);
            cbbMaerialsName.DisplayMember = "Value";
            cbbMaerialsName.ValueMember = "Key";
            cbbMaerialsName.DataSource = new BindingSource(mnlist, null);

            lbldata.Text = DateTime.Now.ToShortDateString();
            int price = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mat_Cost;

            int sum = Convert.ToInt32(nudEach.Value) * price;
            txtprice.Text = sum.ToString();

            if(ofodgvlist != null)
            {
                foreach (OffererOrderForDgvVO item in ofodgvlist)
                {
                    dgvOrder.Rows.Add(item.ofo_Each, item.mat_No, item.off_No, item.cmt_No, item.ofo_Price, item.ofo_DateTime);
                }
            }

        }
        private void DataLoad()
        {
            OrderService service = new OrderService();

            (_, Sublist) = service.SelectAll();

        }
        private void setting()
        {
            //전체초기화 합당한 값 제공!
            cbbMaerialsName.SelectedIndex = 0;

            txtMaterialsCode.Text = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mat_No.ToString();
            txtOffererName.Text = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).off_Name.ToString();
            nudEach.Value = 1;
            txtprice.Text = (Convert.ToInt32(nudEach.Value) * Convert.ToInt32(Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mat_Cost)).ToString();
            lblType.Text = "g";
        }
        /// <summary>
        /// 자재명선택시
        /// </summary>
        private void cbbMaerialsName_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            txtMaterialsCode.Text = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mat_No.ToString();
            txtOffererName.Text = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).off_Name.ToString();
            txtprice.Text = Sublist.Find(item=> item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mat_Cost.ToString();

            int type = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mtt_No;
            if (type == 3)
            {
                lblType.Text = "g";
            }
            else
            {

                lblType.Text = "L";
            }
        
        }
        /// <summary>
        /// 개수에따른 가격변동
        /// </summary>
        private void nudEach_ValueChanged(object sender, EventArgs e)
        {
            int price = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mat_Cost;

            int sum = Convert.ToInt32(nudEach.Value) * price;
            txtprice.Text = sum.ToString();
        }
        private void nudEach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                int price = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).mat_Cost;

                int sum = Convert.ToInt32(nudEach.Value) * price;
                txtprice.Text = sum.ToString();

            }


        }
        /// <summary>
        /// 자제 추가
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
 
            int offno;
            bool check = false;
  
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells[1].Value.ToString() == cbbMaerialsName.SelectedValue.ToString())
                {
                    row.Cells[0].Value = Convert.ToInt32(row.Cells[0].Value) + Convert.ToInt32(nudEach.Value);
                    row.Cells[4].Value = Convert.ToInt32(row.Cells[4].Value) + Convert.ToInt32(txtprice.Text);
                    check = true;
                    break;
                }
            }
            if (check == false)
            {
                offno = Sublist.Find(item => item.mat_No == Convert.ToInt32(cbbMaerialsName.SelectedValue)).off_No;

                dgvOrder.Rows.Add(Convert.ToInt32(nudEach.Value), Convert.ToInt32(cbbMaerialsName.SelectedValue)
                   , offno, 1, Convert.ToInt32(txtprice.Text), lbldata.Text);
                //발주갯수, 자재코드 제조사코드, 주문타입default1, 발주가격, 발주날짜
            }


            int sum=0;
            for(int i=0; i<dgvOrder.Rows.Count; i++)
            {
                sum += Convert.ToInt32( dgvOrder.Rows[i].Cells[4].Value);
            }
            sumprice = sum;
            lblSumPrice.Text = sumprice.ToString();

            setting();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {


            OrderService service = new OrderService();
            foreach (DataGridViewRow row in dgvOrder.Rows) //총가격
            {
                OrderVO order = new OrderVO();
                order.ofo_Each = Convert.ToInt32(row.Cells[0].Value);
                order.mat_No = Convert.ToInt32(row.Cells[1].Value);
                order.off_No = Convert.ToInt32(row.Cells[2].Value);
                order.cmt_No = Convert.ToInt32(row.Cells[3].Value);
                order.ofo_Price = Convert.ToInt32(row.Cells[4].Value);
                order.ofo_Date = Convert.ToDateTime(Convert.ToDateTime(row.Cells[5].Value).ToShortDateString());
                service.Insert(order);
            }
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (DataGridViewRow row in dgvOrder.SelectedRows)
            {
                sum = Convert.ToInt32(row.Cells[4].Value);
                dgvOrder.Rows.Remove(row);
            }
           
            sumprice = sumprice- sum;
          lblSumPrice.Text = sumprice.ToString();
        }
    }
}
