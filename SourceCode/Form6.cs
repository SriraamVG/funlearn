using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        string tb2, tb3, tb4, tb5;

        public Form6()
        {
            InitializeComponent();
            //   comboBox1.Items.Add(textBox2.Text);
            //   comboBox1.Items.Add(textBox3.Text);
            //   comboBox1.Items.Add(textBox4.Text);
            //   comboBox1.Items.Add(textBox5.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panel2.Enabled = true;
                panel1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   comboBox1.Items.Add(textBox2.Text);
         //   comboBox1.Items.Add(textBox3.Text);
         //   comboBox1.Items.Add(textBox4.Text);
         //   comboBox1.Items.Add(textBox5.Text);
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || comboBox1.Text.Length == 0)
                {
                    MessageBox.Show("Donot leave any field empty!! \n To add the text field to the drop down box , press the button next to the corresponding textbox ");
                }
                else
                {
                    try
                    {
                        OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                        OdbcCommand cmd = new OdbcCommand();
                        con.Open();

                        cmd.Connection = con;
                        cmd.CommandText = "insert into que (key,question,answer,ch1,ch2,ch3,ch4) values('ch','" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Succesfully Added");
                        con.Close();

                        textBox1.Text = " ";
                        textBox2.Text = " ";
                        textBox3.Text = " ";
                        textBox4.Text = " ";
                        textBox5.Text = " ";
                        textBox7.Text = " ";
                        textBox8.Text = " ";

                        comboBox1.Items.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            if (radioButton2.Checked == true)
            {
                if(string.IsNullOrEmpty(textBox7.Text) == true || string.IsNullOrEmpty(textBox8.Text)== true)
                {
                    MessageBox.Show("Donot leave any field empty !!! ");
                }
                else
                {
                    try
                    {
                        OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                        OdbcCommand cmd = new OdbcCommand();
                        con.Open();

                        cmd.Connection = con;
                        cmd.CommandText = "insert into que (key,question,answer,ch1,ch2,ch3,ch4) values('fb','" + textBox7.Text + "','" + textBox8.Text + "','nil','nil','nil','nil')";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Succesfully Added");
                        con.Close();

                        textBox1.Text = " ";
                        textBox2.Text = " ";
                        textBox3.Text = " ";
                        textBox4.Text = " ";
                        textBox5.Text = " ";
                        textBox7.Text = " ";
                        textBox8.Text = " ";

                        comboBox1.Items.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

          


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // comboBox1.Items.Add(tb2);
           // comboBox1.Items.Add(tb3);
          //  comboBox1.Items.Add(tb4);
          //  comboBox1.Items.Add(tb5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox2.Text);
        }


        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox4.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox5.Text);
        }
    }
}
