﻿using System.ComponentModel;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class OffererDialogue_Form : Form
    {

         int off_No; //제조사번호
         string off_Name;//제조사이름
         string off_OwnerName;//대표이름
        string off_OwnerMobile;//대표번호
        string off_Manager;//담당자이름
        string off_ManagerMobile;//담당자
        string off_Addr;//제조사주소

        public int Off_No { get => off_No; set => off_No = value; }
        public string Off_Name { get => off_Name; set => off_Name = value; }
        public string Off_OwnerName { get => off_OwnerName; set => off_OwnerName = value; }
        public string Off_OwnerMobile { get => off_OwnerMobile; set => off_OwnerMobile = value; }
        public string Off_Manager { get => off_Manager; set => off_Manager = value; }
        public string Off_ManagerMobile { get => off_ManagerMobile; set => off_ManagerMobile = value; }
        public string Off_Addr { get => off_Addr; set => off_Addr = value; }


        public OffererDialogue_Form()
        {
            InitializeComponent();

       
        }

        private void OffererDialogue_Form_Load(object sender, System.EventArgs e)
        {
            txtCode.Text = Off_No.ToString();
            txtOffererName.Text = Off_Name;
            txtOwnerName.Text = Off_OwnerName;
            txtPhone.Text = Off_OwnerMobile;
            txtAddress.Text = Off_Addr;
            txtManager.Text = Off_Manager;
            txtMgPhone.Text = Off_ManagerMobile;
        }
    }
}
