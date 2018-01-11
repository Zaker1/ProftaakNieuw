using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hoofdform
{
    public static class Login
    {
        static string ConnectionString = @"Server=mssql.fhict.local;Database=dbi392341;User Id = dbi392341; Password=Proftaak123;";
        public static bool Inloggen(string gebruikersnaam, string wachtwoord)
        {
            bool gelukt = false;
            string query = "SELECT * FROM dbo.Gebruiker WHERE naam = @naam AND wachtwoord = @ww";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {

                connection.Open();

                cmd.Parameters.AddWithValue("@naam", gebruikersnaam);
                cmd.Parameters.AddWithValue("@ww", wachtwoord);

                try
                {
                    SqlDataReader adapter = cmd.ExecuteReader();
                    if (adapter.HasRows)
                    {
                        gelukt = true;
                    }
                    else
                    {
                        gelukt = false;
                    }
                }
                catch (ArgumentException e)
                {
                    //Error.ErrorWegschrijven(e.ToString());
                }
            }
            return gelukt;
        }
    }
}
