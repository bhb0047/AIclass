﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook5
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBookManager manager = PhoneBookManager.createManagerInstance();
            int choice;

            while (true)
            {
                try
                {
                    while (true)
                    {
                        manager.showMenu();
                        if (int.TryParse(Console.ReadLine(), out choice))
                            break;
                    }

                    if (choice < 1 || choice > 6)
                        throw new MenuChoiceException(choice);

                    switch (choice)
                    {
                        case 1:
                            manager.inputData();
                            break;
                        case 2:
                            manager.listData();
                            break;
                        case 3:
                            manager.searchData();
                            break;
                        case 4:
                            manager.sortData();
                            break;
                        case 5:
                            manager.deleteData();
                            break;
                        case 6:
                            Console.WriteLine("프로그램을 종료합니다.");
                            System.Environment.Exit(0);
                            break;
                    }
                }
                catch (MenuChoiceException err)
                {
                    err.showWrongChoice();
                    Console.WriteLine("메뉴 선택을 처음부터 다시 진행합니다.\n");
                }
            }
        }
    }
}
