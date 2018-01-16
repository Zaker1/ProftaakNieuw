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
using System.IO.Ports;

namespace Hoofdform
{
    public partial class SimuleerSchermcs : MaterialForm
    {
        List<Coupe> coupeList;
        Locomotief locomotief;
        MessageBuilder messageBuilder = new MessageBuilder('#', '%');

        int xPositieLabels;
        int yPositieLabels;

        int xPositieNumeric;
        int yPositieNumeric;

        MaterialRaisedButton button;
        int xPositieButton;
        int yPositieButton;

        int controlCounter;
        int berichtCounter;

        string strEerstecoupe;

        string opsturenTweede;

        bool blEerstecoupe = true;

        public SimuleerSchermcs(List<Coupe> listCoupe, Locomotief loco, String strEerstecoupe)
        {
            InitializeComponent();

            this.strEerstecoupe = strEerstecoupe;

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

            coupeList = listCoupe;
            locomotief = loco;

            xPositieLabels = 12;
            yPositieLabels = 107;

            xPositieNumeric = 115;
            yPositieNumeric = 107;

            xPositieButton = 12;
            yPositieButton = yPositieLabels;

            controlCounter = 1;

            ControlsAanmaken();

            button = new MaterialRaisedButton
            {
                Location = new Point(xPositieButton, yPositieButton),
                Text = ("Simuleer")
            };

            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        public SimuleerSchermcs()
        {
        }

        private void ControlsAanmaken()
        {
            foreach (Coupe coup in coupeList)
            {
                MaterialLabel label = new MaterialLabel
                {
                    Location = new Point(xPositieLabels, yPositieLabels),
                    Text = String.Format("Coupe {0}:", controlCounter)
                };

                MaterialLabel labelKleur = new MaterialLabel
                {
                    Location = new Point(xPositieNumeric + 130, yPositieLabels),
                    Text = String.Format("Status:"),
                    Tag = controlCounter
                };

                NumericUpDown numeric = new NumericUpDown
                {
                    Location = new Point(xPositieNumeric, yPositieNumeric),
                    Maximum = coup.Aantal_stoelen
                };


                this.Controls.Add(labelKleur);
                this.Controls.Add(label);
                this.Controls.Add(numeric);

                controlCounter++;
                yPositieButton += 34;
                yPositieLabels += 34;
                yPositieNumeric += 34;

                this.Height = yPositieButton + 50;
                this.Width = xPositieNumeric + 300;
            }
        }



        private void String2Aanmaken()
        {
            foreach (NumericUpDown down in this.Controls.OfType<NumericUpDown>())
            {
                int getal = (int)Map(down.Value, 0, down.Maximum, 0, 255);
                string tijdelijkDeel = getal.ToString();


                if (tijdelijkDeel.Length == 1)
                {
                    tijdelijkDeel = "00" + getal.ToString();
                    opsturenTweede = opsturenTweede + tijdelijkDeel + ",";
                }
                else if (tijdelijkDeel.Length == 2)
                {
                    tijdelijkDeel = "0" + getal.ToString();
                    opsturenTweede = opsturenTweede + tijdelijkDeel + ",";
                }
                else
                {
                    opsturenTweede = opsturenTweede + tijdelijkDeel + ",";
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            messageTimer.Enabled = true;
            String2Aanmaken();

            if (blEerstecoupe)
            {
                blEerstecoupe = false;
                Communication.berichtVerzenden("#" + strEerstecoupe + "%");
            }
            
            Communication.berichtVerzenden("#" + opsturenTweede.TrimEnd(',') + "&");

            System.Threading.Thread.Sleep(300);

            opsturenTweede = "";
        }

        private static decimal Map(decimal value, decimal fromSource, decimal toSource, decimal fromTarget, decimal toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        private void messageTimer_Tick(object sender, EventArgs e)
        {
            List<string> berichten = new List<string>();
            berichten = Communication.ReadMessage();

            if (berichten != null)
            {
                berichtCounter = 0;
                foreach (string bericht in berichten)
                {
                    if (bericht == "GEMIDDELD" || bericht == "VOL" || bericht == "LEEG")
                    {
                        berichtCounter++;

                        foreach (MaterialLabel kleurlabel in this.Controls.OfType<MaterialLabel>())
                        {
                            if (Convert.ToInt32(kleurlabel.Tag) == berichtCounter)
                            {
                                kleurlabel.Text = bericht;

                                switch (bericht)
                                {
                                    case "VOL":
                                        kleurlabel.ForeColor = Color.Red;
                                        break;
                                    case "GEMIDDELD":
                                        kleurlabel.ForeColor = Color.Orange;
                                        break;
                                    case "LEEG":
                                        kleurlabel.ForeColor = Color.Green;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
