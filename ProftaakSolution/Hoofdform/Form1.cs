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
        SqlCommand cmd = new SqlCommand();
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

            bool connection = DatabaseCONN.getConnectieString();
            DatabaseCONN.CONN.Open();
            cmd = DatabaseCONN.CONN.CreateCommand();
            cmd.CommandText = "Select * from Perron";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.ExecuteNonQuery();
            DatabaseCONN.CONN.Close();

            cmbCoupe.DataSource = dt;
            cmbCoupe.DisplayMember = "naam";
            cmbCoupe.ValueMember = "id";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
                                                                        
        }

        private void btnCoupeToevoegen_Click(object sender, EventArgs e)
        {
            int stoelen = Convert.ToInt32(textboxStoelenL.Text) + Convert.ToInt32(textboxStoelenR.Text);
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

            Trein coupe = new Trein();
            coupe.CoupeToevoegen(stoelen, dubbeldekker, klasseL, klasseR, naam);

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

            Trein cabine = new Trein();
            cabine.CabineToevoegen(naam, passagier);
        }
    }
}
