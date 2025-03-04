using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Customer : DBService
    {
        DBService dBService = new DBService();


        public string name { get; private set; }


        public Customer(string trailer_id)
        {
            string[] trailerData = dBService.SendQuery("*", "customer", "customer_id", trailer_id);

            name = trailerData[1];

            Debug.WriteLine(name);
        }

        public override string ToString()
        {
            return name;
        }

        public void Addcustomer(string name, string address, string phone, int id, string social)
        {




            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "INSERT INTO customer(Customer_id,name,phone_num,address,social_sec_num) VALUES (@id, @name, @phone, @address, @social)";

            myCommand.Parameters.AddWithValue("@id", id);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@phone", phone);
            myCommand.Parameters.AddWithValue("@address", address);
            myCommand.Parameters.AddWithValue("@social", social);
            myCommand.ExecuteNonQuery();

            //myConnection.Open();

        }


        public void Updatecustomer(string name, string address, string phone, int id)
        {




            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "UPDATE customer SET CusName = @name, CusPhone = @phone, CusAddress = @address WHERE CusID = @id ";

            myCommand.Parameters.AddWithValue("@id", id);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@phone", phone);
            myCommand.Parameters.AddWithValue("@address", address);
            myCommand.ExecuteNonQuery();




        }

        ////public string GetCusinfo(int id)
        ////{
        ////    MySqlCommand myCommand = new MySqlCommand();
        ////    myCommand.Connection = myConnection;
        ////    return GetDoubleValueFromDB("*", "customer", "Customer_id",id.ToString());


        ////}
        //public string[] GetAllCusinfo(int id)
        //{
        //    string idstring = id.ToString();
        //    MySqlCommand myCommand = new MySqlCommand();
        //    myCommand.Connection = myConnection;
        //  string[] array = GetDoubleValueFromDB("*" + "customer", "Customer_id", idstring);
        //    return GetDoubleValueFromDB("customer", "Customer_id", id.ToString());
        //}



    }
}
