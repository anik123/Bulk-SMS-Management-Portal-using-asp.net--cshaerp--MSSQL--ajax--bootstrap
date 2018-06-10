using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMSONBD.MODEL;
using ConnectionProvider;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using SMSONBD.MODEL.API;

namespace SMSONBD.BIZ
{
    public class fetch
    {

        public static List<SMSON_CONTACT> Get_ALL_SMSON_CONTACT(int USER_IDS)
        {

            List<SMSON_CONTACT> OBJlISTSMSON_CONTACT = new List<SMSON_CONTACT>();
            var conn = ConnectionClass.GetConnection();
            var objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_SMSON_CONTACT_GA";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = conn;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = USER_IDS;
            conn.Open();
            try
            {
                var data = objSqlCommand.ExecuteReader();
                while (data.Read())
                {
                    SMSON_CONTACT OBJSMSON_CONTACT = new SMSON_CONTACT();
                    OBJSMSON_CONTACT.CONTACT_ID = int.Parse(data["CONTACT_ID"].ToString());
                    OBJSMSON_CONTACT.CONTACT_NAME = data["CONTACT_NAME"].ToString();
                    OBJSMSON_CONTACT.CONTACT_NUMBER = data["CONTACT_NUMBER"].ToString();
                    OBJSMSON_CONTACT.GROUP_NAME = data["GROUP_NAME"].ToString();
                    OBJlISTSMSON_CONTACT.Add(OBJSMSON_CONTACT);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return OBJlISTSMSON_CONTACT;
        }



        public static List<SMSON_TRANSACTION> Get_ALL_SMSON_TRANSACTION(int USER_IDS)
        {

            List<SMSON_TRANSACTION> OBJlISTSMSON_TRANSACTION = new List<SMSON_TRANSACTION>();
            var conn = ConnectionClass.GetConnection();
            var objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_SMSON_CONTACT_GA";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = conn;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = USER_IDS;
            conn.Open();
            try
            {
                var data = objSqlCommand.ExecuteReader();
                while (data.Read())
                {
                    SMSON_TRANSACTION OBJSMSON_TRANSACTION = new SMSON_TRANSACTION();
                    OBJSMSON_TRANSACTION.TRANSACTION_ID = Convert.ToInt32(data["TRANSACTION_ID"].ToString());
                    OBJSMSON_TRANSACTION.TRANSACTION_NUMBER = Convert.ToInt32(data["TRANSACTION_NUMBER"].ToString());
                    OBJSMSON_TRANSACTION.PACKAGE_ID = Convert.ToInt32(data["PACKAGE_ID"].ToString());
                    OBJSMSON_TRANSACTION.TRANSACTION_TOTAL = Convert.ToInt32(data["TRANSACTION_TOTAL"].ToString());
                    OBJSMSON_TRANSACTION.TRANSACTION_DATE = Convert.ToInt32(data["TRANSACTION_DATE"].ToString());
                    OBJlISTSMSON_TRANSACTION.Add(OBJSMSON_TRANSACTION);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return OBJlISTSMSON_TRANSACTION;
        }
        public static List<SMSON_CONTACT> Get_All_Contact_By_User(int GroupId, string UserId)
        {
            var contactList = new List<SMSON_CONTACT>();

            var conn = ConnectionClass.GetConnection();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FSP_GROUP_GA";
            cmd.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            cmd.Parameters["@USER_IDS"].Value = UserId;
            cmd.Parameters.Add(new SqlParameter("@GROUP_ID", SqlDbType.Int));
            cmd.Parameters["@GROUP_ID"].Value = GroupId;
            conn.Open();
            try
            {
                using (cmd)
                {
                    var data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        var contact = new SMSON_CONTACT();
                        contact.GROUP_ID = int.Parse(data["GROUP_ID"].ToString());
                        // contact.GROUP_NAME = data["GROUP_NAME"].ToString();
                        contact.CONTACT_NUMBER = data["CONTACT_NUMBER"].ToString();
                        contact.SMS_CREDIT = int.Parse(data["BALANCE"].ToString());
                        contactList.Add(contact);
                    }
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return contactList;
        }
        public static List<SMSON_GROUP> Get_All_Group(string User_Ids)
        {
            var groupList = new List<SMSON_GROUP>();

            var conn = ConnectionClass.GetConnection();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FSP_GROUP_GK";
            cmd.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            cmd.Parameters["@USER_IDS"].Value = User_Ids;
            conn.Open();
            try
            {
                using (cmd)
                {
                    var data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        var group = new SMSON_GROUP();
                        group.GROUP_ID = int.Parse(data["GROUP_ID"].ToString());
                        group.GROUP_NAME = data["GROUP_NAME"].ToString();
                        group.USER_IDS = data["USER_IDS"].ToString();
                        groupList.Add(group);
                    }
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return groupList;
        }
        public static List<SMSON_CONTACT> getAllContactList(string GroupId, string UserId)
        {
            var contactList = new List<SMSON_CONTACT>();

            var conn = ConnectionClass.GetConnection();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FSP_GROUP_LIST";
            cmd.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            cmd.Parameters["@USER_IDS"].Value = UserId;
            cmd.Parameters.Add(new SqlParameter("@GROUP_ID", SqlDbType.VarChar, 50));
            cmd.Parameters["@GROUP_ID"].Value = GroupId;
            conn.Open();
            try
            {
                using (cmd)
                {
                    var data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        var contact = new SMSON_CONTACT();
                        contact.GROUP_ID = int.Parse(data["GROUP_ID"].ToString());
                        contact.CONTACT_NAME = data["CONTACT_NAME"].ToString();
                        contact.CONTACT_NUMBER = data["CONTACT_NUMBER"].ToString();
                        contact.GROUP_NAME = data["GROUP_NAME"].ToString();
                        contact.MAKE_DT = DateTime.Parse(data["MAKE_DT"].ToString());
                        contactList.Add(contact);
                    }
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return contactList;
        }

        public static List<SMSON_SEND_BOX> getAllSend(string UserId)
        {
            var sendList = new List<SMSON_SEND_BOX>();
            var conn = ConnectionClass.GetConnection();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FSP_SEND_BOX_GA";
            cmd.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            cmd.Parameters["@USER_IDS"].Value = UserId;
            conn.Open();
            try
            {
                var data = cmd.ExecuteReader();
                while (data.Read())
                {
                    var send = new SMSON_SEND_BOX();
                    send.MOBILE_NUMBER = data["MOBILE_NUMBER"].ToString();
                    send.MAKE_DT = DateTime.Parse(data["MAKE_DT"].ToString());
                    if (data["SMS_STATUS"].ToString().Equals("0"))
                        send.STATUS = "Pending";
                    if (data["SMS_STATUS"].ToString().Equals("1"))
                        send.STATUS = "Sent";
                    if (data["SMS_STATUS"].ToString().Equals("2"))
                        send.STATUS = "Not Sent";
                    if (String.IsNullOrEmpty(data["GROUP_NAME"].ToString()))
                        send.GROUP_NAME = "none";
                    else
                        send.GROUP_NAME = data["GROUP_NAME"].ToString();
                    sendList.Add(send);
                }
            }
            catch { }
            finally { conn.Close(); }
            return sendList;
        }
        public static SMSON_USER getUserProfile(string UserId)
        {

            var user = new SMSON_USER();
            var conn = ConnectionClass.GetConnection();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FSP_USER_PROFILE_GA";
            cmd.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            cmd.Parameters["@USER_IDS"].Value = UserId;
            conn.Open();
            try
            {
                var data = cmd.ExecuteReader();
                while (data.Read())
                {
                    user.USER_FULL_NAME = data["USER_FULL_NAME"].ToString();
                    user.ADDRESS = data["ADDRESS"].ToString();
                    user.EMAIL = data["EMAIL"].ToString();
                    // user.PHONE == data["PHONE"].ToString();
                    user.PHONE = data["PHONE"].ToString();
                    user.DISTRICT = data["DISTRICT"].ToString();
                    user.POST_CODE = data["POST_CODE"].ToString();

                    user.SPEND = data["SPEND"].ToString();
                    user.TOTAL_MESSAGE = data["TOTAL_MESSAGE"].ToString();
                    user.TOTAL_CONTACTS = data["TOTAL_CONTACTS"].ToString();
                    user.SMS_CREDIT = int.Parse(data["SMS_CREDIT"].ToString());
                }
            }
            catch { }
            finally { conn.Close(); }
            return user;
        }
        public static string PasswordEncrypt(string data)
        {

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                message.Append(hashData[i].ToString());
            }
            return Convert.ToBase64String(hashData);

        }
        public static string HashEncrypt(string data)
        {

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                message.Append(hashData[i].ToString());
            }
            return message.ToString();

        }
        public static string getCreditNo(string username, string password,string hashcode)
        {
            var credit = "";
            var conn = ConnectionClass.GetConnection();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SMS_GET_COUNT";
            cmd.Parameters.Add(new SqlParameter("@USERNAME", SqlDbType.VarChar, 50));
            cmd.Parameters["@USERNAME"].Value = username;
            cmd.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50));
            cmd.Parameters["@PASSWORD"].Value = password;
            cmd.Parameters.Add(new SqlParameter("@HASHCODE", SqlDbType.VarChar, 50));
            cmd.Parameters["@HASHCODE"].Value = hashcode;
            cmd.Parameters.Add(new SqlParameter("@RETURN", SqlDbType.VarChar, 50));
            cmd.Parameters["@RETURN"].Direction = ParameterDirection.Output;
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                credit = cmd.Parameters["@RETURN"].Value.ToString();
            }
            catch { }
            finally { conn.Close(); }
            return credit;
        }
        #region API Method

        public static USER getDetails(string username, string password)
        {
            var obj = new USER();
            var conn = ConnectionClass.GetConnection();
            var objSqlCommand = new SqlCommand();

            objSqlCommand.CommandText = "FSP_USER_LOGIN_GK";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = conn;
            objSqlCommand.Parameters.Add(new SqlParameter("@USER_IDS", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@USER_IDS"].Value = username;

            objSqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50));
            objSqlCommand.Parameters["@PASSWORD"].Value = password;
            conn.Open();
            try
            {
                var data = objSqlCommand.ExecuteReader();
                while (data.Read())
                {

                    obj.USER_IDS = data["USER_IDS"].ToString();
                    obj.USER_FULL_NAME = data["USER_FULL_NAME"].ToString();
                    obj.EMAIL = data["EMAIL"].ToString();
                    obj.PHONE = data["PHONE"].ToString();
                    obj.DISTRICT = data["DISTRICT"].ToString();
                    obj.POST_CODE = data["POST_CODE"].ToString();
                    obj.ADDRESS = data["ADDRESS"].ToString();
                    obj.SMS_CREDIT = int.Parse(data["SMS_CREDIT"].ToString());
                    obj.HashCode = data["HASHCODE"].ToString();
                    obj.PENDING = data["PENDING"].ToString();
                    obj.S_SEND = data["S_SEND"].ToString();
                    obj.TOTAL = data["TOTAL"].ToString();

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return obj;
        }


        #endregion

    }
}
