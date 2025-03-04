using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservation
{
    public partial class Mainform : Form
    {

        public Mainform()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

    }
}
