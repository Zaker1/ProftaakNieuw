using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoofdform
{
    public class Coupe
    {
        public Coupe()
        {

        }

        public void Toevoegen(/*int stoelen, bool dubbeldekker, int klasseLinks, int klasseRechts*/ /*+ img*/)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Properties.Settings.Default.connection;
            connection.Open();

            string sql = "INSERT INTO Coupe(aantal_stoelen,is_dubbeldekker,klasse_links,klasse_rechts,id) VALUES(@param1,@param2,@param3,@param4,@param5)";

            SqlCommand command = new SqlCommand(sql, connection);
            
            command.Parameters.Add("@param1", SqlDbType.Int).Value = 69;
            command.Parameters.Add("@param2", SqlDbType.TinyInt).Value = 1;
            command.Parameters.Add("@param3", SqlDbType.VarChar).Value = "test";
            command.Parameters.Add("@param4", SqlDbType.VarChar).Value = "test";
            command.Parameters.Add("@param5", SqlDbType.Int).Value = 1;
            // command.Parameters.AddWithValue("@param6", null);

            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Query uitgevoerd");
            
        }
    }
}
