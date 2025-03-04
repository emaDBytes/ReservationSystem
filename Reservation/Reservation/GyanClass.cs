using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MySqlConnector;



namespace Reservation
{
    public class DBService
    {
        public MySqlConnection myConnection;



        public DBService()
        {
        }
        public void Open()
        {
            OpenConnection();
        }

        public void Close()
        {
            myConnection.Close();
        }

        public void BuildDB()
        {
            ExecuteNonQueryScript("DROP DATABASE IF EXISTS trailer_park;\r\nCREATE DATABASE trailer_park;\r\nUSE trailer_park; \r\nSET SQL_MODE = \"NO_AUTO_VALUE_ON_ZERO\";\r\nSTART TRANSACTION;\r\nSET time_zone = \"+00:00\";\r\n\r\n\r\n/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;\r\n/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;\r\n/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;\r\n/*!40101 SET NAMES utf8mb4 */;\r\n\r\n--\r\n-- Database: `trailer_park`\r\n--\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Table structure for table `customer`\r\n--\r\n\r\nCREATE TABLE `customer` (\r\n  `customer_id` tinyint(4) NOT NULL,\r\n  `name` varchar(15) DEFAULT NULL,\r\n  `phone_num` int(11) DEFAULT NULL,\r\n  `adresse` varchar(16) DEFAULT NULL,\r\n  `social_sec_num` varchar(11) DEFAULT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;\r\n\r\n--\r\n-- Dumping data for table `customer`\r\n--\r\n\r\nINSERT INTO `customer` (`customer_id`, `name`, `phone_num`, `adresse`, `social_sec_num`) VALUES\r\n(1, 'Juha Gustafsson', 401234567, 'Juhankatu 3 A 13', '030995-123A'),\r\n(2, 'Eric Example', 44293469, 'Kuja 5', ':)'),\r\n(3, 'Tessa Testikko', 5069383, 'Street 7', ':)'),\r\n(4, 'Micheal Morocco', 44298503, 'Gatan 4', ':)');\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Table structure for table `extraservice`\r\n--\r\n\r\nCREATE TABLE `extraservice` (\r\n  `extraservice_id` tinyint(4) NOT NULL,\r\n  `Type` varchar(5) DEFAULT '-',\r\n  `Size` varchar(1) DEFAULT NULL,\r\n  `ref_store_id` tinyint(4) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;\r\n\r\n--\r\n-- Dumping data for table `extraservice`\r\n--\r\n\r\nINSERT INTO `extraservice` (`extraservice_id`, `Type`, `Size`, `ref_store_id`) VALUES\r\n(1, 'Cover', 'S', 1),\r\n(2, 'Cover', 'S', 0),\r\n(3, 'Cover', 'S', 0),\r\n(4, 'Cover', 'S', 0),\r\n(5, 'Cover', 'L', 1),\r\n(6, 'Cover', 'L', 1),\r\n(7, 'Cover', 'L', 0),\r\n(8, 'Cover', 'L', 0),\r\n(9, 'Ropes', '-', 1),\r\n(10, 'Ropes', '-', 1),\r\n(11, 'Ropes', '-', 1),\r\n(12, 'Ropes', '-', 1),\r\n(13, 'Ropes', '-', 1),\r\n(14, 'Ropes', '-', 0),\r\n(15, 'Ropes', '-', 0),\r\n(16, 'Ropes', '-', 0),\r\n(17, 'Ropes', '-', 0),\r\n(18, 'Ropes', '-', 0);\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Table structure for table `reservation`\r\n--\r\n\r\nCREATE TABLE `reservation` (\r\n  `reservation_id` tinyint(4) NOT NULL,\r\n  `start_time` datetime DEFAULT NULL,\r\n  `end_time` datetime DEFAULT NULL,\r\n  `customer_id` int(6) NOT NULL,\r\n  `trailer_id` int(3) NOT NULL,\r\n  `extraservice_id` int(5) DEFAULT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;\r\n\r\n--\r\n-- Dumping data for table `reservation`\r\n--\r\n\r\nINSERT INTO `reservation` (`reservation_id`, `start_time`, `end_time`, `customer_id`, `trailer_id`, `extraservice_id`) VALUES\r\n(1, '2023-03-29 00:00:00', '2023-03-09 00:00:00', 1, 5, 9),\r\n(2, '2023-04-01 00:00:00', '2023-04-02 00:00:00', 1, 2, 9),\r\n(3, '2023-04-01 00:00:00', '2023-04-03 00:00:00', 1, 1, 9),\r\n(4, '2023-04-12 01:50:30', '2023-04-23 15:28:07', 2, 5, 4),\r\n(5, '2023-04-12 01:50:30', '2023-04-23 15:28:33', 3, 6, 8),\r\n(6, '2023-04-12 01:50:30', '2023-05-28 15:29:20', 4, 18, 18);\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Table structure for table `reservation_extraservice`\r\n--\r\n\r\nCREATE TABLE `reservation_extraservice` (\r\n  `reservation_id` tinyint(4) NOT NULL,\r\n  `extraservice_id` int(11) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Table structure for table `robes`\r\n--\r\n\r\nCREATE TABLE `robes` (\r\n  `robe_id` int(11) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;\r\n\r\n--\r\n-- Dumping data for table `robes`\r\n--\r\n\r\nINSERT INTO `robes` (`robe_id`) VALUES\r\n(1),\r\n(2),\r\n(3),\r\n(4),\r\n(5),\r\n(6),\r\n(7),\r\n(8),\r\n(9);\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Table structure for table `store`\r\n--\r\n\r\nCREATE TABLE `store` (\r\n  `store_id` tinyint(4) DEFAULT NULL,\r\n  `address` varchar(14) DEFAULT NULL,\r\n  `city` varchar(11) DEFAULT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;\r\n\r\n--\r\n-- Dumping data for table `store`\r\n--\r\n\r\nINSERT INTO `store` (`store_id`, `address`, `city`) VALUES\r\n(0, 'Mukkulankatu 3', 'Lahti'),\r\n(1, 'Mikonkatu 9', 'Lappeeranta');\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Table structure for table `trailer`\r\n--\r\n\r\nCREATE TABLE `trailer` (\r\n  `trailer_id` tinyint(4) DEFAULT NULL,\r\n  `register` varchar(7) DEFAULT NULL,\r\n  `model` varchar(1) DEFAULT NULL,\r\n  `ref_store_id` tinyint(4) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;\r\n\r\n--\r\n-- Dumping data for table `trailer`\r\n--\r\n\r\nINSERT INTO `trailer` (`trailer_id`, `register`, `model`, `ref_store_id`) VALUES\r\n(2, 'ABC-222', 'S', 1),\r\n(3, 'ABC-333', 'S', 1),\r\n(4, 'ABC-444', 'S', 0),\r\n(5, 'ABC-555', 'S', 0),\r\n(6, 'ABC-666', 'S', 0),\r\n(7, 'DEF-111', 'L', 1),\r\n(8, 'DEF-222', 'L', 1),\r\n(9, 'DEF-333', 'L', 1),\r\n(10, 'DEF-444', 'L', 0),\r\n(11, 'DEF-555', 'L', 0),\r\n(12, 'DEF-666', 'L', 0),\r\n(13, 'GHI-111', 'B', 1),\r\n(14, 'GHI-222', 'B', 1),\r\n(15, 'GHI-333', 'B', 1),\r\n(16, 'GHI-444', 'B', 0),\r\n(17, 'GHI-555', 'B', 0),\r\n(18, 'GHI-666', 'B', 0),\r\n(1, 'ABC-111', 'S', 1);\r\n\r\n--\r\n-- Indexes for dumped tables\r\n--\r\n\r\n--\r\n-- Indexes for table `customer`\r\n--\r\nALTER TABLE `customer`\r\n  ADD PRIMARY KEY (`customer_id`);\r\n\r\n--\r\n-- Indexes for table `extraservice`\r\n--\r\nALTER TABLE `extraservice`\r\n  ADD PRIMARY KEY (`extraservice_id`);\r\n\r\n--\r\n-- Indexes for table `reservation`\r\n--\r\nALTER TABLE `reservation`\r\n  ADD PRIMARY KEY (`reservation_id`);\r\n\r\n--\r\n-- Indexes for table `reservation_extraservice`\r\n--\r\nALTER TABLE `reservation_extraservice`\r\n  ADD PRIMARY KEY (`reservation_id`,`extraservice_id`);\r\n\r\n--\r\n-- Indexes for table `robes`\r\n--\r\nALTER TABLE `robes`\r\n  ADD PRIMARY KEY (`robe_id`);\r\n\r\n--\r\n-- AUTO_INCREMENT for dumped tables\r\n--\r\n\r\n--\r\n-- AUTO_INCREMENT for table `customer`\r\n--\r\nALTER TABLE `customer`\r\n  MODIFY `customer_id` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;\r\n\r\n--\r\n-- AUTO_INCREMENT for table `extraservice`\r\n--\r\nALTER TABLE `extraservice`\r\n  MODIFY `extraservice_id` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;\r\n\r\n--\r\n-- AUTO_INCREMENT for table `reservation`\r\n--\r\nALTER TABLE `reservation`\r\n  MODIFY `reservation_id` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;\r\n\r\n--\r\n-- AUTO_INCREMENT for table `robes`\r\n--\r\nALTER TABLE `robes`\r\n  MODIFY `robe_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;\r\nCOMMIT;\r\n\r\n/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;\r\n/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;\r\n/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;\r\n");

        }

