﻿using System;
using System.Windows.Forms;
using IceCreamManager.VO;
using IceCreamManager.Service;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace IceCreamManager
{
    public partial class OffererOder_Form : Form
    {

        List<OrderVO> Orderlist;
        List<OrderVO> Filterlist1 = new List<OrderVO>(); //입고되지않은 자제들만
        List<OrderVO> Filterlist2 = new List<OrderVO>(); //입고된 자제들
        OrderService service = new OrderService();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private bool cFlag = false;
        List<OffererOrderForDgvVO> ofodgvlist;

        public OffererOder_Form()
        {
            InitializeComponent();
        }

        public OffererOder_Form(bool cFlag, List<OffererOrderForDgvVO> list) : this()
        {
            this.cFlag = cFlag;
            ofodgvlist = list;
        }
        private void OffererOder_Form_Shown(object sender, EventArgs e)
        {
            if (cFlag)
            {
                btnOrder_Click(null, null);
            }
        }

        /// <summary>
        /// 발주버튼
        /// </summary>
        private void btnOrder_Click(object sender, EventArgs e)
        {
            OffererOderDialogue frm;
            if (cFlag)
                frm = new OffererOderDialogue(ofodgvlist);
            else
                frm = new OffererOderDialogue();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataLoad();
                Mtimer();
            }
        }
        private void OffererOder_Form_Load(object sender, EventArgs e)
        {
            DatagridviewDesigns.SetDesign(dgvOrder);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "발주번호", "ofo_No", true, 80); //발주코드      
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "제조사번호", "off_No", true, 80); //제조사번호       
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "제조사", "off_Name", true, 110); //제조사번호
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "자재번호", "mat_No", true, 80); //자재번호
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "자재이름", "mat_Name", true, 150); //자재번호
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "발주개수", "ofo_Each", true, 80); //발주개수                   
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "총금액", "ofo_Price", true, 90); //총금액         
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "발주날짜", "ofo_Date", true, 100); //발주날짜   
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "상태", "cmt_No", true, 55); //주문상태번호
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvOrder, "주문 상태", "cmt_Type", true, 100); //주문상태번호

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "발주관리";
            btn.Text = "확인";
            btn.Name = "btn";
            btn.Width = 100;
            btn.UseColumnTextForButtonValue = true;
            dgvOrder.Columns.Add(btn);

            DataGridViewButtonColumn orderbtn = new DataGridViewButtonColumn();
            orderbtn.HeaderText = "발주서";
            orderbtn.Text = "발주서";
            orderbtn.Name = "orderbtn";
            orderbtn.Width = 100;
            orderbtn.UseColumnTextForButtonValue = true;
            dgvOrder.Columns.Add(orderbtn);

            DatagridviewDesigns.SetDesign(dgvCompletion);
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "발주번호", "ofo_No", true, 90); //발주코드      
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "제조사번호", "off_No", true, 90); //제조사번호       
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "제조사", "off_Name", true, 130); //제조사번호   
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "자재번호", "mat_No", true, 160); //자재번호
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "자재이름", "mat_Name", true, 160); //자재번호
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "발주개수", "ofo_Each", true, 110); //발주개수                   
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "총금액", "ofo_Price", true, 110); //총금액         
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "발주날짜", "ofo_Date", true, 130); //발주날짜     
            DatagridviewDesigns.AddNewColumnToDataGridView(dgvCompletion, "주문 상태", "cmt_Type", true, 110); //주문상태번호

            DataLoad();
        }
        private void Mtimer()
        {
            timer.Interval = 4000; // 4초
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }


        private void DataLoad()
        {
            (Orderlist, _) = service.SelectAll();

            Filterlist1 = new List<OrderVO>(); //입고가되지않은 제품들만
            Filterlist1 = Orderlist.FindAll(item => item.cmt_No != 4);
            dgvOrder.DataSource = Filterlist1;

            Filterlist2 = new List<OrderVO>(); //입고가되지않은 제품들만
            Filterlist2 = Orderlist.FindAll(item => item.cmt_No == 4);
            Filterlist2.Sort(delegate (OrderVO a, OrderVO b)
            {
                if (a.ofo_No < b.ofo_No)
                    return 1;
                else if (a.ofo_No > b.ofo_No)
                    return -1;
                return 0;
            });
            dgvCompletion.DataSource = Filterlist2;
        }


        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == dgvOrder.Columns["btn"].Index)
            {
                if (Convert.ToInt32(dgvOrder.SelectedRows[0].Cells[8].Value) == 3)//만약 발주상태가 배송완료라면
                {
                    int count = 0;
                    foreach (var item in Filterlist1)
                    {
                        count++;
                        if (item.ofo_No == Convert.ToInt32(dgvOrder.SelectedRows[0].Cells[0].Value))
                        {
                            Filterlist1.Remove(item);
                            item.cmt_No = 4;
                            item.cmt_Type = "배송완료";
                            Filterlist2.Add(item);
                            service.Update(item.ofo_No, 4);
                            service.MaterialEachUpdate(item.mat_No, item.ofo_Each);//입고된 자제 갯수 업데이트

                            break;
                        }
                    }

                    dgvOrder.DataSource = null; //datasource를 비워준다 이때    dgvOrder.Refresh()는 사용하면 안된다.
                    dgvOrder.DataSource = Filterlist1; //다시 데이터를 넣어준다.

                    dgvCompletion.DataSource = null;
                    Filterlist2.Sort(delegate (OrderVO a, OrderVO b)
                    {
                        if (a.ofo_No < b.ofo_No)
                            return 1;
                        else if (a.ofo_No > b.ofo_No)
                            return -1;
                        return 0;
                    });
                    dgvCompletion.DataSource = Filterlist2;

                    //****************
                    // 제품 수량 증가시켜야됨.          

                    MessageBox.Show("자재창고에 입고되었습니다."); //거래처명세서를 볼수 있다!

                    foreach (Form childForm in System.Windows.Forms.Application.OpenForms)
                    {
                        if (childForm.GetType() == typeof(Offerer_Form))   //리플렉션
                        {
                            ((Offerer_Form)childForm).DataLoad();
                            childForm.Activate();
                            return;
                        }
                    }

                    Offerer_Form frm = new Offerer_Form();             
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("자재가 배송되지 않았습니다.");
                }

            }

            ///발주서 버튼 excel
            if (e.ColumnIndex == dgvOrder.Columns["orderbtn"].Index)
            {
                Cursor = Cursors.WaitCursor;
                List<OrderVO> excellist = Filterlist1.FindAll(item => item.off_No == Convert.ToInt32(dgvOrder.SelectedRows[0].Cells[1].Value));

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                string startPath = System.Windows.Forms.Application.StartupPath + @"\order.xls";
                int sum = 0;
                saveFileDialog.Filter = "Excel Files (*.xls)|*.xls";
                saveFileDialog.InitialDirectory = "C:";
                saveFileDialog.Title = "Save";
                try
                {

              
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                        Cursor = Cursors.WaitCursor;
                        xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(Filename: startPath);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    // C:\team4\IceCreamManager\IceCreamManager\Sample

                    xlWorkSheet.Range["E6"].Value = excellist[0].off_Name;//제조사이름
                    xlWorkSheet.Range["E7"].Value = excellist[0].off_No;//제조사코드                      
                    xlWorkSheet.Range["E8"].Value = excellist[0].off_Addr;//제조사주소  
                    xlWorkSheet.Range["E9"].Value = excellist[0].off_OwnerMobile;//제조사 전화번호
                    xlWorkSheet.Cells[4, 2] = excellist[0].ofo_Date;//작성일
                    xlWorkSheet.Cells[8, 3] = excellist[0].off_Manager;//담당자이름
                    xlWorkSheet.Cells[9, 3] = excellist[0].off_ManagerMobile;//담당자 전화번호
                                                                             // if (File.Exists(savFileName)) File.Delete(savFileName);

                    for (int i = 12; i < excellist.Count + 12; i++)
                    {
                        for (int j = 2; j < 7; j++)
                        {

                            if (j == 2)
                            {
                                xlWorkSheet.Cells[i, j] = excellist[i - 12].mat_No;//자제코드
                            }
                            else if (j == 3)
                            {
                                xlWorkSheet.Cells[i, j] = excellist[i - 12].mat_Name;//자제이름
                            }
                            else if (j == 4)
                            {
                                continue;
                            }
                            else if (j == 5)
                            {
                                xlWorkSheet.Cells[i, j] = excellist[i - 12].ofo_Each;//자제수량
                            }
                            else if (j == 6)
                            {
                                xlWorkSheet.Cells[i, j] = excellist[i - 12].ofo_Price;//자제 가격
                                    sum+= excellist[i - 12].ofo_Price;
                                }
                        }
                    }
                        xlWorkSheet.Range["C29"].Value = sum;//제조사 전화번호
                        xlWorkBook.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlWorkbookNormal);
                    xlWorkBook.Close(true);
                    xlApp.Quit();


                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);
                        Marshal.ReleaseComObject(xlApp);
                        MessageBox.Show("발주서가 저장되었습니다.","알림",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                catch (Exception err)
                {

                    MessageBox.Show("발주서 저장에 실패하였습니다."+err.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }

        }

      
        private void timer_Tick(object sender, EventArgs e)
        {

            int a = Filterlist1.FindAll(item => item.cmt_No == 1).Count;
            a = a + Filterlist1.FindAll(item => item.cmt_No == 2).Count;

            if (a < 1) //배송중과 발주중인 자제가 없다면
            {
                timer.Stop();

            }
            else
            {

                int count = 0;
                foreach (var item in Filterlist1)
                {
                    count++;

                    if (item.cmt_No == 1) //시간에 따라서 배송중 배송완료로 변경
                    {
                        service.Update(item.ofo_No, 2);

                    }
                    else if (item.cmt_No == 2)
                    {
                        service.Update(item.ofo_No, 3);

                    }
                }

                DataLoad();

                dgvOrder.DataSource = null; //datasource를 비워준다 이때    dgvOrder.Refresh()는 사용하면 안된다.
                dgvOrder.DataSource = Filterlist1; //다시 데이터를 넣어준다.  

            }


        }


        private void btnExport_Click(object sender, EventArgs e)
        {

            //Excel.Application xlApp;
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;

            //    xlApp = new Excel.Application();
            //    xlWorkBook = xlApp.Workbooks.Open(Filename: @"c:\temp\orderxlsx.xlsx");
            //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            //xlWorkSheet.Cells[1, 1] = "aa";


            //xlWorkBook.SaveAs("asd", Excel.XlFileFormat.xlWorkbookNormal);
            //    xlWorkBook.Close(true);
            //    xlApp.Quit();




            //try
            //{

            //    var dataList = (List<OrderVO>)dgvOrder.DataSource;
            //    Excel.Application excel = new Excel.Application(); //엑셀을 하나 연다.
            //                                                       //     excel.Application.Workbooks.Add(true);
            //    Excel.Workbook excelBook = excel.Workbooks.Add(true);
            //    Excel.Worksheet worksheet = null;
            //    Microsoft.Office.Interop.Excel.Range range = null;

            //    range = worksheet.get_Range("A2:L2");

            //    range.Merge(Type.Missing);

            //    //엑셀타이틀 =>list프로퍼티명
            //    int columnIndex = 0;
            //    foreach (PropertyInfo prop in typeof(OrderVO).GetProperties()) //getproperties 모든 프로퍼티를 가져온다.
            //    {
            //        if (!prop.Name.Equals("Photo"))
            //        {
            //            columnIndex++; //엑셀의 셀을찍을떄는 1,1부터 찍기때문에 먼저 ++해준다.
            //            excel.Cells[2, columnIndex] = prop.Name; //타이틀 찍기
            //        }
            //    }

            //    //데이타
            //    int rowIndex = 1;

            //    foreach (OrderVO emp in dataList)
            //    {
            //        columnIndex = 0;
            //        rowIndex++;
            //        foreach (PropertyInfo prop in typeof(OrderVO).GetProperties()) //getproperties 모든 프로퍼티를 가져온다.
            //        {
            //            columnIndex++; //엑셀의 셀을찍을떄는 1,1부터 찍기때문에 먼저 ++해준다.
            //            if (prop.GetValue(emp, null) != null)
            //            {
            //                excel.Cells[rowIndex, columnIndex] = prop.GetValue(emp, null).ToString(); //데이터 찍기 이엠피의 값을 가져온다 없다면 null을 준다
            //            }
            //        }
            //    }

            //    //파일 마무리(저장 또는 엑셀프로그램 보여주기)
            //    excel.Visible = true; //만들은 엑셀을 보여준다.
            //    Excel._Worksheet workSheet = (Excel.Worksheet)excel.ActiveSheet;
            //    workSheet.Activate();
            //}
            //catch (Exception err)
            //{

            //    MessageBox.Show(err.Message);
            //}






        }
    }
}
