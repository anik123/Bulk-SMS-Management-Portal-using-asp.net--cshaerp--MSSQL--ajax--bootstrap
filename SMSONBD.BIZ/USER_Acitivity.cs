using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMSONBD.MODEL;
using ConnectionProvider;
using System.Data.SqlClient;
using System.Data;

namespace SMSONBD.BIZ
{
    public class USER_Acitivity
    {
        // SMSON_USER UserBiz=new SMSON_USER();
        static SMSON_USER UserSingle = new SMSON_USER();

        public static List<SMSON_USER> Check_Login(SMSON_USER objSMSON_USER)
        {

            var UserList = new List<SMSON_USER>();


            var conn = ConnectionClass.GetConnection();
            var objSqlCommand = new SqlCommand();

            objSqlCommand.CommandText = "FSP_USER_LOGIN_GK";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = conn;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = objSMSON_USER.USER_IDS;

            objSqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@PASSWORD"].Value = objSMSON_USER.PASSWORD;
            conn.Open();
            try
            {
                var data = objSqlCommand.ExecuteReader();
                while (data.Read())
                {
                    UserSingle.USER_IDS = data["USER_IDS"].ToString();
                    UserSingle.USER_FULL_NAME = data["USER_FULL_NAME"].ToString();
                    
                    UserList.Add(UserSingle);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return UserList;
        }
        public static string Send_SMS(SMSON_SEND_BOX objSMSON_SEND_BOX)
        {
            string message = "";

            var SMS = new SMSON_SEND_BOX();
            var conn = ConnectionClass.GetConnection();
            var objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_SEND_SMS_I";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = conn;
            objSqlCommand.Parameters.Add(new SqlParameter("@MOBILE_NUMBER", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@MOBILE_NUMBER"].Value = objSMSON_SEND_BOX.MOBILE_NUMBER;

            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = objSMSON_SEND_BOX.USER_IDS;

            objSqlCommand.Parameters.Add(new SqlParameter("@SMS_TEXT", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@SMS_TEXT"].Value = objSMSON_SEND_BOX.SMS_TEXT;

            objSqlCommand.Parameters.Add(new SqlParameter("@SMS_STATUS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@SMS_STATUS"].Value = objSMSON_SEND_BOX.SMS_STATUS;

            objSqlCommand.Parameters.Add(new SqlParameter("@GROUP_ID", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@GROUP_ID"].Value = "";

            objSqlCommand.Parameters.Add(new SqlParameter("@ERROR", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            conn.Open();

            try
            {
                var count = objSqlCommand.ExecuteNonQuery();
                message = objSqlCommand.Parameters["@ERROR"].Value.ToString();
            }
            catch//(Exception ex) 
            { }
            finally
            {
                conn.Close();
            }

            return message;
        }
    }
}
