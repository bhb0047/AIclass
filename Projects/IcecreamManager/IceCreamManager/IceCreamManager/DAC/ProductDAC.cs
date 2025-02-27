﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using IceCreamManager.VO;

namespace IceCreamManager.DAC
{
    public class ProductDAC : DACParent
    {
        public List<ProductVO> SelectAll()
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "GetAllProduct";
                comm.CommandType = CommandType.StoredProcedure;

                comm.Connection.Open();
                SqlDataReader read = comm.ExecuteReader();
                List<ProductVO> list = Helper.DataReaderMapToList<ProductVO>(read);

                return list;
            }
        }
        public List<ProductMaterialConnectVO> SelectAllProductMaterialConnect()
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "GetAllProductMaterialConnect";
                comm.CommandType = CommandType.StoredProcedure;

                comm.Connection.Open();
                SqlDataReader read = comm.ExecuteReader();
                List<ProductMaterialConnectVO> list = Helper.DataReaderMapToList<ProductMaterialConnectVO>(read);
                return list;
            }
        }

        public bool delete(List<int> idlist)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in idlist)
            {
                sb.Append(item + "@");
            }
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "ProductsDelete";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ProductNos", sb.ToString().Trim('@'));
                comm.Parameters.AddWithValue("@sep", "@");

                comm.Connection.Open();
                var rowsAffected = comm.ExecuteNonQuery();
                comm.Connection.Close();

                return rowsAffected == idlist.Count;
            }
        }
        public bool delete(int proid)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "delete from product where pro_No = @pro_No ";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@pro_No", proid);

                comm.Connection.Open();
                var rowsAffected = comm.ExecuteNonQuery();
                comm.Connection.Close();
                return rowsAffected > 0;
            }
        }
        public bool Insert(ProductVO productVO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(Connstr);
                cmd.CommandText = "INSERT INTO Product ( pro_Name, mat_No, pro_Price, pro_Img ) VALUES ( @pro_Name, @mat_No, @pro_Price, @pro_Img)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@pro_Name", productVO.pro_Name);
                cmd.Parameters.AddWithValue("@mat_No", productVO.mat_No);
                cmd.Parameters.AddWithValue("@pro_Price", productVO.pro_Price);
                cmd.Parameters.AddWithValue("@pro_Img", productVO.pro_Img);

                cmd.Connection.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return rowsAffected > 0;
            }
        } 
        public bool IsExist(int matNo)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "SELECT count(pro_No) FROM Product WHERE mat_No = @mat_No";
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@mat_No", matNo);

                comm.Connection.Open();
                int read = Convert.ToInt32(comm.ExecuteScalar());
                comm.Connection.Close();

                return read > 0;
            }
        } // 제품에 자재를 이미 등록했는지?
        public bool IsValid(int proNo)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "SELECT count(pro_No) FROM Product WHERE pro_No = @pro_No";
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@pro_No", proNo);

                comm.Connection.Open();
                int read = Convert.ToInt32(comm.ExecuteScalar());
                comm.Connection.Close();

                return read > 0;
            }
        } // 제품 코드가 존재하는지?
        public bool IsValid(List<int> idlist) // 해당 제품 코드들이 정확한지?
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in idlist)
            {
                sb.Append(item + "@");
            }
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "IsProductNosValid";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ProductNos", sb.ToString().Trim('@'));
                comm.Parameters.AddWithValue("@sep", "@");

                comm.Connection.Open();
                int read = Convert.ToInt32(comm.ExecuteScalar());
                comm.Connection.Close();

                return read == idlist.Count;
            }
        }
    }
}