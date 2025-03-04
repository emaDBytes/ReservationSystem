using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Trailer
    {
         DBService dBService = new DBService();


        public int id { get; private set; }
        public int ref_store_id { get; private set; }
        private string register;
        public string model { get; private set; }
        public string extraservice_id { get; private set; }


        public Trailer(string trailer_id)
        {
            string[] trailerData = dBService.SendQuery("*", "trailer", "trailer_id", trailer_id);
            id              = int.Parse(trailerData[0]);
            register        = trailerData[1];
            model           = trailerData[2];
            ref_store_id    = int.Parse(trailerData[0]);

            Console.WriteLine(trailerData.ToString() + "-- Trailer created");
        }

        public override string ToString()
        {
            string mode = "";
            if (model == "S") { mode = "Small trailer"; }
            if (model == "L") { mode = "Large trailer"; }
            if (model == "B") { mode = "Boat trailer"; }
                    return mode + " " + id; 
        }
        //comment
        }
    }

