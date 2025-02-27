﻿using IceCreamManager.Service;
using IceCreamManager.UserMain;
using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static IceCreamManager.UserMain.ProductListUserControl;

namespace IceCreamManager
{

    public partial class UserMain3 : Form
    {
        List<CustomerOrderDetailProductConnectVO> orderDetailsList;
        string pName = string.Empty;
        List<ProductVO> list;
        public UserMain3()
        {
            InitializeComponent();
        }
        public string Pro_Size { get; set; }

        int iPro_Size;
        int Pro_Price;            

    private void PictureBox3_Click(object sender, EventArgs e)
        {
            UserMain2 frm = new UserMain2
            {
                MdiParent = (UserMain1)this.MdiParent,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
            this.Close();
        }// 뒤 폼으로 돌아가는 버튼


        private void PictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                if(numericUpDown1.Value == 0)
                {
                    MessageBox.Show("아이스크림을 선택해주세요", "확인");
                    return;
                }

                if (labMenu.Text.Length > 1 && numericUpDown1.Value != 0 && labPrice.Text != "0")
                {
                    if (orderDetailsList == null)
                        orderDetailsList = new List<CustomerOrderDetailProductConnectVO>();

                    int index = orderDetailsList.FindIndex(p => p.pro_Name == labMenu.Text && p.cod_Size == iPro_Size);

                    if (index >= 0)
                    {
                        orderDetailsList[index].cod_Each = orderDetailsList[index].cod_Each + Convert.ToInt32(numericUpDown1.Value);
                        orderDetailsList[index].cod_Price = (1500 * iPro_Size) * orderDetailsList[index].cod_Each;
                    }
                    else
                    {
                        CustomerOrderDetailProductConnectVO newItem = new CustomerOrderDetailProductConnectVO();
                        newItem.cod_Size = iPro_Size;
                        newItem.pro_Name = labMenu.Text;
                        newItem.cod_Each = Convert.ToInt32(numericUpDown1.Value);
                        newItem.cod_Price = int.Parse(labPrice.Text);
                        newItem.pro_No = int.Parse(Pro_No.Text);

                        orderDetailsList.Add(newItem);
                        
                    }

                    UserMain4 frm = new UserMain4();
                    frm.MdiParent = (UserMain1)this.MdiParent;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.DetailList = orderDetailsList;
                   
                    int sum = 0;
                    foreach (CustomerOrderDetailProductConnectVO item in orderDetailsList)
                    {
                        sum += item.cod_Price;
                    }
                    frm.Allprice = sum;
                    frm.Show();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show("아이스크림을 선택해주세요", "확인");
                }
            }
            catch
            {
                MessageBox.Show("아이스크림을 선택해주세요", "확인");
            }


        } // 다음 폼으로 가는 버튼
        private void MyUserControl1_OrderClick(object sender, UserOrderEventArgs eArgs)
        {
            picIceCream.BackColor = Color.White;
            numericUpDown1.Visible = true;
            pName = labMenu.Text;
            labMenu.Text = eArgs.ProductName;
            picIceCream.BackgroundImage = eArgs.PImage;
            Pro_Price = eArgs.Price;
            Pro_No.Text = eArgs.ProductID.ToString();

            if (pName == eArgs.ProductName)
                numericUpDown1.UpButton();
            else
                numericUpDown1.Value = 1;
        } // 유저컨트롤 클릭 메서드
        private void UserMain3_Load(object sender, EventArgs e)
        {
            GetAllProductData(); // 모든 제품을 가져옴
   
            numericUpDown1.Visible = false;

            // 동적버튼 생성 for

            int i=0;
            foreach (var item in list)
            {
                i++;
                ProductListUserControl ctrl = new ProductListUserControl();
                ctrl.Name = "btn" + i.ToString();
                ctrl.Size = new System.Drawing.Size(207, 176);
                ctrl.PID = item.pro_No.ToString();
                ctrl.PName = item.pro_Name;
                ctrl.Price = item.pro_Price;
                if (item.pro_Img != null)
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                    ctrl.Picture = (Bitmap)(tc.ConvertFrom(item.pro_Img));
                }
                ctrl.OrderClick += new UserOrderEvent(this.MyUserControl1_OrderClick);

                this.flowListShow.Controls.Add(ctrl);
            }
            ((UserMain1)this.MdiParent).btnlogout.Visible = true;
            ((UserMain1)this.MdiParent).btnOrderDetails.Visible = true;
            ((UserMain1)this.MdiParent).label2.Visible = true;
            ((UserMain1)this.MdiParent).labName.Visible = true;
        } //로드
        private void GetAllProductData()
        {
            ProductService service = new ProductService();
            list = service.GetAllProductData();
        } // 모든 제품을 가져오는 메서드
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
               labPrice.Text = (numericUpDown1.Value * (iPro_Size * Pro_Price)).ToString();  
        } // 벨류 체인지

        private void UserMain3_Activated(object sender, EventArgs e)
        {
            labMenu.Text = "";
            numericUpDown1.Value = 0;
            labPrice.Text = "0";
            labSize.Text = Pro_Size; // 이전 폼의 사이즈 
            switch (Pro_Size)
            {
                case "주니어":
                    iPro_Size = 1;
                    break;
                case "레귤러":
                    iPro_Size = 2;
                    break;
                case "킹":
                    iPro_Size = 3;
                    break;
                default:
                    throw new Exception("사이즈를 설정해주세요.");
            }
        }
    }
}
