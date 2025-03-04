using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservation.Properties
{
    public class DataManager : Store
    {
        DBService dBService = new DBService();

        public string cityId;
        public string selectedTrailerId;
        public bool showCustomers = false;
        public bool showTrailers = false;
        public bool showReservations = false;


        public DateTime startDateTime;
        public DateTime endDateTime;

        public string showModel = "";


        public List<Extraservice> availableExtraServices;

   
        public DataManager(string id) : base(id)
        {
            string[] storeID = dBService.SendQuery("*", "store", "store_id", id);
            GetData();
        }

        public void GetData()
        {
            GetTrailers();
            GetExtraservice();
            GetReservation();
            GetCustmomer();
        }

        public void ShowCustomers()
        {
            showCustomers = true;
            showTrailers = false;
            showReservations = false;
        }
        public void ShowTrailers()
        {
            showCustomers = false;
            showTrailers = true;
            showReservations = false;
        }
        public void ShowReservations()
        {
            showCustomers = false;
            showTrailers = false;
            showReservations = true;
        }
  
        }
    }

