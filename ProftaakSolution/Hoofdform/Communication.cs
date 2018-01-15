using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoofdform
{
    static class Communication
    {
        private static SerialMessenger serialMessenger;
        private static Timer checkBerichten;

        public static void Connect()
        {
            MessageBuilder messageBuilder = new MessageBuilder('#', '%');
            serialMessenger = new SerialMessenger("COM1", 9600, messageBuilder);

            try
            {
                serialMessenger.Connect();

                checkBerichten = new Timer();
                checkBerichten.Interval = 10;
                checkBerichten.Tick += new EventHandler(ReadMessageTimer_Tick);
                checkBerichten.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Er kan geen verbinding worden gemaakt met de Arduino");
            }
        }

        public static void berichtVerzenden(string bericht, string parameter)
        {
            serialMessenger.SendMessage(bericht + ":" + parameter);
        }


        private static void ReadMessageTimer_Tick(object sender, EventArgs e)
        {
            string[] berichten = serialMessenger.ReadMessages();
            if (berichten != null)
            {
                foreach (string bericht in berichten)
                {
                    //berichtOphalen(bericht);
                }
            }
        }

        /* private static void berichtOphalen(string bericht)
        {
            if (bericht.StartsWith("Nieuw_spel"))
            {
                Form1 activeForm = (Form1)Form.ActiveForm;
                activeForm.start_spel();

            }
            else if (bericht.StartsWith("Beweging:"))
            {
                string beweging = GetParameter(bericht);
                Form1 activeForm = (Form1)Form.ActiveForm;
                activeForm.robot.bewegen(beweging);

            }
            else if (bericht.StartsWith("Regen:"))
            {
                int interval = Convert.ToInt32(GetParameter(bericht));
                Form1 activeForm = (Form1)Form.ActiveForm;
                activeForm.changeRegenInterval(interval);

            }
            else if (bericht.StartsWith("Stop_spel:"))
            {
                string tijd = GetParameter(bericht);
                Form1 activeForm = (Form1)Form.ActiveForm;
                activeForm.stop_spel();
                activeForm.lblGameOverTijd.Text = "Tijd: " + tijd;
            }

        } */

        private static string GetParameter(string message)
        {
            int valueIndex = message.IndexOf(':');
            if (valueIndex != -1)
            {
                return message.Substring(valueIndex + 1);
            }
            throw new ArgumentException("Bericht heeft geen parameter meegekregen");
        }
    }
}
