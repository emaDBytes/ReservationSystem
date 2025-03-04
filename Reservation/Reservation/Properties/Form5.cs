using Reservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Reservation
{
    public partial class Form5 : Form
    {
        DataManager dataManager;


        public Form5(DataManager dataManager)
        {
            InitializeComponent();
            this.dataManager = dataManager;


            this.Resize += Form1_Resize;
            Form1_Resize(this, EventArgs.Empty);
            label1.Font = new Font("Arial", 12, FontStyle.Bold);


            listBox1.DataSource = null;
            if (dataManager.showReservations == true)
            {
                listBox1.DataSource = dataManager.reservationList;
            }
            if (dataManager.showTrailers == true)
            {
                listBox1.DataSource = dataManager.trailersList;
            }
            if(dataManager.showCustomers == true)
            {
                listBox1.DataSource = dataManager.customerList;

            }


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float formWidth = this.ClientSize.Width;
            float formHeight = this.ClientSize.Height;
            double gap = formWidth * 0.015;
            double gapY = formHeight * 0.1;
            double numPictureBoxes = 3;
            double pictureBoxratio = 0.1;
            double pictureBoxratio2 = 0.4;

            int pictureBoxWidth = (int)((formWidth - (numPictureBoxes + 1) * gap) / numPictureBoxes);


            //Dashboard
            pictureBox2.Width = (int)(pictureBoxWidth * 0.9);
            pictureBox2.Height = (int)(formHeight * pictureBoxratio);
            pictureBox2.Left = (int)((0 + gap * 2));
            pictureBox2.Top = (int)((0 + gapY * 0.9));
            ////available trailers
            listBox1.Width = (int)(formWidth * 0.6);
            listBox1.Height = (int)(formHeight * 0.6);
            listBox1.Left = (int)((formWidth / 4));
            listBox1.Top = (int)((formHeight / 4));
            ////label
            label1.Width = (int)(formWidth * 0.6);
            label1.Height = (int)(formHeight * 0.6 );
            label1.Left = (int)((formWidth / 2));
            label1.Top = (int)((formHeight / 7));
        }
  
        public string Label1Text
        {
            get { return label1.Text; }
            set { label1.Text = value;
            }
        }
   
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataManager);
            form2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
