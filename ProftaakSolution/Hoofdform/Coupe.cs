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
        private int aantalStoelen;
        private bool dubbelDekker;
        private bool speciaal;
        private string klasseLinks;
        private string klasseRechts;
        private Image image;

        public Coupe(int stoelen, bool dubbeldekker, string klasseLinks, string klasseRechts, string naam, Image img, bool speciaal)
        {
            this.aantalStoelen = stoelen;
            this.dubbelDekker = dubbeldekker;
            this.speciaal = speciaal;
            this.klasseLinks = klasseLinks;
            this.klasseRechts = klasseRechts;
            this.image = img;
            this.naam = naam;
        }

        public Coupe(string naam)
        {
            this.naam = naam;
        }


        public void CoupeToevoegen()
        {
            byte [] imageByte = ImageConverter.imageToByteArray(image);

            string query = "INSERT INTO dbo.Coupe(aantal_stoelen,is_dubbeldekker,klasse_links,klasse_rechts,image, naam, speciaal) VALUES(@param1,@param2,@param3,@param4,@param5, @param6, @param7)";

            using (SqlConnection connection = new SqlConnection(DatabaseCONN.ConnString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@param1", aantalStoelen);
                cmd.Parameters.AddWithValue("@param2", dubbelDekker);
                cmd.Parameters.AddWithValue("@param3", klasseLinks);
                cmd.Parameters.AddWithValue("@param4", klasseRechts);
                cmd.Parameters.AddWithValue("@param5", imageByte);
                cmd.Parameters.AddWithValue("@param6", naam);
                cmd.Parameters.AddWithValue("@param7", speciaal);

                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Error.ErrorWegschrijven(e.ToString());
                }
            }
        } 

        public static List<Coupe> CoupeOphalen()
        {
            string query = "SELECT * FROM dbo.Coupe";
            List<Coupe> list = new List<Coupe>();

            using (SqlConnection connection = new SqlConnection(DatabaseCONN.ConnString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {

                connection.Open();



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Error.ErrorWegschrijven(e.ToString());
                }

                foreach (DataRow dr in dt.Rows)
                {
                    string naam = dr["naam"].ToString();
                    int stoelen = (int)dr["aantal_stoelen"];
                    string klasseLinks = dr["klasse_links"].ToString();
                    string klasseRechts = dr["klasse_rechts"].ToString();
                    bool speciaal = Convert.ToBoolean(dr["speciaal"]);
                    bool dubbeldekker = Convert.ToBoolean(dr["is_dubbeldekker"]);
                    byte[] byteImage = (byte[])dr["image"];
                    Image image = ImageConverter.byteArrayToImage(byteImage);

                    Coupe coupe = new Coupe(stoelen, dubbeldekker, klasseLinks, klasseRechts, naam, image, speciaal);
                    list.Add(coupe);
                }
            }
            return list;
        }

        public override string ToString()
        {
            return naam;
        }
    }
}
