using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using SMSONBD.BIZ;
using SMSONBD.MODEL;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using SMSONBD.MODEL.API;
using ConnectionProvider;
using System.Data.SqlClient;
using System.Text;
namespace SMS.UI.API
{
    /// <summary>
    /// Summary description for SMSAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class SMSAPI : System.Web.Services.WebService
    {
        private System.Windows.Forms.Label label1;


        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        [WebMethod]
        public void login(string username, string password)
        {
            var msg = new STATUS();
            USER Info = new USER();
            if (string.IsNullOrEmpty(username))
            {
                msg.MESSAGE = "User is required";
                goto Error;
            }
            if (String.IsNullOrEmpty(password))
            {
                msg.MESSAGE = "Password is required";
                goto Error;
            }
            if (username.Length > 50)
            {
                msg.MESSAGE = "Username must be less than or equal 50 character";
                goto Error;
            }
            if (password.Length > 50)
            {
                msg.MESSAGE = "Password must be less than or equal 50 character";
                goto Error;
            }
            if (username.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of Username";
                goto Error;
            }
            if (password.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of Password";
                goto Error;
            }

            Info = fetch.getDetails(username, fetch.PasswordEncrypt(password));
            if (String.IsNullOrEmpty(Info.HashCode))
            {
                msg.MESSAGE = "Wrong Id And Password";
                goto Error;
            }
            else
                goto Success;

        Error:
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(msg);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(strJSON);
            return;
        Success:
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            string strJSON1 = js1.Serialize(Info);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(strJSON1);
        }
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        [WebMethod]
        public void sendsms(string hashcode, string username, string password, string receiver, string message)
        {
            var msg = new STATUS();
            string send = "";
            var obj = new SEND_SMS();
            decimal i = 0;
            if (String.IsNullOrEmpty(hashcode))
            {
                msg.MESSAGE = "Hash is required";
                goto Error;
            }
            if (hashcode.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of hashcode";
                goto Error;
            }
            if (string.IsNullOrEmpty(username))
            {
                msg.MESSAGE = "User is required";
                goto Error;
            }
            if (String.IsNullOrEmpty(password))
            {
                msg.MESSAGE = "Password is required";
                goto Error;
            }
            if (String.IsNullOrEmpty(receiver))
            {
                msg.MESSAGE = "phone number is required";
                goto Error;
            }
            if (username.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of phone number";
                goto Error;
            }
            if (username.Length > 50)
            {
                msg.MESSAGE = "Username must be less than or equal 50 character";
                goto Error;
            }
            if (password.Length > 50)
            {
                msg.MESSAGE = "Password must be less than or equal 50 character";
                goto Error;
            }
            if (receiver.Length > 50)
            {
                msg.MESSAGE = "Phone number must be less than or equal 50 character";
                goto Error;
            }
            if (username.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of Username";
                goto Error;
            }
            if (password.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of Password";
                goto Error;
            }
            if (string.IsNullOrEmpty(message))
            {
                msg.MESSAGE = "Message is required";
                goto Error;
            }
            if (message.Length > 5000)
            {
                msg.MESSAGE = "Password must be less than or equal 5000 character";
                goto Error;
            }
            obj.USER_IDS = username;
            obj.HASHCODE = hashcode;
            obj.PASSWORD = fetch.PasswordEncrypt(password);
            obj.NUMBER = receiver;
            obj.MESSAGE = message;

            msg.MESSAGE = save.Send_API_SMS(obj);


        Error:
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(msg);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(strJSON);
            return;

        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        [WebMethod]
        public void sendsmsmulti(string hashcode, string username, string password, string receiver, string message)
        {
            var msg = new STATUS();
            string send = "";
            var obj = new SEND_SMS();
            decimal i = 0;
            if (String.IsNullOrEmpty(hashcode))
            {
                msg.MESSAGE = "Hash is required";
                goto Error;
            }
            if (hashcode.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of hashcode";
                goto Error;
            }
            if (string.IsNullOrEmpty(username))
            {
                msg.MESSAGE = "User is required";
                goto Error;
            }
            if (String.IsNullOrEmpty(password))
            {
                msg.MESSAGE = "Password is required";
                goto Error;
            }
            if (String.IsNullOrEmpty(receiver))
            {
                msg.MESSAGE = "phone number is required";
                goto Error;
            }
            if (!IsValid(receiver))
            {
                msg.MESSAGE = "phone number is required";
                goto Error;
            }
            if (username.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of phone number";
                goto Error;
            }
            if (username.Length > 50)
            {
                msg.MESSAGE = "Username must be less than or equal 50 character";
                goto Error;
            }
            if (password.Length > 50)
            {
                msg.MESSAGE = "Password must be less than or equal 50 character";
                goto Error;
            }
            if (receiver.Length > 50)
            {
                msg.MESSAGE = "Phone number must be less than or equal 50 character";
                goto Error;
            }
            if (username.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of Username";
                goto Error;
            }
            if (password.Contains(" "))
            {
                msg.MESSAGE = "Invalid Format of Password";
                goto Error;
            }
            if (string.IsNullOrEmpty(message))
            {
                msg.MESSAGE = "Message is required";
                goto Error;
            }
            if (message.Length > 5000)
            {
                msg.MESSAGE = "Password must be less than or equal 5000 character";
                goto Error;
            }

            var counter = fetch.getCreditNo(username, fetch.PasswordEncrypt(password), hashcode);
            if (counter.Contains("User"))
            {
                msg.MESSAGE = counter;
                goto Error;
            }
            else
            {
                char[] a = new char[] { ',' };
                string[] numbers = receiver.Split(a);

                int count = numbers.Count() * (int)(Math.Ceiling(message.Length / 150.0));
                if (count > int.Parse(counter))
                {
                    msg.MESSAGE = "Not Enough Balance";
                    goto Error;
                }
                var conn = ConnectionClass.GetConnection();
                var cmd = new SqlCommand();
                SqlTransaction trans = null;
                StringBuilder sb = new StringBuilder();
                foreach (var item in numbers)
                {
                    sb.Append("EXEC FSP_SEND_SMS_I '" + item + "','" + username + "','" + message + "','0','','' ; ");
                }
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    var data = cmd.ExecuteNonQuery();
                    if (data > 0)
                    {
                        msg.MESSAGE = "Successfully Send!";
                        trans.Commit();
                        goto Error;

                    }
                    else
                    {
                        msg.MESSAGE = "Not Succesfull!";
                        trans.Rollback();
                        goto Error;
                    }

                }
                catch
                {
                    trans.Rollback();
                }
                finally
                {

                }


            }
        Error:
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(msg);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Flush();
            Context.Response.Write(strJSON);
            return;

        }
        private bool IsValid(string message)
        {
            string allowableLetters = "0123456789,-+";
            foreach (char c in message)
            {
                if (!allowableLetters.Contains(c.ToString()))
                    return false;
            }
            return true;

        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";

        }
    }
}
