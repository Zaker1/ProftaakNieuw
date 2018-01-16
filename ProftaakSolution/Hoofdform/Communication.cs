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

        public static string[] ReadMessage()
        {
            string[] berichten = serialMessenger.ReadMessages();
            if (berichten != null)
            {
                return berichten;
            }

            return null;
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
