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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class Trein
    {
        SqlCommand cmd = new SqlCommand();

        public Trein()
        {

        }


        public void CoupeToevoegen(int stoelen, bool dubbeldekker, string klasseLinks, string klasseRechts, string naam)
        {
            bool connection = DatabaseCONN.getConnectieString();
            DatabaseCONN.CONN.Open();
            cmd = DatabaseCONN.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Coupe(aantal_stoelen,is_dubbeldekker,klasse_links,klasse_rechts, naam) VALUES(@param1,@param2,@param3,@param4,@param5)";

            cmd.Parameters.AddWithValue("@param1", stoelen);
            cmd.Parameters.AddWithValue("@param2", dubbeldekker);
            cmd.Parameters.AddWithValue("@param3", klasseLinks);
            cmd.Parameters.AddWithValue("@param4", klasseRechts);
            cmd.Parameters.AddWithValue("@param5", naam);

            cmd.ExecuteNonQuery();

            DatabaseCONN.CONN.Close();
        }

        public void CabineToevoegen(string naam, bool passagiers_plekken)
        {
            bool connection = DatabaseCONN.getConnectieString();
            DatabaseCONN.CONN.Open();
            cmd = DatabaseCONN.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.TreinCabine(naam, passagiers_plekken) VALUES(@param1, @param2)";

            cmd.Parameters.AddWithValue("@param1", naam);
            cmd.Parameters.AddWithValue("@param2", passagiers_plekken);

            cmd.ExecuteNonQuery();

            DatabaseCONN.CONN.Close();
        }
    }
}
