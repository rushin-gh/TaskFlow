using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Model;

namespace Business_Layer
{
    public static class Database
    {
        public static string DBConnectionString = Config.Database.ConnectionString;

        public static int GetUserId(User user)
        {
            int userId = 0;
            using (SqlConnection DbConnection = new SqlConnection(DBConnectionString))
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
                            userId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // To Do : Log exception here
                }
                finally
                {
                    DbConnection.Close();
                }
            }
            return userId;
        }

        public static void GetUserTasks(User user)
        {
            using (SqlConnection DbConnection = new SqlConnection(DBConnectionString))
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
                catch (Exception ex)
                {
                    // To Do : Log exception here
                }
                finally
                {
                    DbConnection.Close();
                }
            }
        }
    }
}