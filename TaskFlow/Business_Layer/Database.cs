using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TaskFlow.Models;

namespace TaskFlow.Business_Layer
{
    public class Database
    {
        public static int GetUserId(User user)
        {
            int userId = 0;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DB_ConnectionString"].ConnectionString;
            using (SqlConnection DbConnection = new SqlConnection(dbConnectionString))
            {
                try
                {
                    DbConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Login", DbConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            userId = (int)result;
                        }
                    }
                }
                catch { }
                finally
                {
                    DbConnection.Close();
                }
            }
            return userId;
        }
    }
}