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

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Properties.Settings.Default.DatabaseUSFConnectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command = connection.CreateCommand();
            command.CommandText = "Select * from Perron";
            SqlDataAdapter da = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            da.Fill(dt);

            command.ExecuteNonQuery();
            connection.Close();

            cmbCoupe.DataSource = dt;
            cmbCoupe.DisplayMember = "naam";
            cmbCoupe.ValueMember = "id";

            // DataSet ds = new DataSet();
            // da.Fill(ds);
            // dataGridView1.AutoGenerateColumns = true;
            // dataGridView1.DataSource = ds.Tables;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
                                                                        
        }
    }
}
