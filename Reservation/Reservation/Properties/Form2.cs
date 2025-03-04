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

namespace Reservation
{
    public partial class Form2 : Form
    {
        DataManager dataManager;

        public Form2(DataManager dataManager)
        {
            InitializeComponent();
            this.dataManager = dataManager;

            pictureBox8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Resize += Form1_Resize;
            Form1_Resize(this, EventArgs.Empty);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float formWidth = this.ClientSize.Width;
            float formHeight = this.ClientSize.Height;
            double gap = formWidth * 0.015;
            double gapY = formHeight * 0.1;
            double numPictureBoxes = 3;
            double pictureBoxratio = 0.30;
            double pictureBoxratio2 = 0.2;

            int pictureBoxWidth = (int)((formWidth - (numPictureBoxes + 1) * gap) / numPictureBoxes);


            //boat trailer
            pictureBox1.Width = pictureBoxWidth;
            pictureBox1.Height = (int)(formHeight * pictureBoxratio);
            pictureBox1.Left = (int)((formWidth - pictureBox1.Width - gap));
            pictureBox1.Top = (int)((formHeight - pictureBox1.Height - gapY));
            //Small trailer
            pictureBox8.Width = pictureBoxWidth;
            pictureBox8.Height = (int)(formHeight * pictureBoxratio);
            pictureBox8.Left = (int)((formWidth - (pictureBox1.Width + pictureBox1.Width ) - gap * 2));
            pictureBox8.Top = (int)((formHeight - pictureBox1.Height - gapY));

            //Large trailer
            pictureBox3.Width = pictureBoxWidth;
            pictureBox3.Height = (int)(formHeight * pictureBoxratio);
            pictureBox3.Left = (int)((formWidth - (pictureBox3.Width + pictureBox8.Width + pictureBox1.Width )- gap * 3));
            pictureBox3.Top = (int)((formHeight - pictureBox3.Height - gapY));

            //Reservation
            pictureBox4.Width = (int)(formWidth / 3);
            pictureBox4.Height = (int)(formHeight * pictureBoxratio2);
            pictureBox4.Left = (int)((formWidth - pictureBox4.Width));
            pictureBox4.Top = (int)(0);

            //customers
            pictureBox5.Width = (int)(formWidth / 3);
            pictureBox5.Height = (int)(formHeight * pictureBoxratio2);
            pictureBox5.Left = (int)((formWidth - (pictureBox5.Width + pictureBox4.Width)));
            pictureBox5.Top = (int)(0);

            //ttrailer
            pictureBox6.Width = (int)(formWidth / 3);
            pictureBox6.Height = (int)(formHeight * pictureBoxratio2);
            pictureBox6.Left = (int)((formWidth - (pictureBox6.Width + pictureBox5.Width + pictureBox4.Width)));
            pictureBox6.Top = (int)(0);

            //pictureBox7.Width = (int)(formWidth * 0.35);
            //pictureBox7.Height = (int)(formHeight * pictureBoxratio);
            //pictureBox7.Left = (int)((formWidth - (pictureBox3.Width + pictureBox2.Width + pictureBox1.Width) - gap * 3));
            //pictureBox7.Top = (int)((pictureBox1.Height - formHeight * 0.1));

        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            dataManager.showModel = "L";
            Form3 form3 = new Form3(dataManager);
            form3.Show();
            this.Hide();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataManager.showModel = "B";

            Form3 form3 = new Form3(dataManager);
            form3.Show();
            this.Hide();

        }
 
        private void pictureBox4_Click(object sender, EventArgs e)
        {

            dataManager.ShowReservations();
            Form5 form5 = new Form5(dataManager);
            form5.Label1Text = "Reservations";


            form5.Show();
            this.Hide();
            //show reservatíons
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            dataManager.ShowCustomers();
            Form5 form5 = new Form5(dataManager);
            form5.Label1Text = "Customers";

            form5.Show();
            this.Hide();
            //show reservatíons
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
  

            dataManager.ShowTrailers();
            Form5 form5 = new Form5(dataManager);
           
            form5.Label1Text = "Trailers";
            form5.Show();
            this.Hide();
            //show trailers
        }
        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            dataManager.showModel = "S";

            Form3 form3 = new Form3(dataManager);
            form3.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            dataManager.showModel = "L";

            Form3 form3 = new Form3(dataManager);
            form3.Show();
            this.Hide();
        }
    }
}

