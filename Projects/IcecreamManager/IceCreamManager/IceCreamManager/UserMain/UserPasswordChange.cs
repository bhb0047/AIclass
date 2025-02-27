﻿using IceCreamManager.Service;
using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamManager
{
    public partial class UserPasswordChange : Form
    {
        string errorMessage = string.Empty;
        public UserPasswordChange()
        {
            InitializeComponent();
        }

        

        private void BtnPwdChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginChecked())
                {

                    UserInfoVO uif = new UserInfoVO();
                    uif.cus_ID = Global.Cus_Id;
                    uif.cus_Password = txtpwd.Text;
                    uif.PasswordChange = newpwd1.Text;

                    UserService service = new UserService();           
                    bool PwdCheak = service.PwdCheak(uif);
                    if (PwdCheak == true)
                    {
                        if (service.PwdChange(uif) > 0 )
                        {
                            MessageBox.Show("성공적으로변경되었습니다.","성공");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("변경 중 오류가 발생했습니다. 다시 시도하여 주십시오.","오류");
                        }
                    }
                    else
                    {
                        MessageBox.Show("현재 비밀번호가 일치하지 않습니다. 다시한번 확인해주세요.","오류");
                    }
                }
                else
                {
                    MessageBox.Show(this.errorMessage, "비밀번호 변경 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string PwdPattern = @"^(?=.{8,}$)(?=[^A-Z]*[A-Z][^A-Z]*$)\w*\W\w*$";

            if (newpwd1.Text.Trim() == string.Empty)
            {
                errorMessage += "비밀번호를 입력해주세요. \n";
            }
            if (newpwd1.Text.Trim() != newpwd2.Text.Trim())
            {
                errorMessage += "비밀번호가 서로 다릅니다. \n";
            }

            if (!Regex.IsMatch(newpwd1.Text, PwdPattern))
            {
                errorMessage += "하나의 대문자, 하나의 특수 문자 및 영숫자를 포함하여 8 자 여야 합니다.\n";
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

    }
}
