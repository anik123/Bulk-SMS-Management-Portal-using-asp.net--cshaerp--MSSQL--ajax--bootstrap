using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectionProvider;
using System.Data.SqlClient;
using System.Data;
using SMSONBD.MODEL;
using SMSONBD.MODEL.API;

namespace SMSONBD.BIZ
{
    public class save
    {
        public static string SaveSMSON_USER(SMSON_USER objSMSON_USER)
        {
            var message = "";
            SqlConnection con = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_USER_REGISTRATION_I";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = con;

            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = objSMSON_USER.USER_IDS;
            objSqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@PASSWORD"].Value = objSMSON_USER.PASSWORD;
            objSqlCommand.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@EMAIL"].Value = objSMSON_USER.EMAIL;

            objSqlCommand.Parameters.Add(new SqlParameter("@HASHCODE", SqlDbType.VarChar, 500));
            objSqlCommand.Parameters["@HASHCODE"].Value = objSMSON_USER.HashCode;

            objSqlCommand.Parameters.Add(new SqlParameter("@ERROR", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            con.Open();
            try
            {
                int i = objSqlCommand.ExecuteNonQuery();
                message = objSqlCommand.Parameters["@ERROR"].Value.ToString();
            }
            catch//(Exception ex) 
            { }
            finally
            {
                con.Close();
            }
            return message;
        }


        public static string SaveSMSON_USERUpdate(SMSON_USER objSMSON_USER)
        {
            int i = 0; string Message = "";
            SqlConnection con = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_PROFILE_U";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = con;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_FULL_NAME", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_FULL_NAME"].Value = objSMSON_USER.USER_FULL_NAME;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = objSMSON_USER.USER_IDS;
            objSqlCommand.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@EMAIL"].Value = objSMSON_USER.EMAIL;
            objSqlCommand.Parameters.Add(new SqlParameter("@PHONE", SqlDbType.Int));
            objSqlCommand.Parameters["@PHONE"].Value = objSMSON_USER.PHONE;
            objSqlCommand.Parameters.Add(new SqlParameter("@DISTRICT", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@DISTRICT"].Value = objSMSON_USER.DISTRICT;
            objSqlCommand.Parameters.Add(new SqlParameter("@POST_CODE", SqlDbType.Int));
            objSqlCommand.Parameters["@POST_CODE"].Value = objSMSON_USER.POST_CODE;
            objSqlCommand.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@ADDRESS"].Value = objSMSON_USER.ADDRESS;

            objSqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@PASSWORD"].Value = objSMSON_USER.PASSWORD;

            objSqlCommand.Parameters.Add(new SqlParameter("@ERROR", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            con.Open();
            try
            {
                var data = objSqlCommand.ExecuteNonQuery();

                Message = objSqlCommand.Parameters["@ERROR"].Value.ToString();
            }
            catch//(Exception ex) 
            { }
            finally
            {
                con.Close();
            }
            return Message;
        }

        public static string SaveSMSON_USERPassUpdate(string old, string newp, string id)
        {
            string Message = "";
            SqlConnection con = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_USER_PASSWORD_U";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = con;
            objSqlCommand.Parameters.Add(new SqlParameter("@OLD", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@OLD"].Value = old;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = id;


            objSqlCommand.Parameters.Add(new SqlParameter("@NEW", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@NEW"].Value = newp;

            objSqlCommand.Parameters.Add(new SqlParameter("@ERROR", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            con.Open();
            try
            {
                var data = objSqlCommand.ExecuteNonQuery();

                Message = objSqlCommand.Parameters["@ERROR"].Value.ToString();
            }
            catch//(Exception ex) 
            { }
            finally
            {
                con.Close();
            }
            return Message;
        }




        public static string SaveSMSON_GROUP(SMSON_GROUP objSMSON_GROUP)
        {
            string Message = "";
            SqlConnection con = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_ADD_GROUP_I";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = con;
            // objSqlCommand.Parameters.Add(new SqlParameter("@GROUP_ID", SqlDbType.Int));
            // objSqlCommand.Parameters["@GROUP_ID"].Value = objSMSON_GROUP.GROUP_ID;
            objSqlCommand.Parameters.Add(new SqlParameter("@GROUP_NAME", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@GROUP_NAME"].Value = objSMSON_GROUP.GROUP_NAME;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = objSMSON_GROUP.USER_IDS;
            objSqlCommand.Parameters.Add(new SqlParameter("@ERROR", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            con.Open();
            try
            {
                var data = objSqlCommand.ExecuteNonQuery();
                Message = objSqlCommand.Parameters["@ERROR"].Value.ToString();
            }
            catch//(Exception ex) 
            { }
            finally
            {
                con.Close();
            }
            return Message;
        }


        public static string SaveSMSON_CONTACT(SMSON_CONTACT objSMSON_CONTACT)
        {
            string message = "";
            SqlConnection con = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_ADD_CONTACT_I";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = con;
            // objSqlCommand.Parameters.Add(new SqlParameter("@GROUP_ID", SqlDbType.Int));
            // objSqlCommand.Parameters["@GROUP_ID"].Value = objSMSON_GROUP.GROUP_ID;
            objSqlCommand.Parameters.Add(new SqlParameter("@CONTACT_NAME", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@CONTACT_NAME"].Value = objSMSON_CONTACT.CONTACT_NAME;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar));
            objSqlCommand.Parameters["@USER_IDS"].Value = objSMSON_CONTACT.USER_IDS;
            objSqlCommand.Parameters.Add(new SqlParameter("@GROUP_ID", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@GROUP_ID"].Value = objSMSON_CONTACT.GROUP_ID;
            objSqlCommand.Parameters.Add(new SqlParameter("@CONTACT_NUMBER", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@CONTACT_NUMBER"].Value = objSMSON_CONTACT.CONTACT_NUMBER;
            objSqlCommand.Parameters.Add(new SqlParameter("@ERROR", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            con.Open();
            try
            {
                var data = objSqlCommand.ExecuteNonQuery();
                message = objSqlCommand.Parameters["@ERROR"].Value.ToString();
            }
            catch//(Exception ex) 
            { }
            finally
            {
                con.Close();
            }
            return message;
        }

        #region API Method

        public static string Send_API_SMS(SEND_SMS sms)
        {
            string message = "";
            SqlConnection con = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_SEND_SMS_API";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = con;
            // objSqlCommand.Parameters.Add(new SqlParameter("@GROUP_ID", SqlDbType.Int));
            // objSqlCommand.Parameters["@GROUP_ID"].Value = objSMSON_GROUP.GROUP_ID;
            objSqlCommand.Parameters.Add(new SqlParameter("@HASCODE", SqlDbType.VarChar, 100));
            objSqlCommand.Parameters["@HASCODE"].Value = sms.HASHCODE;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = sms.USER_IDS;
            objSqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@PASSWORD"].Value = sms.PASSWORD;
            objSqlCommand.Parameters.Add(new SqlParameter("@NUMBER", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@NUMBER"].Value = sms.NUMBER;
            objSqlCommand.Parameters.Add(new SqlParameter("@MESSAGE", SqlDbType.NVarChar, 4000));
            objSqlCommand.Parameters["@MESSAGE"].Value = sms.MESSAGE;
            objSqlCommand.Parameters.Add(new SqlParameter("@ERROR", SqlDbType.VarChar, 4000));
            objSqlCommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            con.Open();

            var data = objSqlCommand.ExecuteNonQuery();
            message = objSqlCommand.Parameters["@ERROR"].Value.ToString();


            con.Close();

            return message;
        }
        #endregion
    }
}
