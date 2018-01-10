using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hoofdform
{
    public class Locomotief
    {
        SqlCommand cmd = new SqlCommand();



        public Locomotief()
        {
               
        }

        public void CabineToevoegen(string naam, bool passagiers_plekken)
        {
            bool connection = DatabaseCONN.getConnectieString();
            DatabaseCONN.CONN.Open();
            cmd = DatabaseCONN.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.TreinCabine(naam, passagiers_plekken) VALUES(@param1, @param2)";

            cmd.Parameters.AddWithValue("@param1", naam);
            cmd.Parameters.AddWithValue("@param2", passagiers_plekken);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                
            }

            DatabaseCONN.CONN.Close();
        }
    }
}
