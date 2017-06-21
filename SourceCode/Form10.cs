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
    public partial class Form10 : Form
    {
        string name;
        int mark;

        public Form10(string n,int m)
        {
            InitializeComponent();
            name = n;
            mark = m;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            label1.Text = name;
            label3.Text = mark.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int m = Int16.Parse(label3.Text); 
            int eg = 425; 
            int n = 3431; 
            int c = 1;  

            for (int i = 0; i < eg; i++) 
            {
                c = c * m;
                c = c % n;
            }

            int d = 1769; 
            m = 1;

            
            for (int i = 0; i < d; i++) 
            {
                m = m * c;
                m = m % n; 
            }
            MessageBox.Show(""+c);

            OdbcConnection con = new OdbcConnection(@"DSN=mad1");
            OdbcCommand cmd = new OdbcCommand();
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "update log set marks =  "+c+" where name = '"+label1.Text+"'";
            cmd.ExecuteNonQuery();

            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();

            /*int dc = 1769;

            for (int i = 0; i < d; i++)
            {
                m = m * c;
                m = m % n; 
            }
            */
        }
    }
}
