using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hoofdform
{
    public static class DatabaseCONN
    {
        public static SqlConnection conn = new SqlConnection();

        public static string ConnString = @"Server=mssql.fhict.local;Database=dbi392341;User Id=dbi392341;Password=Proftaak123;";

        /// <summary>
        /// kijkt of de connstring connected is
        /// </summary>
        /// <returns>boolean of de connectie goed is of niet</returns>
        public static Boolean getConnectieString()
        {
            try
            {
                conn.ConnectionString = ConnString;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
