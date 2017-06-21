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
    public partial class Form5 : Form
    {
        string dir;

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = " image files |*.jpg;*.jpeg;*.gif";
            DialogResult dr = ofd.ShowDialog();


            if (dr == DialogResult.Cancel)
            {
                return;
               //MessageBox.Show("inside else ");
            }

                pictureBox1.Image = Image.FromFile(ofd.FileName);
                textBox1.Text = ofd.FileName;
                dir = ofd.FileName;
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ( pictureBox1.Image != null && textBox2.Text.Length != 0)
            {
                try
                {
                    OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                    OdbcCommand cmd = new OdbcCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into pic(img,answer,add) values('" + textBox1.Text + "','"+textBox2.Text+"','"+textBox1.Text+"')";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" Picture successfully added ");

                    textBox1.Text = " ";
                    pictureBox1.Image = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
            else
            {
                MessageBox.Show("Donot leave any field blank");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
