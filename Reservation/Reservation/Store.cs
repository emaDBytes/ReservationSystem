using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Store
    {   DBService dBService = new DBService();  
        string id;
        string address;
        string city;

       public List<Trailer> trailersList;
       public List<Extraservice> extraserviceList;
       public List<Reservation> reservationList;
       public List<Customer> customerList;



        int[,] timeslot;

        public Store(string id)
        {                                        
            string[] storeID = dBService.SendQuery("*", "store", "store_id", id);


            this.id = storeID[0];
            this.address = storeID[1];
            this.city = storeID[2];

            GetTrailers();
            GetExtraservice();
            GetReservation();
            GetCustmomer();
            timeslot = new int[trailersList.Count, 30];
        }
        public void GetTrailers() 
        {
            trailersList = new List<Trailer>();
                                                        /*  SELECT * FROM * WHERE X=X  */
            string[] trailerID = dBService.SendQuery("trailer_id", "trailer", "ref_store_id", id);

            for (int i = 0; i < trailerID.Length-1; i++)
            {
                Trailer trailer = new Trailer(trailerID[i]);
                trailersList.Add(trailer);
            }
        }
        public void GetExtraservice()
        {
            extraserviceList = new List<Extraservice>();
            string[] extra_serviceID = dBService.SendQuery("extraservice_id", "extraservice", "ref_store_id", id);

            for (int i = 0; i < extra_serviceID.Length - 1; i++)
            {
                Extraservice extra_service = new Extraservice(extra_serviceID[i]);
                extraserviceList.Add(extra_service);
            }
        }
        public void GetReservation()
        {
            reservationList = new List<Reservation>();

            string[] reservationID = dBService.SendQuery("SELECT r.reservation_id FROM reservation AS r JOIN trailer AS t ON r.trailer_id = t.trailer_id WHERE t.ref_store_id = " + id + ";", true); ;

            for (int i = 0; i < reservationID.Length - 1; i++)
            {
                Reservation reservation = new Reservation(reservationID[i]);
                reservationList.Add(reservation);
            }
        }
      
        public void GetCustmomer()
        {
            customerList = new List<Customer>();

            string[] customerID = dBService.SendQuery("SELECT customer_id FROM customer", true); ;

            for (int i = 0; i < customerID.Length - 1; i++)
            {
                Customer customer = new Customer(customerID[i]);
                customerList.Add(customer);
            }
        }
        public void ShowReservation()
        {
            DateTime today = DateTime.Today;

            foreach (Reservation res in reservationList)
            {
                 int trailerID = res.trailer_id;
                 int startDay = (res.start_time - today).Days;
                 int endDay = (res.end_time - today).Days;

                    for (int day = startDay; day <= endDay; day++)
                    {
                        if (day >= 0 && day < timeslot.GetLength(1))
                        {
                        timeslot[trailerID, day] = res.id;
                        }
                    }
             }
            int rows = timeslot.GetLength(0);
            int cols = timeslot.GetLength(1);

            // header row 
            Console.Write("\nTrailer\\Day".PadRight(12));
            for (int day = 0; day < cols; day++)
            {
                Console.Write((day + 1).ToString().PadLeft(3));
            }
            Console.WriteLine();

            // trailer reservations.
            Console.WriteLine("Store id " + id + "".PadRight(12));

            for (int row = 0; row < rows; row++)
            {
                Console.Write("Trailer id " + (trailersList[row].id) +" }".PadRight(12));
                for (int col = 0; col < cols; col++)
                {
                    char cell = ' ';
                    if (timeslot[row, col] != 0)
                    {
                        cell = 'X';
                    }
                    Console.Write(cell.ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }
    }
}
