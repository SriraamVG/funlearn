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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                OdbcCommand cmd = new OdbcCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from que";
                cmd.ExecuteNonQuery();
                MessageBox.Show("The questions were succesfully deleted !! ");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                OdbcCommand cmd = new OdbcCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from pic";
                cmd.ExecuteNonQuery();
                MessageBox.Show("The pictures were succesfully deleted !! ");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                OdbcCommand cmd = new OdbcCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from log";
                cmd.ExecuteNonQuery();
                MessageBox.Show("The logs were succesfully deleted !! ");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
