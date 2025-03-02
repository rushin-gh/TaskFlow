using System.Configuration;

namespace Config
{
    public class Database
    {
        public static string ConnectionString 
            => ConfigurationManager.ConnectionStrings["DB_ConnectionString"].ConnectionString;
    }
}
