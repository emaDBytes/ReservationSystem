using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Extraservice
    {
        DBService dBService = new DBService();

        public int id           { get; private set; }
        public int ref_store_id { get; private set; }
        public string type      { get; private set; }
        public string size      { get; private set; }


        public Extraservice(string service_id)
        {
            string[] trailerData = dBService.SendQuery("*", "extraservice", "extraservice_id", service_id);

            id              = int.Parse(trailerData[0]);
            type            = trailerData[1];
            size            = trailerData[2];
            ref_store_id    = int.Parse(trailerData[3]);

             Console.WriteLine(type);


        }
    }
}