        public void OpenConnection()
        {
            string connstr;
            //string server = "localhost"; //ServerName 
            //string database = "trailer_park";  //Database name from workbench using MySQL
            //string username = "";
            //string password = "admin";
            connstr = "server=localhost;database=trailer_park;uid=root;password=;Allow User Variables=true";
            myConnection = new MySqlConnection();
            myConnection.ConnectionString = connstr;
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Opening Database Connection");
            }
        }

        public void Addcustomer(string name, string address, string phone, int id,  string social)
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

            // myConnection.Open();

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


        //public string GetDoubleValueFromDB( string from, string where, string rule)
        //{
        //    MySqlCommand myCommand = new MySqlCommand();
        //    myCommand.Connection = myConnection;

        //    string mycommand = "SELECT *  FROM " + from + " WHERE " + where + " = " + rule;
        //    return GetData(mycommand);
        //}

        //public string GetDoubleValueFromDB(string what, string from, string where, string rule)
        //{
        //    MySqlCommand myCommand = new MySqlCommand();
        //    myCommand.Connection = myConnection;

        //    string mycommand = "SELECT " + what + " FROM " + from + " WHERE " + where + " = " + rule;
        //    return GetData(mycommand, what);
        //}

        public string[] SendQuery(string select, string from, string where, string rule)
        {
            //$query = "SELECT * FROM buyer";
            string mycommand = "SELECT " + select + " FROM " + from + " WHERE " + where + " = '" + rule + "'";
            return GetData(mycommand);
        }

        //Gets the whole table 
        public string[] SendQuery(string from)
        {

            string mycommand = "SELECT *  FROM " + from;
            return GetData(mycommand);
        }
        public string[] SendQuery(string quary, bool tru)
        {

            string mycommand = quary;
            return GetData(mycommand);
        }

        private string[] GetData(string query)
        {
            Open();
            //Using "using" automatically closes the connection and has some performance benefits
            using (MySqlCommand myCommand = new MySqlCommand(query, myConnection))
            {
                string retstr = "";

                using (MySqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                        {
                        for (int i = 0; i < myReader.FieldCount; i++)
                            {
                            retstr += myReader[i].ToString() + "\t";
                            }
                        retstr += "\n";
                        }

                    if (retstr == "") { Console.WriteLine("error: Quary returned empty"); return null; }
                    string[] stuff = retstr.Split('\t');
                    return stuff;


                }
 
            }

        }

        public void ExecuteNonQueryScript(string script)
        {
            Open();

            using (MySqlCommand myCommand = new MySqlCommand(script, myConnection))
            {
                myCommand.ExecuteNonQuery();
            }

            Close();
        }

    }


}


