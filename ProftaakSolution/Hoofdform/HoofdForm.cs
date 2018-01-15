using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO.Ports;



namespace Hoofdform
{
    public partial class HoofdForm : MaterialForm
    {
        DataTable dt = new DataTable();
        int counterTotaalCoupe;
        int counterEerste;
        int counterTweede;
        int counterSpeciaal;
        List<Coupe> coupeLijst = new List<Coupe>();
        string opsturenEerste;

        public HoofdForm(bool rechten)
        {
            InitializeComponent();

            if (rechten == false)
            {
                materialTabControl1.TabPages.Remove(coupeToevoeg);
                materialTabControl1.TabPages.Remove(tabPage1);
            }
            
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

        private void String1Aanmaken()
        {
            Coupe coupe = coupeLijst.First();
            string speciaal;
            string klasseR = coupe.Klasse_Rechts;
            string klasseL = coupe.Klasse_Links;
            string stoelenInCoupe = coupe.Aantal_stoelen.ToString();

            if (coupe.Speciaal)
            {
                speciaal = "1";
            }
            else
            {
                speciaal = "0";
            }
            opsturenEerste = String.Format("{0},{1},{2},{3}", speciaal, klasseR, klasseL, Convert.ToInt32(textLengte.Text));
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (coupeLijst.Count == 0)
            {
                MessageBox.Show("Je hebt geen coupe's geselecteerd");
            }
            else
            {
                try
                {
                    String1Aanmaken();

                    SimuleerSchermcs simuleer = new SimuleerSchermcs(coupeLijst, (Locomotief)cmbCabine.SelectedItem, opsturenEerste);
                    simuleer.Show();
                }
                catch (Exception c)
                {
                    Error.ErrorWegschrijven(c.ToString());
                    MessageBox.Show("Selecteer een locomotief/coupe");
                } 
            }
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
                fillCombos();
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
            try
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
                Image foto = pictureAddCabine.Image;

                Locomotief cabine = new Locomotief(naam, passagier, foto);
                cabine.CabineToevoegen();
                fillCombos();
                MessageBox.Show("Cabine is toegevoegd");
            }
            catch (Exception c)
            {
                MessageBox.Show("U bent iets vergeten!");
                Error.ErrorWegschrijven(c.ToString());
            }
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
                pictureAddCabine.Image = new Bitmap(open.FileName);
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

                    if (coupe.Klasse_Links == "1")
                    {
                        counterEerste++;
                    }
                    else
                    {
                        counterTweede++;
                    }

                    if (coupe.Klasse_Rechts == "1")
                    {
                        counterEerste++;
                    }
                    else
                    {
                        counterTweede++;
                    }

                    if (coupe.Speciaal)
                    {
                        counterSpeciaal++;
                    }

                    coupeLijst.Add(coupe);
                }
                catch (Exception c)
                {
                    Error.ErrorWegschrijven(c.ToString());
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

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            locomotiefToevoegen();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonUitloggen_Click(object sender, EventArgs e)
        {
            this.Close();
            InlogForm form = new InlogForm();
            form.Show();
        }
    }
}
    
    

