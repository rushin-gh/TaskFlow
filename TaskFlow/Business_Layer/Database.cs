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

        public static void GetUserTasks(User user)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DB_ConnectionString"].ConnectionString;
            using (SqlConnection DbConnection = new SqlConnection(dbConnectionString))
            {
                try
                {
                    DbConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GetUserTasks", DbConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", user.UserId);

                        using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                user.TaskList.Add(
                                    new Task()
                                    {
                                        TaskId = sqlDataReader.GetInt32(0),
                                        TaskDesc = sqlDataReader.GetString(1)
                                    }
                                );
                            }
                        }
                    }
                }
                catch { }
                finally
                {
                    DbConnection.Close();
                }
            }
            // return userId;
        }
    }
}