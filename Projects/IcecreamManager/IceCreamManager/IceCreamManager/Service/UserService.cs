﻿using System;
using System.Collections.Generic;
using IceCreamManager.DAC;
using IceCreamManager.VO;

namespace IceCreamManager.Service
{
    public class UserService
    {
      

        public bool UserSiginUp(UserInfoVO emp)
        {
            UserDAC dac = new UserDAC();
            return dac.UserSiginUp(emp);
        }
        public bool PwdCheak(UserInfoVO emp) //비밀번호 변경시 현재 비밀번호가 맞는지 확인하는 것
        {
            UserDAC dac = new UserDAC();
            return dac.PwdCheak(emp);
        }
  
        public bool UserIDCheck(UserInfoVO emp) // 아이디 중복확인
        {
            UserDAC dac = new UserDAC();
            return dac.UserIDCheck(emp);
        }

        public string UserIDSearch(UserInfoVO uvo) // 아이디 있는 없는지 확인 있으면 그 아이디를 가지고온다
        {
            UserDAC dac = new UserDAC();
            return dac.UserIDSearch(uvo);
        }

        public string UserName(UserInfoVO uvo) // 아이디 있는 없는지 확인 있으면 그 아이디를 가지고온다
        {
            UserDAC dac = new UserDAC();
            return dac.UserName(uvo);
        }

        public bool UserEmailCheck(UserInfoVO emp) // 아이디 찾기
        {
            UserDAC dac = new UserDAC();
            return dac.UserEmailCheck(emp);
        }
    
        public int UserPWDUpdate(UserInfoVO uvo) //패스워드 찾기
        {
            UserDAC dac = new UserDAC();
            return dac.UserPWDUpdate(uvo);
        }

        public int PwdChange(UserInfoVO uvo) //패스워드 변경
        {
            UserDAC dac = new UserDAC();
            return dac.PwdChange(uvo);
        }

        public bool? ManagerCheck(UserInfoVO emp)
        {
            UserDAC dac = new UserDAC();
            return dac.ManagerCheck(emp);
        }

        public bool RegisterOrder(CustomerOrderVO order, List<CustomerOrderDetailProductConnectVO> details) //유저가 주문 할때
        {
            UserDAC dac = new UserDAC();
            return dac.RegisterOrder(order, details);
        }

        public string UserCode(UserInfoVO uvo) // 유저코드 가지고온다
        {
            UserDAC dac = new UserDAC();
            return dac.UserCode(uvo);
        }
    }
}
