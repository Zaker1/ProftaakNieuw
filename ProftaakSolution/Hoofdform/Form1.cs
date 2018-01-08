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

            string query = "SELECT naam, id FROM Coupe";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                cmbCabine.DisplayMember = "naam";
                cmbCabine.ValueMember = "id";

                List<Object> resultCoupes = new List<object>();

                while (reader.Read())
                {
                    resultCoupes.Add(reader["naam"]);
                }

                cmbCabine.DataSource = resultCoupes;
               
                int test = Convert.ToInt32(cmbCabine.SelectedValue);
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
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
                                                                        
        }

        private void btnCoupeToevoegen_Click(object sender, EventArgs e)
        {
            int stoelen = 0;
            try
            {
                stoelen = Convert.ToInt32(textboxStoelenL.Text) + Convert.ToInt32(textboxStoelenR.Text);
            }
            catch(Exception)
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
                klasseL = "1e";
            }
            else
            {
                klasseL = "2e";
            }
            
            if (radio1eR.Checked)
            {
                klasseR = "1e";
            }
            else
            {
                klasseR = "2e";
            }

            string naam = textboxNaamCoupe.Text;

            Coupe coupe = new Coupe();
            coupe.CoupeToevoegen(stoelen, dubbeldekker, klasseL, klasseR, naam, pictureCoupe.Image);
            MessageBox.Show("Coupe is toegevoegd");

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
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

            Cabine cabine = new Cabine();
            cabine.CabineToevoegen(naam, passagier);
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
    }
}
