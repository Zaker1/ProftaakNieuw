using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;

namespace Hoofdform
{
    public class Locomotief
    {
        private string naam;
        private bool passagierPlekken;
        private Image image;

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
            catch (Exception)
            {

                
            }

            DatabaseCONN.conn.Close();
        }
    }
}
