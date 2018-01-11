using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Hoofdform
{
    public class Locomotief
    {
        private string naam;
        private bool passagierPlekken;
        private Image image;

        public Image Image
        {
            get
            {
                return this.image;
            }
        }

        SqlCommand cmd = new SqlCommand();

        public Locomotief(string naam, bool passagierPlekken, Image image)
        {
            this.naam = naam;
            this.passagierPlekken = passagierPlekken;
            this.image = image;
        }

        public void CabineToevoegen()
        {
            byte[] imageByte = ImageConverter.imageToByteArray(image);

            bool connection = DatabaseCONN.getConnectieString();
            DatabaseCONN.conn.Open();
            cmd = DatabaseCONN.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.TreinCabine(naam, passagiers_plekken, image) VALUES(@param1, @param2, @param3)";

            cmd.Parameters.AddWithValue("@param1", naam);
            cmd.Parameters.AddWithValue("@param2", passagierPlekken);
            cmd.Parameters.AddWithValue("@param3", imageByte);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Error.ErrorWegschrijven(e.ToString());
            }

            DatabaseCONN.conn.Close();
        }

        public static List<Locomotief> LocomotiefOphalen()
        {
            string query = "SELECT * FROM dbo.TreinCabine";
            List<Locomotief> list = new List<Locomotief>();

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
                    //Error.ErrorWegschrijven(e.ToString());
                }

                foreach (DataRow dr in dt.Rows)
                {
                    string naam = dr["naam"].ToString();
                    byte[] byteImage = (byte[])dr["image"];
                    Image image = ImageConverter.byteArrayToImage(byteImage);
                    bool stoelen = Convert.ToBoolean(dr["passagiers_plekken"]);

                    Locomotief loco = new Locomotief(naam, stoelen, image);
                    list.Add(loco);
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
