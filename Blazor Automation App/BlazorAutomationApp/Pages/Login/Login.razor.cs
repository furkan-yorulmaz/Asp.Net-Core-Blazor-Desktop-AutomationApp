using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAutomationApp.Pages.Login
{
    public class LoginBase : ComponentBase
    {
        protected UserResultObject Login(string username, string password)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            UserResultObject resultObject = new UserResultObject();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    password = EncryptText(password);
                    string SqlCommand = "SELECT * FROM [user] WHERE userName='"+username+"' AND userPassword='"+password+"'";
                    SqlCommand cmd = new SqlCommand(SqlCommand, cn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultObject.Username = reader["UserName"].ToString();
                            resultObject.Password = reader["UserPassword"].ToString();
                            resultObject.Userrole = reader["UserRole"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: "+ ex.Message);
            }
            return resultObject;
        }

        private const string cnSalt = "f123f";
        public static string EncryptText(string strText)
        {
            var salt = System.Text.Encoding.UTF8.GetBytes(cnSalt);
            var password = System.Text.Encoding.UTF8.GetBytes(strText);
            var hmacMD5 = new HMACMD5(salt);
            var saltedHash = hmacMD5.ComputeHash(password);


            StringBuilder sbEncrypt = new StringBuilder();
            foreach (byte ba in saltedHash)
            {
                sbEncrypt.Append(ba.ToString("x2").ToLower());
            }

            return sbEncrypt.ToString();
        }
    }
}
