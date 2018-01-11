using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hoofdform
{
    public static class Error
    {
        public static void ErrorWegschrijven(string error)
        {
            string pathText = String.Format(@"Resources/Logbestand.txt");
            FileStream fs = new FileStream(pathText, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(error + "//" + DateTime.Now);

            sw.Close();
            fs.Close();
        }

        public static void ErrorOphalen()
        {

        }
    }
}
