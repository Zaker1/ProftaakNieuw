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
            MessageBuilder messageBuilder = new MessageBuilder('$', '@');
            serialMessenger = new SerialMessenger("COM4", 9600, messageBuilder);

            try
            {
                serialMessenger.Connect();
            }
            catch
            {
                MessageBox.Show("Er kan geen verbinding worden gemaakt met de Arduino");
            }
        }

        public static void berichtVerzenden(string bericht)
        {
            serialMessenger.SendMessage(bericht);
        }

        public static List<string> ReadMessage()
        {
            List<string> berichten = new List<string>();
            berichten = serialMessenger.ReadMessages();
            if (berichten[0] != "")
            {
                return berichten;
            }

            berichten.Add("");
            return berichten;
        }

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
