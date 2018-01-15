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

        int xPositieLabels;
        int yPositieLabels;

        int xPositieNumeric;
        int yPositieNumeric;

        MaterialRaisedButton button;
        int xPositieButton;
        int yPositieButton;

        int controlCounter;

        string opsturenTweede;

        public SimuleerSchermcs(List<Coupe> listCoupe, Locomotief loco)
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

        private void ControlsAanmaken()
        {
            foreach (Coupe coup in coupeList)
            {
                MaterialLabel label = new MaterialLabel
                {
                    Location = new Point(xPositieLabels, yPositieLabels),
                    Text = String.Format("Coupe {0}:", controlCounter)
                };

                NumericUpDown numeric = new NumericUpDown
                {
                    Location = new Point(xPositieNumeric, yPositieNumeric),
                    Maximum = coup.Aantal_stoelen
                };

                this.Controls.Add(label);
                this.Controls.Add(numeric);

                controlCounter++;
                yPositieButton += 34;
                yPositieLabels += 34;
                yPositieNumeric += 34;

                this.Height = yPositieButton + 50;
            }
        }



        private void String2Aanmaken()
        {
            foreach (NumericUpDown down in this.Controls.OfType<NumericUpDown>())
            {
                int getal = (int)down.Value;
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

            String2Aanmaken();


            SerialPort arduinoPort = new SerialPort();

            arduinoPort.BaudRate = 9600;
            arduinoPort.PortName = "COM4";

            arduinoPort.Open();
            arduinoPort.WriteLine("#" + opsturenTweede.TrimEnd(',') + "&");
            arduinoPort.Close();
        }
    }
}
