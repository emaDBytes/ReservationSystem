
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using System.Data.OleDb;


//namespace Reservation
//{
//    class HairdresserProgram
//    {
//        private DBService myDB;

//        public HairdresserProgram()
//        {
//            myDB = new DBService();
//        }

//        public void CloseProgram()
//        {
//            myDB.CloseDB();
//        }

//        public void AddNewCustomer(string name, string area)
//        {
//            myDB.AddNewCustomer(name, area);
//        }

//        public void RemoveCustomerByName(string name)
//        {
//            myDB.DeleteCustomer(name);
//        }

//        public double GetBalance(Customer customer)
//        {
//            string cID = customer.CustID;
//            return myDB.GetBalanceOfCustomer(cID);
//        }

//        public List<Customer> GetCustomers()
//        {
//            //DBService myDataBase = new DBService();
//            return myDB.ListAllCustomersSorted();
//        }

//        public string ListAllCustomers()
//        {
//            //DBService myDataBase = new DBService();
//            List<Customer> allCustomers = myDB.ListAllCustomersSorted();

//            StringBuilder custList = new StringBuilder();

//            foreach (Customer c in allCustomers)
//                custList.Append(c.ToString() + "\n");

//            return custList.ToString();
//        }
//    }

//    class Customer
//    {
//        private string name;
//        private string custID;

//        public Customer(string nm, string id)
//        {
//            name = nm;
//            custID = id;
//        }

//        public override string ToString()
//        {
//            return name + ": " + custID;
//        }
//        public string CustID
//        {
//            get { return custID; }
//        }

//        public string Name
//        {
//            get { return name; }
//        }

//    }

//    class DBService
//    {
//        private OleDbConnection myConnection;

//        public DBService()
//        {
//            OpenConnection();
//        }

//        public void CloseDB()
//        {
//            myConnection.Close();
//        }
//        private void OpenConnection()
//        {
//            string connstr;
//            string projectPath = @"..\..\Data\CustomerOrders2019.accdb;";

//            connstr = "Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = " + projectPath;

//            myConnection = new OleDbConnection();

//            myConnection.ConnectionString = connstr;
//            myConnection.Open();
//        }

//        private string FindValidNewCustId()
//        {
//            List<Customer> allCust = ListAllCustomers();
//            int proposedID = 0;
//            Boolean validFound = false;
//            while (!validFound)
//            {
//                proposedID++;
//                validFound = true;
//                foreach (Customer c in allCust)
//                {
//                    if (c.CustID == proposedID.ToString())
//                    {
//                        validFound = false;
//                        break;
//                    }
//                }
//            }
//            return proposedID.ToString();
//        }

//        public void AddNewCustomer(string name, string area)
//        {
//            AddNewCustomer(name, area, FindValidNewCustId());
//        }

//        private void AddNewCustomer(string name, string area, string id)
//        {
//            OleDbCommand myCommand = new OleDbCommand();
//            myCommand.Connection = myConnection;
//            myCommand.CommandText = "INSERT INTO Customer(CustID, Name, Area, Balance)" +
//                "VALUES ('" + id + "','" + name + "','" + area + "','0,0')";

//            myCommand.ExecuteNonQuery();
//        }


//        public double GetPriceOfProduct(string key)
//        {
//            return GetDoubleValueFromDB("Price", "Produt", "ProdID", key);
//        }


//        public double GetBalanceOfCustomer(string key)
//        {
//            return GetDoubleValueFromDB("Balance", "Customer", "CustID", key);
//        }

//        private double GetDoubleValueFromDB(string what, string from, string where, string rule)
//        {
//            string commandText = "SELECT " + what + " FROM " + from + " WHERE " + where + " = " + rule;
//            return GetSomeData(commandText, what);
//        }

//        private double GetSomeData(string query, string what)
//        {
//            OleDbCommand myCommand = new OleDbCommand();
//            myCommand.Connection = myConnection;

//            myCommand.CommandText = query;
//            myCommand.CommandType = CommandType.Text;

//            OleDbDataReader myReader;
//            myReader = myCommand.ExecuteReader();

//            Boolean NotEOF = myReader.Read();

//            double retVal = 0.0;

//            if (NotEOF)
//                retVal = Convert.ToDouble(myReader[what].ToString());

//            return retVal;
//        }

//        private OleDbDataReader GetReaderData(string query)
//        {
//            OleDbCommand myCommand = new OleDbCommand();
//            myCommand.Connection = myConnection;

