﻿using IceCreamManager.Service;
using IceCreamManager.VO;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class UserJoin : Form
    {
        string errorMessage = string.Empty;
        public UserJoin()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginChecked())
                {
                    UserInfoVO uif = new UserInfoVO();

                    uif.cus_ID = cus_ID.Text.Trim();
                    uif.cus_Password = cus_Password1.Text.Trim();
                    uif.cus_Name = cus_Name.Text.Trim();
                    uif.cus_Phone = cus_Phone.Text.Trim();
                    uif.cus_Addr = cus_Addr.Addr1.Trim() + cus_Addr.Addr2.Trim();
                    uif.cus_Email = cus_Email.Text.Trim();
                    uif.IsManager = 0;

                    UserService service = new UserService();
                    bool bResult = service.UserSiginUp(uif);
                    if (bResult)
                    {
                        MessageBox.Show("성공적으로 등록되었습니다.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("등록 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
                    }
                }
                else
                {
                    MessageBox.Show(this.errorMessage, "회원가입 경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.errorMessage = string.Empty;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private bool LoginChecked()
        {

            string phonePattern = @"^\d{2,3}-\d{3,4}-\d{4}$";
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            string PwdPattern = @"^(?=.{8,}$)(?=[^A-Z]*[A-Z][^A-Z]*$)\w*\W\w*$";

            if (cus_ID.Text.Trim() == string.Empty)
            {
                errorMessage += "ID를 입력해주세요. \n";
            }
            if (cus_Password1.Text.Trim() == string.Empty)
            {
                errorMessage += "비밀번호를 입력해주세요. \n";
            }
            if (cus_Password1.Text.Trim() != cus_Password2.Text.Trim())
            {
                errorMessage += "비밀번호가 서로 다릅니다. \n";
            }

            if (!Regex.IsMatch(cus_Password1.Text, PwdPattern))
            {
                errorMessage += "하나의 대문자, 하나의 특수 문자 및 영숫자를 포함하여 8 자 여야 합니다.\n";
            }

            if (cus_Name.Text.Trim() == string.Empty)
            {
                errorMessage += "이름을 입력해주세요. \n";
            }
            if (!Regex.IsMatch(cus_Phone.Text, phonePattern))
            {
                errorMessage += "전화번호 형식이 아닙니다.\n";
            }
            if (cus_Addr.Addr1.Trim() == string.Empty)
            {
                errorMessage += "주소를 입력해주세요. \n";
            }
            if (!Regex.IsMatch(cus_Email.Text, emailPattern))
            {
                errorMessage += "이메일 형식이 아닙니다.\n";
            }
            if (errorMessage == string.Empty)
            {              
                return true;
            }
            else
            {
                errorMessage.Insert(0, "등록실패 \n\n");

                return false;
            }

        }
        private void BtnIDcheck_Click(object sender, EventArgs e)
        {
            UserInfoVO uvo = new UserInfoVO
            {
                cus_ID = cus_ID.Text.Trim()
            };

            UserService service = new UserService();
            bool bResult = service.UserIDCheck(uvo);

            if (cus_ID.Text.Length > 0)
            {
                if (bResult == false)
                {
                    MessageBox.Show("아이디가 중복되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cus_ID.Focus();
                    cus_ID.Text = string.Empty;
                    return;
                }
                else
                {
                    MessageBox.Show("사용가능한 아이디 입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("아이디를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cus_ID.Focus();
            }
        }
    }
}
