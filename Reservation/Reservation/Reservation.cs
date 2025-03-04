using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Reservation
{
    public class Reservation
    {
        DBService dBService = new DBService();

        public DateTime start_time { get; private set; }
        public DateTime end_time { get; private set; }


        public int id            { get; private set; }
        public int customer_id   { get; private set; }
        public int trailer_id    { get; private set; }
        public int extraservice_id { get; private set; }

        public Reservation(string id)
        {
            string[] reservationData = dBService.SendQuery("*", "reservation", "reservation_id", id);

            this.id             = int.Parse(reservationData[0]);
            //start_time          = DateTime.ParseExact(reservationData[1], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //end_time            = DateTime.ParseExact(reservationData[2], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            customer_id         = int.Parse(reservationData[3]);
            trailer_id          = int.Parse(reservationData[4]);

           // Console.WriteLine(reservationData[1]);
        }
        public override string ToString()
        {
            return start_time.ToString() + end_time.ToString() + " Customer id: "  + customer_id + " Trailer id: " + trailer_id ;
        }
    }
}
