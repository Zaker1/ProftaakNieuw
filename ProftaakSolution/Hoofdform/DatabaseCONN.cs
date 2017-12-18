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
        public static SqlConnection CONN = new SqlConnection();

        public static string CONNSTRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Zaker\Source\Repos\ProftaakNieuw\ProftaakSolution\Hoofdform\DatabaseUSF.mdf';Integrated Security=True";
        

        /// <summary>
        /// kijkt of de connstring connectie is
        /// </summary>
        /// <returns>boolean of de connectie goed is of niet</returns>
        public static Boolean getConnectieString()
        {
            try
            {
                CONN.ConnectionString = CONNSTRING;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
