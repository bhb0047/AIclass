﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0916_01_준비운동
{
    class ArrayTest
    {
        static void Main(string[] args)
        {
            //1. 이름을 입력받아서 출력해보세요.
            Console.Write("이름입력:");
            string strName = Console.ReadLine();
            Console.WriteLine("{0} 님 좋은 아침입니다.", strName);

            //2. 5명의 이름을 입력받고, 5명의 이름을 출력해보세요.
            string[] nameArr = new string[5];
            for (int i = 0; i < nameArr.Length; i++)
            {
                Console.Write("이름입력:");
                nameArr[i] = Console.ReadLine();
            }
            foreach (string name in nameArr)
            {
                Console.WriteLine("{0} 님 좋은 아침입니다.", name);
            }

            //3. 5명의 이름과 전화번호를 입력받아서 출력해보세요.
            string[,] personArr = new string[5, 2];
            for (int i = 0; i < personArr.GetLength(0); i++)
            {
                Console.Write("이름입력:");
                personArr[i, 0] = Console.ReadLine();
                Console.Write("전화번호입력:");
                personArr[i, 1] = Console.ReadLine();
            }
            for (int i = 0; i < personArr.GetLength(0); i++)
            {
                Console.WriteLine("{0}님의 전화번호는 {1} 입니다.",
                    personArr[i, 0], personArr[i, 1]);
            }

            //4. 5명의 이름, 전화번호, 생일을 입력받아서 출력해보세요.
            PhoneInfo[] pArr = new PhoneInfo[5];
            for (int i = 0; i < pArr.Length; i++)
            {
                Console.Write("이름입력:");
                string name = Console.ReadLine();
                Console.Write("전화번호입력:");
                string phone = Console.ReadLine();
                Console.Write("생일입력:");
                string birth = Console.ReadLine();

                pArr[i] = new PhoneInfo(name, phone, birth);
            }
            foreach (PhoneInfo person in pArr)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }

    public class PhoneInfo
    {
        string name;
        string phone;
        string birth;

        public PhoneInfo(string name, string phone, string birth)
        {
            this.name = name;
            this.phone = phone;
            this.birth = birth;
        }

        public override string ToString()
        {
            return string.Format("{0}님 - {1} / {2} 입니다.", this.name, this.phone, this.birth);
        }
    }
}