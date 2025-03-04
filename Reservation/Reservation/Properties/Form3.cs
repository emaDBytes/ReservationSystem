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

namespace Reservation
{
    public partial class Form3 : Form
    {
        DataManager dataManager;
        DBService dbService = new DBService();
        List<Trailer> trailerList;


        public Form3(DataManager dataManager)
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.Items.Clear();

            this.dataManager = dataManager;
            this.trailerList = dataManager.trailersList;

            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            listBox1.BackColor = Color.White;
            listBox1.ForeColor = Color.Black;
            listBox1.Font = new Font("Arial", 12);

            this.Resize += Form1_Resize;
            Form1_Resize(this, EventArgs.Empty);
            this.dataManager = dataManager;
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
            pictureBox2.Left = (int)((0 + gap*2));
            pictureBox2.Top = (int)((0 + gapY));
            ////Reservations
            dateTimePicker1.Width = (int)(pictureBoxWidth * 1);
            dateTimePicker1.Height = (int)(formHeight * pictureBoxratio);
            dateTimePicker1.Left = (int)((0 + gap * 2));
            dateTimePicker1.Top = (int)((0 + pictureBox2.Height + gapY *2.45));

            ////Customer
            dateTimePicker2.Width = (int)(pictureBoxWidth * 1);
            dateTimePicker2.Height = (int)(formHeight * pictureBoxratio);
            dateTimePicker2.Left = (int)((0 + gap * 2));
            dateTimePicker2.Top = (int)((0 + pictureBox2.Height + gapY * 3.6));

            ////Small trailer
            pictureBox1.Width = (int)(formWidth / 2.5);
            pictureBox1.Height = (int)(formHeight * pictureBoxratio2);
            pictureBox1.Left = (int)((formWidth / 2 ));
            pictureBox1.Top = (int)(formHeight / 2 - pictureBox1.Height / 2);

            ////available trailers
            listBox1.Width = (int)(formWidth / 2.5 * 0.6);
            listBox1.Height = (int)(formHeight * pictureBoxratio2 * 0.55);
            listBox1.Left = (int)((formWidth / 2) * 1.1);
            listBox1.Top = (int)((formHeight / 2 - pictureBox1.Height / 2) * 1.3);

            ////boat trailer
            pictureBox4.Width = (int)(pictureBoxWidth * 0.9);
            pictureBox4.Height = (int)(formHeight * pictureBoxratio);
            pictureBox4.Left = (int)((formWidth - pictureBox4.Width - gap * 2));
            pictureBox4.Top = (int)((formHeight - pictureBox4.Height - gapY));

            //pictureBox7.Width = (int)(formWidth * 0.35);
            //pictureBox7.Height = (int)(formHeight * pictureBoxratio);
            //pictureBox7.Left = (int)((formWidth - (pictureBox3.Width + pictureBox2.Width + pictureBox1.Width) - gap * 3));
            //pictureBox7.Top = (int)((pictureBox1.Height - formHeight * 0.1));

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2_ValueChanged(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataManager);
            form2.Show();
            this.Hide();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDateTime = dateTimePicker1.Value;
            DateTime endDateTime = dateTimePicker2.Value;
            dataManager.GetReservation();
            List<Reservation> reservationList = dataManager.reservationList;
            DateTime today = DateTime.Today;
            listBox1.Items.Clear();
            label1.Text = null;
            listBox1.SelectedIndex = -1;

            HashSet<int> reservedTrailers = new HashSet<int>();
            if (startDateTime > endDateTime)
            {
                label1.Text = "incorrect date";
                return;
            }

            // Fetch all extra services from the database
            List<Extraservice> extraServiceList = dataManager.extraserviceList; // Replace this with the actual call to fetch extra services from the database.

            HashSet<int> reservedExtraServices = new HashSet<int>();
            foreach (Reservation res in reservationList)
            {
                int extraServiceID = res.extraservice_id;
                DateTime resStartTime = res.start_time;
                DateTime resEndTime = res.end_time;
                Console.WriteLine(resEndTime.ToString());

                if ((resStartTime >= startDateTime && resStartTime <= endDateTime) ||
                    (resEndTime >= startDateTime && resEndTime <= endDateTime) ||
                    (resStartTime <= startDateTime && resEndTime >= endDateTime))
                {
                    reservedTrailers.Add(res.trailer_id);
                    reservedExtraServices.Add(extraServiceID);
                }
            }

            List<Trailer> availableTrailers = trailerList.Where(t => !reservedTrailers.Contains(t.id)).ToList();
            List<Trailer> modelTrailers = availableTrailers.Where(t => t.model == dataManager.showModel).ToList();
            dataManager.startDateTime = startDateTime;
            dataManager.endDateTime = endDateTime;

            listBox1.Items.Clear();
            foreach (Trailer trailer in modelTrailers)
            {
                listBox1.Items.Add(trailer.ToString());
            }

            // Get available extra services
            List<Extraservice> availableExtraService = extraServiceList.Where(es => !reservedExtraServices.Contains(es.id)).ToList();
            dataManager.availableExtraServices = availableExtraService;

        }




        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTrailer = listBox1.SelectedItem.ToString();
            string[] split = selectedTrailer.Split(' ');
            if (split.Length > 1)
            {
                dataManager.selectedTrailerId = split[2]; 
                Console.WriteLine(split[2]);
            }
            else
            {
            }


        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataManager);
            form2.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (dataManager.selectedTrailerId != null) 
            { 
            Form4 form4 = new Form4(dataManager);
            form4.Show();
            this.Hide();
            }
            else
            {
                label1.Text = "Pick a trailer to continue";
            }
        }
    }
}
