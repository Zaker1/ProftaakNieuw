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

namespace Hoofdform
{
    public partial class InlogForm : MaterialForm
    {
        public InlogForm()
        {
            InitializeComponent();

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

        private void buttonInloggen_Click(object sender, EventArgs e)
        {
            bool inloggen = Login.Inloggen(textNaam.Text, textWachtwoord.Text);

            if (inloggen)
            {
                Form1 form = new Form1();

                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Dit account bestaat niet, probeer opnieuw.");
            }
            
        }
    }
}
