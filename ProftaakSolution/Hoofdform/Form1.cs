using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using System.Data.SqlClient;


namespace Hoofdform
{
    public partial class Form1 : MaterialForm
    {
        DataTable dt = new DataTable();

        List<Coupe> coupeLijst = new List<Coupe>();

        static string ConnectionString =  @"Server=mssql.fhict.local;Database=dbi392341;User Id = dbi392341; Password=Proftaak123;";
        public Form1()
        {
           InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Yellow700, Primary.Blue800,
                Primary.Yellow600, Accent.Blue400,
                TextShade.BLACK
            );

            fillCombos();
            
        }

        private void fillCombos()
        {
            // query voor naam id ophalen van coupes
            string query = "SELECT * FROM Coupe";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {

                connection.Open();



                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                cmd.ExecuteNonQuery();


                cmbCoupe.DataSource = dt;
                cmbCoupe.DisplayMember = "naam";
                cmbCoupe.ValueMember = "id";


            }
            // query voor naam id ophalen van cabines
            string query1 = "SELECT naam, id FROM TreinCabine";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query1, connection))
            {

                connection.Open();



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill(dt);

                cmd.ExecuteNonQuery();


                cmbCabine.DataSource = dt;
                cmbCabine.DisplayMember = "naam";
                cmbCabine.ValueMember = "id";


            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }
        

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            /*
                DatabaseCon.CONN.Open();
                cmd = DatabaseCon.CONN.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Boek WHERE isbn_nummer ='" + data.isbn_nummer + "'";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    data.titel = (dr["titel"].ToString());
                    data.auteur = (dr["auteur"].ToString());
                    data.beschrijving = (dr["beschrijving"].ToString());
                    data.genre = (dr["genre"].ToString());
                    data.prijs = (Convert.ToDecimal(dr["prijs"].ToString()));
                    data.uitgeversector_naam = (dr["uitgeversector_naam"].ToString());
                }
                cmd.ExecuteNonQuery();
                DatabaseCon.CONN.Close();
            */

            


            //ImageConverter.byteArrayToImage()

            // trein.TreinOntvangen(list); 

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
                                                                        
        }

        private void coupeToevoegen()
        {
            int stoelen = 0;
            try
            {
                stoelen = Convert.ToInt32(textboxStoelenL.Text) + Convert.ToInt32(textboxStoelenR.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invoer is ongeldig, vul alles in!");
            }


            bool dubbeldekker;
            if (radioDubbelJa.Checked)
            {
                dubbeldekker = true;
            }
            else
            {
                dubbeldekker = false;
            }

            string klasseL;
            string klasseR;
            if (radio1eL.Checked)
            {
                klasseL = "1";
            }
            else
            {
                klasseL = "2";
            }

            if (radio1eR.Checked)
            {
                klasseR = "1";
            }
            else
            {
                klasseR = "2";
            }

            string naam = textboxNaamCoupe.Text;

            bool speciaal;
            if (checkSpeciaal.Checked)
            {
                speciaal = true;
            }
            else
            {
                speciaal = false;
            }

            Coupe coupe = new Coupe(stoelen, dubbeldekker, klasseL, klasseR, naam, pictureCoupe.Image, speciaal);
            coupe.CoupeToevoegen();
            MessageBox.Show("Coupe is toegevoegd");
        }

        private void btnCoupeToevoegen_Click(object sender, EventArgs e)
        {
            coupeToevoegen();
        }

        private void locomotiefToevoegen()
        {
            string naam = textboxCabineNaam.Text;
            bool passagier;
            if (radioPassagierJa.Checked)
            {
                passagier = true;
            }
            else
            {
                passagier = false;
            }

            Locomotief loco = new Locomotief(naam, passagier, pictureLoco.Image);
            loco.CabineToevoegen();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            locomotiefToevoegen();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureCoupe.Image = new Bitmap(open.FileName);
            }
        }

        private void materialToevoegen_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureLoco.Image = new Bitmap(open.FileName);
            }
        }

        private void btnAddCoupe_Click(object sender, EventArgs e)
        {
           // Coupe coupe = (Coupe) cmbCoupe.SelectedItem;
           
            for (int i = 0; i < Convert.ToInt32(textAantal.Text); i++)
            {
                int id = (int)cmbCoupe.SelectedValue;

                DataRow foundRow = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("id") == id);

                byte[] byteImage = (byte[])foundRow["image"];

                Coupe Coupe = new Coupe(Convert.ToInt32(foundRow["aantal_stoelen"]), Convert.ToBoolean(foundRow["is_dubbeldekker"]), foundRow["klasse_links"].ToString(),foundRow["klasse_rechts"].ToString(),foundRow["naam"].ToString(),ImageConverter.byteArrayToImage(byteImage),Convert.ToBoolean(foundRow["speciaal"]));

                coupeLijst.Add(Coupe);
            }

           

        }
    }
}
