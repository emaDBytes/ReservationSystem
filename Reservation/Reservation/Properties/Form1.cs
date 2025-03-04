using Reservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Reservation
{


    public partial class Form1 : Form
    {
        public event EventHandler Button1Clicked;
        public event EventHandler Button2Clicked;
        public Form1()
        {
            InitializeComponent();
            

            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            button1.Text = "Lahti";
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.Font = new Font("Arial", 12, FontStyle.Bold);

       
            button2.Text = "Lappeenranta";
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            button2.Font = new Font("Arial", 12, FontStyle.Bold);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            Store store = new Store("0");
            DataManager dataManager = new DataManager("0");

            Form2 form2 = new Form2(dataManager);
            form2.Show();
            this.Hide();
            //lahti default 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataManager dataManager = new DataManager("1");
            Form2 form2 = new Form2(dataManager);
            form2.Show();
            this.Hide();
            //lappeenranta
        }
    }
}