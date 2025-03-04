using MySqlConnector;
using Reservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservation
{
    public partial class Form4 : Form
    {
        public int rope = 0;
        public int hardcover = 0;
        public int softcover = 0;
        int rope_ = 0;
        int hardcover_ = 0;
        int softcover_ = 0;
        DataManager dataManager;


        public Form4(DataManager dataManager)
        {
            InitializeComponent();
            this.dataManager = dataManager;

            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Resize += Form1_Resize;
            Form1_Resize(this, EventArgs.Empty);


            foreach (Extraservice extraservice in dataManager.availableExtraServices)
            {
                if (extraservice.type == "Ropes")
                {
                    rope_++;
                }
                if (extraservice.type == "Cover" && extraservice.size == "S")
                {
                    softcover_++;
                }
                if (extraservice.type == "Cover" && extraservice.size == "L")
                {
                    hardcover_++;
                }
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


            //add hard cover
            pictureBox2.Width = (int)(pictureBoxWidth * 0.5);
            pictureBox2.Height = (int)(formHeight * pictureBoxratio);
            pictureBox2.Left = (int)((0 + gap * 19));
            pictureBox2.Top = (int)((0 + gapY * 1.5));
            ////////Add soft cover
            pictureBox3.Width = (int)(pictureBoxWidth * 0.5);
            pictureBox3.Height = (int)(formHeight * pictureBoxratio);
            pictureBox3.Left = (int)((0 + gap * 19));
            pictureBox3.Top = (int)((0 + gapY * 4.5));

            ////////Add rope
            pictureBox4.Width = (int)(pictureBoxWidth * 0.5);
            pictureBox4.Height = (int)(formHeight * pictureBoxratio);
            pictureBox4.Left = (int)((0 + gap * 19));
            pictureBox4.Top = (int)((0 + gapY * 7));

            ////////Checkout
            pictureBox5.Width = (int)(pictureBoxWidth * 0.9);
            pictureBox5.Height = (int)(formHeight * pictureBoxratio);
            pictureBox5.Left = (int)((formWidth - pictureBox5.Width - gap * 2));
            pictureBox5.Top = (int)((formHeight - pictureBox5.Height - gapY));
            ////////fulltname
            textBox2.Width = (int)(pictureBoxWidth * 1.25);
            textBox2.Height = (int)(formHeight * pictureBoxratio);
            textBox2.Left = (int)((formWidth / 2 ));
            textBox2.Top = (int)((formHeight - pictureBox5.Height - gapY*3));

            ////////number
            textBox5.Width = (int)(pictureBoxWidth * 1.25);
            textBox5.Height = (int)(formHeight * pictureBoxratio);
            textBox5.Left = (int)((formWidth / 2));
            textBox5.Top = (int)((formHeight + (textBox2.Height * 1.4) - pictureBox5.Height - gapY * 3 ));
            //email
            textBox4.Width = (int)(pictureBoxWidth * 1.25);
            textBox4.Height = (int)(formHeight * pictureBoxratio);
            textBox4.Left = (int)((formWidth / 2));
            textBox4.Top = (int)((formHeight + ((textBox2.Height * 1.4)* 2 )- pictureBox5.Height - gapY * 3));
            //add hardcover count
            label3.Width = (int)(pictureBoxWidth * 0.5);
            label3.Height = (int)(formHeight * pictureBoxratio);
            label3.Left = (int)((0 + gap * 20));
            label3.Top = (int)((0 + gapY * 1.75));
            //add softcover count
            label2.Width = (int)(pictureBoxWidth * 0.5);
            label2.Height = (int)(formHeight * pictureBoxratio);
            label2.Left = (int)((0 + gap * 20));
            label2.Top = (int)((0 + gapY * 4.76));
            //add robe count
            label1.Width = (int)(pictureBoxWidth * 0.5);
            label1.Height = (int)(formHeight * pictureBoxratio);
            label1.Left = (int)((0 + gap * 20));
            label1.Top = (int)((0 + gapY * 7.24));
            //clear
            pictureBox7.Width = (int)(pictureBoxWidth * 0.3);
            pictureBox7.Height = (int)(formHeight * pictureBoxratio);
            pictureBox7.Left = (int)((0 + gap * 20));
            pictureBox7.Top = (int)((0 + gapY * 9));
        }
    

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (hardcover_ == 0 || dataManager.showModel == "B")
            { label4.Text = "Hardcover not available"; return; }
            rope = 0;
            softcover = 0;
            hardcover = 1;
            label1.Text = rope.ToString();
            label2.Text = softcover.ToString();
            label3.Text = hardcover.ToString();
            label6.Text = null;
            label5.Text = null;
            label4.Text = null;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox7_Click(object sender, EventArgs e)
        {
            rope = 0;
            softcover = 0;
            hardcover = 0;
            label1.Text = rope.ToString();
            label2.Text = softcover.ToString();
            label3.Text = hardcover.ToString();
            label6.Text = null;
            label5.Text = null;
            label4.Text = null;

        }

        private void label3_Click(object sender, EventArgs e)
        {
        
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (rope_ == rope )
            { label6.Text = "No more robes available"; return; }
            rope = 1;
            softcover = 0;
            hardcover = 0;
            label1.Text = rope.ToString();
            label2.Text = softcover.ToString();
            label3.Text = hardcover.ToString();
            label6.Text = null;
            label5.Text = null;
            label4.Text = null;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (softcover_ == 0 || dataManager.showModel == "B")
            { label4.Text = "Softcover not available"; return; }
            rope = 0;
            softcover = 1;
            hardcover = 0;
            label1.Text = rope.ToString();
            label2.Text = softcover.ToString();
            label3.Text = hardcover.ToString();
            label6.Text = null;
            label5.Text = null;
            label4.Text = null;
        }


        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            


                if (textBox2.Text != "Full name*" && textBox5.Text != "Phone number*" && textBox4.Text != "Address*")
                {
                    DBService dBService = new DBService();
                    dBService.Open();

                    int customerId;

                    // if customer is already in db
                    using (MySqlCommand checkNameCmd = new MySqlCommand())
                    {
                        checkNameCmd.Connection = dBService.myConnection;
                        checkNameCmd.CommandText = "SELECT Customer_id FROM customer WHERE name = @name";
                        checkNameCmd.Parameters.AddWithValue("@name", textBox2.Text);

                        object result = checkNameCmd.ExecuteScalar();

                        if (result != null && !Convert.IsDBNull(result))
                        {
                            customerId = Convert.ToInt32(result);
                        }
                        else
                        {
                            // new one 
                            using (MySqlCommand insertCmd = new MySqlCommand())
                            {
                                insertCmd.Connection = dBService.myConnection;
                                insertCmd.CommandText = "INSERT INTO customer(name, phone_num, adresse, social_sec_num) VALUES (@name, @phone, @adresse, @social); SELECT LAST_INSERT_ID();";

                                insertCmd.Parameters.AddWithValue("@name", textBox2.Text);
                                insertCmd.Parameters.AddWithValue("@phone", textBox5.Text);
                                insertCmd.Parameters.AddWithValue("@adresse", textBox4.Text);
                                insertCmd.Parameters.AddWithValue("@social", ":)");

                                customerId = Convert.ToInt32(insertCmd.ExecuteScalar());
                            }
                        }
                    }

                    using (MySqlCommand insertReservationCmd = new MySqlCommand())
                        {
                            insertReservationCmd.Connection = dBService.myConnection;
                            insertReservationCmd.CommandText = "INSERT INTO reservation(start_time, end_time, customer_id, trailer_id, extraservice_id) VALUES (@start_time, @end_time, @customer_id, @trailer_id, @extraservice_id); SELECT LAST_INSERT_ID();";
                            insertReservationCmd.Parameters.AddWithValue("@start_time", dataManager.startDateTime);
                            insertReservationCmd.Parameters.AddWithValue("@end_time", dataManager.endDateTime);
                            insertReservationCmd.Parameters.AddWithValue("@customer_id", customerId);
                            insertReservationCmd.Parameters.AddWithValue("@trailer_id", dataManager.selectedTrailerId);

                    int extraservice_id = -1;
                    foreach (Extraservice extraservice in dataManager.availableExtraServices)
                    {
                        if (rope == 1 && extraservice.type == "Ropes")
                        {
                            extraservice_id = extraservice.id;
                        }

                        if (softcover == 1 && extraservice.type == "Cover" && extraservice.size == "S")
                        {
                            extraservice_id = extraservice.id;
                        }

                        if (hardcover == 1 && extraservice.type == "Cover" && extraservice.size == "L")
                        {
                            extraservice_id = extraservice.id;
                        }
                    }

                    if (extraservice_id != -1)
                            {
                                insertReservationCmd.Parameters.AddWithValue("@extraservice_id", extraservice_id);
                            }
                            else
                            {
                            }
                        

                    int reservationId = Convert.ToInt32(insertReservationCmd.ExecuteScalar());

                        }

                    dBService.Close();


                string id = dataManager.cityId;
                dataManager.GetData(); 
                Form2 form2 = new Form2(dataManager);
                form2.Show();
                this.Hide();

            }
            }
        }
    }










