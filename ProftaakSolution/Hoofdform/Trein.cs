using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO.Ports;

namespace Hoofdform
{
    public class Trein
    {
        public SerialPort arduinoPoort;
        List<int> listCoupe;
        
        static string ConnectionString = @"Server=mssql.fhict.local;Database=dbi392341;User Id = dbi392341; Password=Proftaak123;";

        string speciaal;
        string klasseR;
        string klasseL;
        string stoelenInCoupe;
        string compleet;
        

        public Trein()
        {

        }

        public void TreinOntvangen(List<int> list)
        {
            listCoupe = list;
            CoupeOphalen();
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
            if (speciaal == "True")
            {
                speciaal = "1";
            }
            else
            { 
                speciaal = "0";
            }
            compleet = String.Format("{0},{1},{2},{3}", speciaal, klasseR, klasseL, stoelenInCoupe);

            arduinoPoort.Open();
            arduinoPoort.WriteLine(compleet);
            arduinoPoort.Close();
        }
    }
}
