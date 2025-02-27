﻿using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace IceCreamManager.DAC
{
    public class UserDAC : DACParent
    {
        public bool UserSiginUp(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.Connstr);
                cmd.CommandText = "insert into Customer(cus_Id, cus_Password,cus_Name ,cus_Phone ,cus_Addr , cus_Email) values (@cus_Id, @cus_Password, @cus_Name, @cus_Phone, @cus_Addr, @cus_Email)";

                cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);
                cmd.Parameters.AddWithValue("@cus_Password", uvo.cus_Password);
                cmd.Parameters.AddWithValue("@cus_Name", uvo.cus_Name);
                cmd.Parameters.AddWithValue("@cus_Phone", uvo.cus_Phone);
                cmd.Parameters.AddWithValue("@cus_Addr", uvo.cus_Addr);
                cmd.Parameters.AddWithValue("@cus_Email", uvo.cus_Email);

                cmd.Connection.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return rowsAffected > 0;
            }
        }
        public bool PwdCheak(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.Connstr);
                cmd.CommandText = "select count(*) from Customer where cus_Id=@cus_Id AND cus_Password=@cus_Password ";

                cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);
                cmd.Parameters.AddWithValue("@cus_Password", uvo.cus_Password);

                cmd.Connection.Open();
                var rowsAffected = cmd.ExecuteScalar();
                cmd.Connection.Close();
                if ((int)rowsAffected == 1) //동일한 ID 가있다면
                {
                    return true;
                }
                else
                {
                    return false; //없다면
                }
            }
        }
        public bool UserIDCheck(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.Connstr);
                cmd.CommandText = "select count(*) from Customer where cus_Id=@cus_Id";

                cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);

                cmd.Connection.Open();
                var rowsAffected = cmd.ExecuteScalar();
                cmd.Connection.Close();
                if ((int)rowsAffected == 1) //동일한 ID 가있다면
                {
                    return false;
                }
                return true; //없다면
            }
        }
        public string UserCode(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = new SqlConnection(this.Connstr);
                    cmd.CommandText = "select cus_No from Customer where cus_Id =@cus_Id";

                    cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);

                    cmd.Connection.Open();
                    string result = Convert.ToString(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                    if (result == "")
                    {
                        return null;
                    }
                    else
                    {
                        return result;
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                    return null;
                }
            }
        }
        public string UserIDSearch(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = new SqlConnection(this.Connstr);
                    cmd.CommandText = "select cus_Id from Customer where cus_Email =@cus_Email  and cus_Name=@cus_Name and cus_Phone=@cus_Phone";

                    cmd.Parameters.AddWithValue("@cus_Name", uvo.cus_Name);
                    cmd.Parameters.AddWithValue("@cus_Phone", uvo.cus_Phone);
                    cmd.Parameters.AddWithValue("@cus_Email", uvo.cus_Email);

                    cmd.Connection.Open();
                    string result = Convert.ToString(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                    if (result == "")
                    {
                        return null;
                    }
                    else
                    {
                        return result;
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                    return null;
                }
            }
        }
        public string UserName(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = new SqlConnection(this.Connstr);
                    cmd.CommandText = "select cus_Name from Customer where cus_Id=@cus_Id AND cus_Password=@cus_Password";

                    cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);
                    cmd.Parameters.AddWithValue("@cus_Password", uvo.cus_Password);

                    cmd.Connection.Open();
                    string result = Convert.ToString(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                    if (result == "")
                    {
                        return null;
                    }
                    else
                    {
                        return result;
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                    return null;
                }
            }
        }
        public bool UserEmailCheck(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.Connstr);
                cmd.CommandText = "select count(*) from Customer where cus_Email =@cus_Email  and cus_Id=@cus_Id and cus_Phone=@cus_Phone";

                cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);
                cmd.Parameters.AddWithValue("@cus_Email", uvo.cus_Email);
                cmd.Parameters.AddWithValue("@cus_Phone", uvo.cus_Phone);

                cmd.Connection.Open();
                var rowsAffected = cmd.ExecuteScalar();
                cmd.Connection.Close();
                if ((int)rowsAffected == 1)
                {
                    return false;
                }
                return true;
            }
        }
        public int UserPWDUpdate(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = new SqlConnection(this.Connstr);
                    cmd.CommandText = "update Customer set cus_Password=@cus_Password where cus_Email =@cus_Email  and cus_Id=@cus_Id and cus_Phone=@cus_Phone";

                    cmd.Parameters.AddWithValue("@cus_Password", uvo.cus_Password);
                    cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);
                    cmd.Parameters.AddWithValue("@cus_Email", uvo.cus_Email);
                    cmd.Parameters.AddWithValue("@cus_Phone", uvo.cus_Phone);

                    cmd.Connection.Open();

                    int a = cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                    return a;

                }
                catch (Exception err)
                {
                    throw err;
                }

            }
        }
        public int PwdChange(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = new SqlConnection(this.Connstr);
                    cmd.CommandText = "update Customer set cus_Password=@cus_Password where cus_Id=@cus_Id";
                    cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);
                    cmd.Parameters.AddWithValue("@cus_Password", uvo.PasswordChange);

                    cmd.Connection.Open();
                    int a = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return a;
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }
        public bool? ManagerCheck(UserInfoVO uvo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.Connstr);
                cmd.CommandText = "select count(IsManager) from Customer where cus_Id=@cus_Id AND cus_Password=@cus_Password";

                cmd.Parameters.AddWithValue("@cus_Id", uvo.cus_ID);
                cmd.Parameters.AddWithValue("@cus_Password", uvo.cus_Password);

                cmd.Connection.Open();
                int manager = Convert.ToByte(cmd.ExecuteScalar());
                if (manager > 0)
                {
                    cmd.CommandText = "select IsManager from Customer where cus_Id=@cus_Id AND cus_Password=@cus_Password";
                    manager = Convert.ToByte(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                    if (manager == 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    cmd.Connection.Close();
                    return null;
                }
            }
        }
        public bool RegisterOrder(CustomerOrderVO order, List<CustomerOrderDetailProductConnectVO> details)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.Connstr);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = @"Insert into Customer_Order 
                                                (cus_No, cuo_Datetime, cuo_TotalPrice)
                                          Values 
                                             (@cus_No, @cuo_Datetime, @cuo_TotalPrice); Select @@IDENTITY";

                    cmd.Parameters.AddWithValue("@cus_No", order.cus_No);
                    cmd.Parameters.AddWithValue("@cuo_Datetime", order.cuo_Datetime);
                    cmd.Parameters.AddWithValue("@cuo_TotalPrice", order.cuo_TotalPrice);


                    int newcuo_No = Convert.ToInt32(cmd.ExecuteScalar()); //주문코드

                    foreach (CustomerOrderDetailProductConnectVO item in details)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "CustomerOrderDetail";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@cuo_No", newcuo_No);
                        cmd.Parameters.AddWithValue("@pro_No", item.pro_No);
                        cmd.Parameters.AddWithValue("@cod_Each", item.cod_Each);
                        cmd.Parameters.AddWithValue("@cod_Size", item.cod_Size);

                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    cmd.Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    tran.Rollback();
                    cmd.Connection.Close();
                    return false;
                }
            }
        }
    }
}
