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

            List<Coupe> list = Coupe.CoupeOphalen();

            foreach (Coupe coupe in list)
            {
                cmbCoupe.Items.Add(coupe);
            }

            List<Locomotief> list1 = Locomotief.LocomotiefOphalen();

            foreach (Locomotief loco in list1)
            {
                cmbCabine.Items.Add(loco);
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

            Trein trein = new Trein();
            int id = Convert.ToInt32(cmbCoupe.SelectedValue);
            List<int> list = new List<int>();


            for (int i = 0; i < Convert.ToInt32(textAantal.Text); i++)
            {
                list.Add(id);
            }
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
            catch(Exception c)
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
            Image foto = pictureBox3.Image;

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
                pictureBox3.Image = new Bitmap(open.FileName);
            }
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
