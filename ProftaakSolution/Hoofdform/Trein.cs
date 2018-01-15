using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO.Ports;

namespace Hoofdform
{
    public class Trein
    {
        public SerialPort arduinoPoort;

        List<Coupe> coupes = new List<Coupe>();
        Locomotief locomotief;
        //static string ConnectionString = @"Server=mssql.fhict.local;Database=dbi392341;User Id = dbi392341; Password=Proftaak123;";
        
        public Trein(List<Coupe> coupes, Locomotief locomotief)
        {
            this.locomotief = locomotief;
            this.coupes = coupes;
        }

        public Trein()
        {

        }

        public void passagiersDoorgeven()
        {
            //hier de values doorgeven van het scherm
        }

        public void coupeDoorgeven()
        {
            //hier de eerste coupe uit de lijst doorgeven
        }

        
    }
}
