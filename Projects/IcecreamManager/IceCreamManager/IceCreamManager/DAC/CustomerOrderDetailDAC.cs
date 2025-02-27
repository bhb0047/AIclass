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
    class CustomerOrderDetailDAC : DACParent
    {
        public List<CustomerOrderDetailVO> SelectAll()
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "SELECT [cod_No], [cuo_No], [pro_No], [cod_Each] FROM [dbo].[CostomerOrderDetail] ";
                comm.CommandType = CommandType.Text;

                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<CustomerOrderDetailVO> bomList = Helper.DataReaderMapToList<CustomerOrderDetailVO>(reader);
                comm.Connection.Close();

                return bomList;
            }
        }
        public List<CustomerOrderDetailVO> SelectAll(int cuoNo)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "SELECT [cod_No], [cuo_No], [pro_No], [cod_Each] FROM [dbo].[Customer_Order_Detail] WHERE cuo_No = @cuo_No ";
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@cuo_No", cuoNo);

                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<CustomerOrderDetailVO> bomList = Helper.DataReaderMapToList<CustomerOrderDetailVO>(reader);
                comm.Connection.Close();

                return bomList;
            }
        }
        public List<CustomerOrderDetailProductConnectAllVO> SelectAllJoinProductName(int cuoNo)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "SELECT [cod_No], [cuo_No], p.[pro_No], [cod_Each] ,[pro_Name] ,[mat_No] ,[pro_Price], [cod_Size] FROM [dbo].[Customer_Order_Detail] cod LEFT OUTER JOIN [dbo].[Product] p ON p.[pro_No] = cod.[pro_No] WHERE cuo_No = @cuo_No; ";
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@cuo_No", cuoNo);

                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<CustomerOrderDetailProductConnectAllVO> bomList = Helper.DataReaderMapToList<CustomerOrderDetailProductConnectAllVO>(reader);
                comm.Connection.Close();

                return bomList;
            }
        }
    }
}
