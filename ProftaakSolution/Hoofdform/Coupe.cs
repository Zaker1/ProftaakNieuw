using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoofdform
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class Coupe
    {
        SqlCommand cmd = new SqlCommand();

        public Coupe()
        {

        }


        public void CoupeToevoegen(int stoelen, bool dubbeldekker, string klasseLinks, string klasseRechts, string naam, Image img)
        {
            byte [] image = ImageConverter.imageToByteArray(img);

            bool connection = DatabaseCONN.getConnectieString();
            DatabaseCONN.CONN.Open();
            cmd = DatabaseCONN.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Coupe(aantal_stoelen,is_dubbeldekker,klasse_links,klasse_rechts,image, naam) VALUES(@param1,@param2,@param3,@param4,@param5, @param6)";

            cmd.Parameters.AddWithValue("@param1", stoelen);
            cmd.Parameters.AddWithValue("@param2", dubbeldekker);
            cmd.Parameters.AddWithValue("@param3", klasseLinks);
            cmd.Parameters.AddWithValue("@param4", klasseRechts);
            cmd.Parameters.AddWithValue("@param5", image);
            cmd.Parameters.AddWithValue("@param6", naam);

            cmd.ExecuteNonQuery();

            DatabaseCONN.CONN.Close();
        }

        
    }
}
