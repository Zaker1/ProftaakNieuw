using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoofdform
{
    public static class Error
    {
        public static void ErrorWegschrijven(string error)
        {
            string pathText = String.Format(@"Resources/Logbestand.txt");
            FileStream fs = new FileStream(pathText, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(DateTime.Now + "//" + error);

            sw.Close();
            fs.Close();
        }

        public static void ErrorOphalen()
        {

        }
    }
}
