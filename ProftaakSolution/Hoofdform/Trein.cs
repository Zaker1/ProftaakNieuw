using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hoofdform
{
    public class Trein
    {
        List<int> listCoupe;
        Locomotief locomotief;
        static string ConnectionString = @"Server=mssql.fhict.local;Database=dbi392341;User Id = dbi392341; Password=Proftaak123;";

        string speciaal;
        string klasseR;
        string klasseL;
        string stoelenInCoupe;
        

        public Trein()
        {

        }

        public void TreinOntvangen(List<int> list, Locomotief loco)
        {
            locomotief = loco;
            listCoupe = list;
        }

        public void CoupeOphalen()
        {
            string query = "SELECT * FROM dbo.Coupe WHERE id = @ID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue(@"ID", listCoupe.First());

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    speciaal = reader["speciaal"].ToString();
                    klasseR = reader["klasse_rechts"].ToString();
                    klasseL = reader["klasse_links"].ToString();
                    stoelenInCoupe = reader["aantal_stoelen"].ToString();
                }
            }
        }
    }
}
