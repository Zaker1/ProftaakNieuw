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
        int counterTotaalCoupe;
        int counterEerste;
        int counterTweede;
        int counterSpeciaal;
        List<Coupe> coupeLijst = new List<Coupe>();

        // static string ConnectionString = @"Server=mssql.fhict.local;Database=dbi392341;User Id = dbi392341; Password=Proftaak123;";
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
            List<Locomotief> list1 = Locomotief.LocomotiefOphalen();
            foreach (Locomotief loco in list1)
            {
                cmbCabine.Items.Add(loco);
            }

            List<Coupe> list = Coupe.CoupeOphalen();

            foreach (Coupe coupe in list)
            {
                cmbCoupe.Items.Add(coupe);
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
            SimuleerSchermcs simuleer = new SimuleerSchermcs(coupeLijst, (Locomotief)cmbCabine.SelectedItem);

            simuleer.Show();
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
            catch (Exception c)
            {
                
                Error.ErrorWegschrijven(c.ToString());
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

            try
            {
                Coupe coupe = new Coupe(stoelen, dubbeldekker, klasseL, klasseR, naam, pictureCoupe.Image, speciaal);
                coupe.CoupeToevoegen();
                MessageBox.Show("Coupe is toegevoegd");
            }
            catch (Exception c)
            {
                MessageBox.Show("U bent iets vergeten!");
                Error.ErrorWegschrijven(c.ToString());
            }
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
            Image foto = pictureCoupeHoofd.Image;

            Locomotief cabine = new Locomotief(naam, passagier, foto);
            cabine.CabineToevoegen();
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

            /* for (int i = 0; i < Convert.ToInt32(textAantal.Text); i++)
            {
                int id = (int)cmbCoupe.SelectedValue;

                DataRow foundRow = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("id") == id);

                byte[] byteImage = (byte[])foundRow["image"];

                Coupe Coupe = new Coupe(Convert.ToInt32(foundRow["aantal_stoelen"]), Convert.ToBoolean(foundRow["is_dubbeldekker"]), foundRow["klasse_links"].ToString(), foundRow["klasse_rechts"].ToString(), foundRow["naam"].ToString(), ImageConverter.byteArrayToImage(byteImage), Convert.ToBoolean(foundRow["speciaal"]));

                coupeLijst.Add(Coupe);
            } */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //if closed by user
            {
                Application.Exit();
            }
        }

        private void btnAddCoupeTrein_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < Convert.ToInt32(textAantal.Text); i++)
            {
                counterTotaalCoupe++;

                try
                {
                    Coupe coupe = (Coupe)cmbCoupe.SelectedItem;
                    coupeLijst.Add(coupe);
                }
                catch (Exception c)
                {
                    Error.ErrorWegschrijven(c.ToString());
                }

                foreach (Coupe coup in coupeLijst)
                {
                    if(coup.Klasse_Links == "1")
                    {
                        counterEerste++;
                    }
                    else
                    {
                        counterTweede++;
                    }
                    if (coup.Speciaal)
                    {
                        counterSpeciaal++;
                    }
                }
            }

            labelTotaalCoupes.Text = String.Format("Totaal aantal coupe's: {0}", counterTotaalCoupe);
            labelEersteklasse.Text = String.Format("Aantal eerste klasse: {0}", counterEerste);
            labelTweedeklasse.Text = String.Format("Aantal tweede klasse: {0}", counterTweede);
            labelHandiCoupe.Text = String.Format("Aantal speciale coupe's: {0}", counterSpeciaal);

        }

        private void cmbCabine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Locomotief loco = (Locomotief)cmbCabine.SelectedItem;
            pictureCabine.Image = loco.Image;
        }

        private void cmbCoupe_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coupe coupe = (Coupe)cmbCoupe.SelectedItem;
            pictureCoupeHoofd.Image = coupe.Image;
        }
    }
}
    
    

