﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using IceCreamManager.Service;
using IceCreamManager.VO;
namespace IceCreamManager
{
    public partial class Salescheck_Form : Form
    {
        SalescheckService service = new SalescheckService();
        List<SalescheckCVO> customerlist = new List<SalescheckCVO>();  //회원별
        List<UserVO> userlist = new List<UserVO>();//유저리스트
        List<SalescheckMVO> materiallist = new List<SalescheckMVO>(); //전체, 상품별


        public Salescheck_Form()
        {
            InitializeComponent();
        }
        private void Salescheck_Form_Load(object sender, EventArgs e)
        {
            cbbChoice.Items.Add("제품전체");
            cbbChoice.Items.Add("회원별");
            cbbChoice.Items.Add("제품별");

            //회원별은 list가 변경되지 않아서 db에 한번만 다녀오려고
            customerlist = service.SelectAllC(dtpStart.Value.ToShortDateString(), dtpEnd.Value.AddDays(1).ToShortDateString());


            // 유저 콤보박스    
            userlist = service.SelectUser();
            UserVO user = new UserVO();
            user.cus_Name = "전체";
            user.cus_No = 0;
            userlist.Insert(0, user);
            cbbCustomer.DataSource = userlist;
            cbbCustomer.ValueMember = "cus_No";
            cbbCustomer.DisplayMember = "cus_Name";

        }
        private void datagridview()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            DatagridviewDesigns.SetDesign(dataGridView1);
            DatagridviewDesigns.AddNewColumnToDataGridView(dataGridView1, "주문일", "cuo_Datetime", true, 250); //제조사주소
            if (cbbChoice.Text == "회원별")
            {
                DatagridviewDesigns.AddNewColumnToDataGridView(dataGridView1, "고객코드", "cus_No", true, 150); //제조사주소
                DatagridviewDesigns.AddNewColumnToDataGridView(dataGridView1, "이름", "cus_Name", true, 150); //제조사주소
            }
            DatagridviewDesigns.AddNewColumnToDataGridView(dataGridView1, "제품코드", "pro_No", true, 60);
            DatagridviewDesigns.AddNewColumnToDataGridView(dataGridView1, "제품이름", "pro_Name", true, 150); //제조사주소
            DatagridviewDesigns.AddNewColumnToDataGridView(dataGridView1, "제품개수", "cod_Each", true, 150); //제조사주소
            DatagridviewDesigns.AddNewColumnToDataGridView(dataGridView1, "가격", "pro_Price", true, 150); //제조사주소
        }
        private void chartShow()
        {
            DateTime start = DateTime.Parse(dtpStart.Value.ToShortDateString());
            DateTime end = DateTime.Parse(dtpEnd.Value.ToShortDateString());

            TimeSpan day = end - start;
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].LegendText = "제품";

           int sum = 0;
            if (cbbChoice.Text == "제품전체")
            {
                if (day.TotalDays <= 31.0) //한달
                {
                    //제품별
                    
                        var productName = materiallist.GroupBy(item => item.cuo_Datetime.ToShortDateString()).Select(item => new { name = item.Key, sum = item.Sum(y => y.pro_Price) }).ToList();
                        for (int i = 0; i < productName.Count; i++)
                        {
                            chart1.Series["Series1"].Points.AddXY(productName[i].name, productName[i].sum);
                            chart1.Series["Series1"].ToolTip = productName[i].sum.ToString() + "원";
                            sum += productName[i].sum;
                            txtSales.Text = sum.ToString();
                        }
                    
                }
                else //한달이상
                {
                    //제품별
                  
                        var productName = materiallist.GroupBy(item => item.cuo_Datetime.Month).Select(item => new { name = item.Key, sum = item.Sum(y => y.pro_Price) }).ToList();
                        for (int i = 0; i < productName.Count; i++)
                        {
                            chart1.Series["Series1"].Points.AddXY(productName[i].name, productName[i].sum);
                            chart1.Series["Series1"].ToolTip = productName[i].sum.ToString() + "원";
                            sum += productName[i].sum;
                            txtSales.Text = sum.ToString();
                        }
                    
                }
            }
            else if (cbbChoice.Text == "회원별")
            {
                //제품별
                if (cbbCustomer.SelectedIndex == 0) //전체선택
                {
                    var productName = customerlist.GroupBy(item => item.cus_Name).Select(item => new { name = item.Key, sum = item.Sum(y => y.pro_Price) }).ToList();
                    for (int i = 0; i < productName.Count; i++)
                    {
                        chart1.Series["Series1"].Points.AddXY(productName[i].name, productName[i].sum);
                        chart1.Series["Series1"].ToolTip = productName[i].sum.ToString() + "원";
                        sum += productName[i].sum;
                        txtSales.Text = sum.ToString();
                    }
                }
                else
                {
                    var productName = customerlist.FindAll(item => item.cus_No == Convert.ToInt32(cbbCustomer.SelectedValue)).GroupBy(item => item.pro_Name).Select(item => new { name = item.Key, sum = item.Sum(y => y.pro_Price) }).ToList();
                    for (int i = 0; i < productName.Count; i++)
                    {
                        chart1.Series["Series1"].Points.AddXY(productName[i].name, productName[i].sum);
                        chart1.Series["Series1"].ToolTip = productName[i].sum.ToString() + "원";
                        chart1.Series["Series1"].LegendText = "회원";
                        sum += productName[i].sum;
                        txtSales.Text = sum.ToString();
                    }
                }
            }
            else if (cbbChoice.Text == "제품별")
            {
                //제품별
                var productName = materiallist.GroupBy(item => item.pro_Name).Select(item => new { name = item.Key, sum = item.Sum(y => y.pro_Price) }).ToList();
                for (int i = 0; i < productName.Count; i++)
                {
                    if (productName[i].name == "소계" || productName[i].name == "합계")
                    {
                        continue;
                    }
                    chart1.Series["Series1"].Points.AddXY(productName[i].name, productName[i].sum);
                    chart1.Series["Series1"].ToolTip = productName[i].sum.ToString() + "원";
                    sum += productName[i].sum;
                    txtSales.Text = sum.ToString();
                }
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("날짜를 잘 못 선택 하셨습니다.");
                return;
            }
            //List<SalescheckMVO> materiallist = new List<SalescheckMVO>(); //제품전체 ,제품별 판매금액

            datagridview();
            if (cbbChoice.Text == "제품전체")
            {
                materiallist = service.SelectAllM(dtpStart.Value.ToShortDateString(), dtpEnd.Value.AddDays(1).ToShortDateString(), 1);
                dataGridView1.DataSource = materiallist;
            }
            else if (cbbChoice.Text == "회원별")
            {
                dataGridView1.DataSource = null;
                if (cbbCustomer.SelectedIndex == 0) //전체선택
                {
                    dataGridView1.DataSource = customerlist;
                }
                else//특정 회원선택
                {
                    dataGridView1.DataSource = customerlist.FindAll(item => item.cus_No == Convert.ToInt32(cbbCustomer.SelectedValue));
                }
            }
            else if (cbbChoice.Text == "제품별")
            {
                materiallist = service.SelectAllM(dtpStart.Value.ToShortDateString(), dtpEnd.Value.AddDays(1).ToShortDateString(), 2);
                dataGridView1.DataSource = materiallist;
            }
         
            txtSales.Text = "0";
            chartShow();
        }
        private void CbbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbChoice.Text == "회원별")
            {
                cbbCustomer.Visible = true;
            }
            else
            {
                cbbCustomer.Visible = false;
            }
        }
    }
}
