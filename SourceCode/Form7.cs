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
    public partial class Form7 : Form
    {
        int picfl,butid;
        string name,status,switcher1;
        string question, answer, opt1, opt2, opt3, opt4;
        int picmin, picmax, qmin, qmax, questids, points=0 , loginid , mark;
        int count = 0;
        int[] qnos = new int[17];
        int buttonid;
        int[] buttonflag = new int[17];
        



      

        public Form7(string tempname,int m,int[] qid,int pic,int[] butfl)
        {
            InitializeComponent();

            mark = m;
            name = tempname;
            label2.Text = " Hello , " +name;
            label3.Text = " Your Current Score : "+mark;
            qnos = qid;
            picfl = pic;
            buttonflag = butfl;
        }
        

        

        public Form7(string tempname ,int id,int pfl,int[] qarr,int[] butfl)
        {
            InitializeComponent();
            name = tempname;
            picfl = pfl;
            label2.Text = " Hello , " + name;
            label3.Text = " Your Current Score : "+mark;
            loginid = id;
            qnos = qarr;
            buttonflag = butfl;

            //MessageBox.Show(picfl.ToString());

            //for (int i = 1; i < 17; i++)
            //{

            //    MessageBox.Show(qnos[i].ToString());
            //}

            int endcount=0;

            if (picfl == 0)
            {
                for (int i = 1; i <= 16; i++)
                {
                    if (buttonflag[i] == 4)
                    {
                        endcount = endcount + 1;
                    }

                }

             //   if (endcount == 16)
               // {
                 //   MessageBox.Show("Your final score is : " + mark);
                   // Form1 f1 = new Form1();
                   // f1.Show();
                   // this.Hide();

                //}
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            outside(4);
        }

        private void Form7_Load(object sender, EventArgs e)
        {
                int bg = picfl;
                OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                OdbcCommand cmd = new OdbcCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select add from pic where imgid = " + bg;
                OdbcDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pictureBox1.Image = Image.FromFile(dr[0].ToString());
                }


                for (int i = 1; i <= 16; i++)
                {
                    if (buttonflag[i] == 4)
                    {
            
                            if(i== 1)
                                button1.Visible = false;
                            if(i== 2)
                                button2.Visible = false;
                            if(i== 3)
                                button3.Visible = false;
                            if(i== 4)
                                button4.Visible = false;
                            if(i== 5)
                                button5.Visible = false;
                            if(i== 6)
                                button6.Visible = false;
                            if(i== 7)
                                button7.Visible = false;
                             if(i== 8)
                                button8.Visible = false;
                              if(i== 9)
                                button9.Visible = false;
                              if(i== 10)
                                button10.Visible = false;
                              if(i== 11)
                                button11.Visible = false;
                               if(i== 12)
                                button12.Visible = false;
                               if(i== 13)
                                button13.Visible = false;
                                if(i== 14)
                                button14.Visible = false;
                               if(i== 15)
                                button15.Visible = false;
                               if(i== 16)
                                button16.Visible = false;
                          
                    }
                }

                int endcount=0;

                for (int i = 1; i <= 16; i++)
                {
                    if(buttonflag[i]==4)
                        endcount=endcount+1;
                }
                if (endcount == 16 && picfl == 0)
                {
                    Form10 f10 = new Form10(name,mark);
                    f10.Show();
                    this.Hide();

                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outside(1);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            outside(2);
        }

        void outside(int bid)
        {
            //MessageBox.Show("Hello , how are you , this is working rite !! \n "+bid+ "," + qnos[bid]);


            butid = bid;

            //buttonflag[bid] = 4;

            try
            {

                OdbcConnection con = new OdbcConnection(@"DSN=mad1");
                OdbcCommand cmd2 = new OdbcCommand();
                con.Open();
                cmd2.Connection = con;
                cmd2.CommandText = " select *  from que where id =" + qnos[bid];
                OdbcDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    switcher1 = dr[1].ToString();
                    question = dr[2].ToString();
                    answer = dr[3].ToString();
                    opt1 = dr[4].ToString();
                    opt2 = dr[5].ToString();
                    opt3 = dr[6].ToString();
                    opt4 = dr[7].ToString();
                }

              //   MessageBox.Show(switcher1.ToString());
              //   MessageBox.Show(qnos[bid].ToString());


                if (switcher1.Equals("fb"))
                {
                    //this.Hide();
                    //Form9 f9 = new Form9(question, answer, name, mark,qnos);
                    //f9.Show();

                    Form9 form2 = new Form9(question, answer, name, mark, qnos, picfl, buttonflag, bid);
                    form2.Tag = this;
                    form2.Show(this);
                    Hide();
                }
                else
                {
                    //this.Hide();
                    //Form8 f8 = new Form8(question, answer, opt1, opt2, opt3, opt4, name, mark,qnos);
                    //f8.Show();

                    Form8 form2 = new Form8(question, answer, opt1, opt2, opt3, opt4, name, mark, qnos, picfl, buttonflag, bid);
                    form2.Tag = this;
                    form2.Show(this);
                    Hide();



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            outside(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            outside(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            outside(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            outside(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            outside(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            outside(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            outside(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            outside(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            outside(12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            outside(13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            outside(14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            outside(15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            outside(16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string answer=null;

              OdbcConnection con = new OdbcConnection(@"DSN=mad1");
            OdbcCommand cmd2 = new OdbcCommand();
            con.Open();
            cmd2.Connection = con;
            cmd2.CommandText = " select *  from pic where imgid ="+picfl ;
            OdbcDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
               answer=(dr[2].ToString());
            }

            if (textBox1.Text == answer)
            {
                MessageBox.Show("Correct Answer");
                mark = mark + 20;
                picfl=0;
                Form7 f7 = new Form7(name, mark, qnos, picfl, buttonflag);
                f7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Answer");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form10 f10 = new Form10(name, mark);
            f10.Show();
            this.Hide();
        }
    }
}
