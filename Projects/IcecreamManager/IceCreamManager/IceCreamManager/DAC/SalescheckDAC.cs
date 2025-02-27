﻿using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManager.DAC
{
    public class SalescheckDAC : DACParent
    {

        /// <summary>
        /// 제품전체,  회원별 ,제품별
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<SalescheckMVO> SelectAllM(string start, string end, int check)
        {
            string sql = "";
            switch (check)
            {
                case 1:
                    sql = $"select p.pro_No,pro_Name,o.cod_Each,(pro_Price*cod_Each) pro_Price,cuo_Datetime " +
                        $" from Product p inner join Customer_Order_Detail o on p.pro_No = o.pro_No" +
                        $" inner join Customer_Order co on o.cuo_No = co.cuo_No" +
                        $" where cuo_Datetime between '{start}' and '{end}'";

                    break;

                case 2:
                    sql = $"select isnull(p.pro_No, 0) pro_No" +
                        $", case when pro_Name is null and p.pro_No is null then '총합'" +
                        $" when pro_Name is null then '소계'" +
                        $" else pro_Name end pro_Name,sum(cod_Each) cod_Each,sum(pro_Price*cod_Each) pro_Price,cuo_Datetime " +
                        $" from Product p inner join Customer_Order_Detail o on p.pro_No = o.pro_No" +
                        $" inner join Customer_Order co on o.cuo_No=co.cuo_No" +
                        $" where cuo_Datetime between '{start}' and '{end}'  group by p.pro_No,pro_Name,cuo_Datetime  with rollup;";

                    break;
                default:
                    break;
            }

            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = sql;
                comm.CommandType = CommandType.Text;
                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<SalescheckMVO> list = Helper.DataReaderMapToList<SalescheckMVO>(reader);
                comm.Connection.Close();

                return list;
            }

        }

        public List<SalescheckCVO> SelectAllC(string start, string end)
        {

            string sql = $"select cu.cus_No,cu.cus_Name, p.pro_No,pro_Name,cod_Each,pro_Price,cuo_Datetime " +
                 $"from Product p inner join Customer_Order_Detail o on p.pro_No = o.pro_No inner join Customer_Order" +
                 $" co on o.cuo_No=co.cuo_No inner join Customer cu  on cu.cus_No = co.cus_No" +
                 $" where cuo_Datetime between '{start}' and '{end}'";


            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = sql;
                comm.CommandType = CommandType.Text;
                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<SalescheckCVO> list = Helper.DataReaderMapToList<SalescheckCVO>(reader);
                comm.Connection.Close();

                return list;
            }
        }


        public List<UserVO> SelectUser()
        {
            string sql = "select cus_No,cus_Name from Customer where IsManager !=1" ;


            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = sql;
                comm.CommandType = CommandType.Text;
                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(reader);
                comm.Connection.Close();

                return list;
            }
        }

    }

    ///// <summary>
    ///// 제품전체,  회원별 ,제품별
    ///// </summary>
    ///// <param name="start"></param>
    ///// <param name="end"></param>
    ///// <returns></returns>
    //public List<T> SelectAllM<T>(string start, string end, int check)
    //{
    //    string sql = "";
    //    switch (check)
    //    {
    //        case 1:
    //            sql = $"select p.pro_No,pro_Name,o.cod_Each,pro_Price " +
    //                $"from Product p inner join Customer_Order_Detail o on p.pro_No = o.pro_No" +
    //                $" inner join Customer_Order co on o.cuo_No = co.cuo_No" +
    //                $" where cuo_Datetime between '{start}' and '{end}'";

    //            List<SalescheckMVO> list = new List<SalescheckMVO>();

    //            return list;

    //        case 2:
    //            sql = $"select cu.cus_No,cu.cus_Name, p.pro_No,pro_Name,cod_Each,pro_Price " +
    //                $"from Product p inner join Customer_Order_Detail o on p.pro_No = o.pro_No inner join Customer_Order" +
    //                $" co on o.cuo_No=co.cuo_No inner join Customer cu  on cu.cus_No = co.cus_No" +
    //                $" where cuo_Datetime between '{start}' and '{end}'";
    //            return sqlstart<SalescheckMVO>(sql);

    //        case 3:
    //            sql = $"select isnull(p.pro_No, 0) pro_No" +
    //                $", case when pro_Name is null and p.pro_No is null then '총합'" +
    //                $" when pro_Name is null then '소계'" +
    //                $" else pro_Name end pro_Name,sum(cod_Each) cod_Each,sum(pro_Price) pro_Price" +
    //                $" from Product p inner join Customer_Order_Detail o on p.pro_No = o.pro_No" +
    //                $" inner join Customer_Order co on o.cuo_No=co.cuo_No" +
    //                $" where cuo_Datetime between '{start}' and '{end}'  group by p.pro_No,pro_Name  with rollup;";
    //            return sqlstart<SalescheckCVO>(sql);

    //        default:
    //            return null;
    //    }

    //}


    //private List<T> sqlstart<T>(string sql) where T: class
    //{
    //    using (SqlCommand comm = new SqlCommand())
    //    {
    //        comm.Connection = new SqlConnection(Connstr);
    //        comm.CommandText = sql;
    //        comm.CommandType = CommandType.Text;
    //        comm.Connection.Open();
    //        SqlDataReader reader = comm.ExecuteReader();
    //        List<T> list = Helper.DataReaderMapToList<T>(reader);
    //        comm.Connection.Close();

    //        return list;
    //    }
    //}

}