//            myCommand.CommandText = query;
//            myCommand.CommandType = CommandType.Text;

//            OleDbDataReader myReader;
//            myReader = myCommand.ExecuteReader();

//            return myReader;
//        }


//        public void DeleteCustomer(string name)
//        {
//            if (CustomerNameExists(name))
//                DeleteRowFromTable("Customer", "Name", name);
//        }

//        private bool CustomerNameExists(string name)
//        {
//            foreach (Customer c in ListAllCustomers())
//                if (c.Name == name)
//                    return true;
//            return false;
//        }

//        private void DeleteRowFromTable(string from, string where, string rule)
//        {
//            string commandText = "DELETE FROM " + from + " WHERE " + where + " = '" + rule + "'";
//            OleDbCommand myCommand = new OleDbCommand();
//            myCommand.Connection = myConnection;
//            myCommand.CommandText = commandText;

//            myCommand.ExecuteNonQuery();

//        }


//        public List<Customer> ListAllCustomers()
//        {
//            OleDbDataReader myReader = GetReaderData("SELECT CustID, Name FROM Customer");

//            Boolean NotEOF = myReader.Read();

//            List<Customer> custList = new List<Customer>();

//            while (NotEOF)
//            {
//                //Console.WriteLine(myReader["Name"].ToString() + ": " + myReader["CustID"].ToString());
//                custList.Add(new Customer(myReader["Name"].ToString(), myReader["CustID"].ToString()));
//                NotEOF = myReader.Read();
//            }

//            return custList;
//        }

//        public List<Customer> ListAllCustomersSorted()
//        {
//            OleDbDataReader myReader = GetReaderData("SELECT CustID, Name FROM Customer ORDER BY CustID");

//            Boolean NotEOF = myReader.Read();

//            List<Customer> custList = new List<Customer>();

//            while (NotEOF)
//            {
//                //Console.WriteLine(myReader["Name"].ToString() + ": " + myReader["CustID"].ToString());
//                custList.Add(new Customer(myReader["Name"].ToString(), myReader["CustID"].ToString()));
//                NotEOF = myReader.Read();
//            }

//            return custList;
//        }

//    }

//    class UI
//    {
//        private HairdresserProgram myHairDresserProgram;

//        private void ListAllCustomers()
//        {
//            Console.WriteLine("Currently in the customer list we have:");
//            Console.WriteLine(myHairDresserProgram.ListAllCustomers());
//        }


//        private void AddNewCustomers()
//        {
//            while (true)
//            {
//                Console.WriteLine("With this program you can add new customer into the database");
//                Console.WriteLine("Currently in the customer list we have:");
//                Console.WriteLine(myHairDresserProgram.ListAllCustomers());

//                Console.WriteLine("Please enter the name of the new customer:");
//                string name = Console.ReadLine();

//                Console.WriteLine("Please enter the area of the new customer (north, south, west, east):");
//                string area = Console.ReadLine();

//                myHairDresserProgram.AddNewCustomer(name, area);
//                Console.WriteLine("***********************************");
//                Console.WriteLine("Currently in the customer list we have:");
//                Console.WriteLine(myHairDresserProgram.ListAllCustomers());

//                Console.WriteLine("***********************************");
//                Console.WriteLine("Do you want to continue adding new customers? (Y/N)");
//                string cont = Console.ReadLine();
//                if (cont != "Y")
//                    break;

//                Console.Clear();
//            }
//        }

//        public void Run()
//        {
//            myHairDresserProgram = new HairdresserProgram();
//            while (true)
//            {
//                Console.WriteLine("With this program you can:");
//                Console.WriteLine("A. List all customers in the database");
//                Console.WriteLine("B. Add a new customer in the database");
//                Console.WriteLine("What do you want to do? (A/B)");

//                string command = Console.ReadLine();

//                switch (command)
//                {
//                    case "A":
//                        ListAllCustomers();
//                        break;
//                    case "B":
//                        AddNewCustomers();
//                        break;
//                    default:
//                        Console.WriteLine("Invalid selection, do you want to end the program (Y/N)?");
//                        if (Console.ReadLine() == "Y")
//                            return;
//                        break;
//                }
//            }
//        }
//    }

//    //class Program
//    //{
//    //    static void Main(string[] args)
//    //    {
//    //        UI myUI = new UI();
//    //        myUI.Run();
//    //    }
//    //}
//}