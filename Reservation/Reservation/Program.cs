using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Reservation
{

    public class Program
    {
        //test
        // second comment for test
        static void Main(string[] args)
        {
            DBService db = new DBService();
            db.BuildDB();   
            //Customer customer = new Customer();
            ////db.Addcustomer("Gyan","mukkla","93939393",199,"030997-332R");
            //Console.WriteLine(customer.GetAllCusinfo(1));
            //Console.ReadKey();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Console.ReadLine();
        }
    }
}
