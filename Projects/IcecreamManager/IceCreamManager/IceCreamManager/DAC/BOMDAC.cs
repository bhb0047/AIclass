﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using IceCreamManager.VO;

namespace IceCreamManager.DAC
{
    public class BOMDAC : DACParent
    {
        public List<BOMVO> SelectBomAll()
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "GetAllBOM";
                comm.CommandType = CommandType.StoredProcedure;

                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<BOMVO> bomList = Helper.DataReaderMapToList<BOMVO>(reader);
                comm.Connection.Close();

                //TODO - 수정 : 프로시저 이름 입력 후 return bomlist
                //throw new NotImplementedException();
                return bomList;
            }
        }
        public List<MaterialsBOMConnectVO> GetAllBOMMaterialsByParentNo(int bomNo)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "GetAllBOMMaterialsByParentNo";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@mat_ParentNo", bomNo);

                comm.Connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<MaterialsBOMConnectVO> bomList = Helper.DataReaderMapToList<MaterialsBOMConnectVO>(reader);
                comm.Connection.Close();

                //TODO - 수정 : 프로시저 이름 입력 후 return bomlist
                //throw new NotImplementedException();
                return bomList;
            }
        }
        public bool Insert(List<BOMVO> item)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "InsertBOM";
                comm.CommandType = CommandType.StoredProcedure;
                
                comm.Connection.Open();
                SqlTransaction trans = comm.Connection.BeginTransaction();
                try
                {
                    comm.Transaction = trans;
                    foreach (var bom in item)
                    {
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@mat_ParentNo", bom.mat_ParentNo);
                        comm.Parameters.AddWithValue("@mat_ChildNo", bom.mat_ChildNo);
                        comm.Parameters.AddWithValue("@bom_ChildEach", bom.bom_ChildEach);
                        comm.Parameters.AddWithValue("@bom_ChildUnit", bom.bom_ChildUnit);

                        comm.ExecuteNonQuery();
                    }
                    trans.Commit();
                    comm.Connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    comm.Connection.Close();
                    return false;
                }
            }
        }
        public bool Update(BOMVO item)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "UpdateBOM";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@mat_ParentNo", item.mat_ParentNo);
                comm.Parameters.AddWithValue("@mat_ChildNo", item.mat_ChildNo);
                comm.Parameters.AddWithValue("@bom_ChildEach", item.bom_ChildEach);

                comm.Connection.Open();
                var rowsAffected = comm.ExecuteNonQuery();
                comm.Connection.Close();
                return rowsAffected > 0;
            }
        }
        public bool Delete(BOMVO item)
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "delete from bom where mat_ParentNo = @mat_ParentNo and mat_ChildNo = @mat_ChildNo";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@mat_ParentNo", item.mat_ParentNo);
                comm.Parameters.AddWithValue("@mat_ChildNo", item.mat_ChildNo);

                comm.Connection.Open();
                var rowsAffected = comm.ExecuteNonQuery();
                comm.Connection.Close();
                return rowsAffected > 0;
            }
        }

        public bool TreeDelete(int pNo)
        {
            using(SqlCommand comm = new SqlCommand())
            {
                comm.Connection = new SqlConnection(Connstr);
                comm.CommandText = "delete from BOM where mat_ParentNo = @mat_ParentNo";
                comm.Parameters.AddWithValue("@mat_ParentNo", pNo);

                comm.Connection.Open();
                var rowsAffected = comm.ExecuteNonQuery();
                comm.Connection.Close();
                return rowsAffected > 0;
            }
        }
    }
}