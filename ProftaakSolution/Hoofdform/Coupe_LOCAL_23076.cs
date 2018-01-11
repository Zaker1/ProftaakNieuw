using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Hoofdform
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class Coupe
    {
        //static string ConnectionString = @"Server=mssql.fhict.local;Database=dbi392341;User Id = dbi392341; Password=Proftaak123;";
        private string naam;
        private int aantal_stoelen;
        private bool is_dubbeldekker;
        private bool speciaal;
        private string klasse_links;
        private string klasse_rechts;
        private Image image;

        public Coupe(int stoelen, bool dubbeldekker, string klasseLinks, string klasseRechts, string naam, Image img, bool speciaal)
        {
            this.aantal_stoelen = stoelen;
            this.is_dubbeldekker = dubbeldekker;
            this.speciaal = speciaal;
            this.klasse_links = klasseLinks;
            this.klasse_rechts = klasseRechts;
            this.image = img;
            this.naam = naam;
        }

        public string Naam { get; set; }
        public Image Image { get; set; }
        public bool Speciaal { get; set; }
        public bool Is_dubbeldekker { get; set; }
        public int Aantal_stoelen { get; set; }
        public string Klasse_rechts { get; set; }
        public string Klasse_links { get; set; }


        public void CoupeToevoegen()
        {
            byte [] imageByte = ImageConverter.imageToByteArray(image);

            string query = "INSERT INTO dbo.Coupe(aantal_stoelen,is_dubbeldekker,klasse_links,klasse_rechts,image, naam, speciaal) VALUES(@param1,@param2,@param3,@param4,@param5, @param6, @param7)";

            using (SqlConnection connection = new SqlConnection(DatabaseCONN.ConnString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@param1", aantal_stoelen);
                cmd.Parameters.AddWithValue("@param2", is_dubbeldekker);
                cmd.Parameters.AddWithValue("@param3", klasse_links);
                cmd.Parameters.AddWithValue("@param4", klasse_rechts);
                cmd.Parameters.AddWithValue("@param5", imageByte);
                cmd.Parameters.AddWithValue("@param6", naam);
                cmd.Parameters.AddWithValue("@param7", speciaal);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        } 
    }
}
