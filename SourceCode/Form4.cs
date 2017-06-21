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
    public partial class Form4 : Form
    {
        int  rand , picno ,picmin , picmax , maxlog   , qmin , qmax;
        int[] questionsarr = new int[17];
        string name;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this part of the program checks the no of questions and if there is pics enough to initiate thequiz
            int count1 = 0, count2 = 0;

            OdbcConnection con = new OdbcConnection(@"DSN=mad1");
            OdbcCommand cmd = new OdbcCommand();
            OdbcCommand cmd1 = new OdbcCommand();
            con.Open();
            cmd.Connection = con;
            cmd1.Connection = con;
            cmd.CommandText = "select count(imgid) from pic";
            cmd1.CommandText = "select count(id) from que";
            OdbcDataReader dr = cmd.ExecuteReader();
            OdbcDataReader dr1 = cmd1.ExecuteReader();
            while (dr.Read())
            {
                count1 = Int32.Parse(dr[0].ToString());
            }
            while (dr1.Read())
            {
                count2 = Int32.Parse(dr1[0].ToString());
            }
            con.Close();

            if (count1 >= 1 && count2 >= 16)
            {
                if (textBox1.Text.Length != 0)
                {
                    try
                    {
                        OdbcConnection con3 = new OdbcConnection(@"DSN=mad1");
                        OdbcCommand cmd3 = new OdbcCommand();
                        con3.Open();
                        cmd3.Connection = con3;
                        cmd3.CommandText = "insert into log(name,marks) values('" + textBox1.Text + "',0)";
                        cmd3.ExecuteNonQuery();
            //            MessageBox.Show("checkpoint1");

                        try
                        {
                            OdbcConnection con2 = new OdbcConnection(@"DSN=mad1");
                            OdbcCommand cmd2 = new OdbcCommand();
                            OdbcCommand cmd4 = new OdbcCommand();
                            OdbcCommand cmd9 = new OdbcCommand();
                            con2.Open();
                            cmd4.Connection = con2;
                            cmd2.Connection = con2;
                            cmd9.Connection = con2;
                            cmd4.CommandText = "select min(imgid) from pic";
                            cmd2.CommandText = " select max(imgid) from pic";
                            cmd9.CommandText = " select max(id) from log ";
                            OdbcDataReader dr2 = cmd4.ExecuteReader();
                            OdbcDataReader dr9 = cmd9.ExecuteReader();
                            while (dr2.Read())
                            {
                                picmin = Int32.Parse(dr2[0].ToString());
                            }
                            OdbcDataReader dr3 = cmd2.ExecuteReader();
                            while (dr3.Read())
                            {
                                picmax = Int32.Parse(dr3[0].ToString());
                            }
                            while (dr9.Read())
                            {
                                maxlog = Int32.Parse(dr9[0].ToString());
                            }
                            //          MessageBox.Show("Checkpoint2");

                            con.Close();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        Random r = new Random();
                        int bg = r.Next(picmin, picmax+1);
                        
                        name = textBox1.Text;
                        maxlog = maxlog+1;
                        //MessageBox.Show(maxlog.ToString());
                //        MessageBox.Show("Checkpoint3");
                        try
                        {
                            OdbcConnection con4 = new OdbcConnection(@"DSN=mad1");
                            OdbcCommand cmd5 = new OdbcCommand();
                            con4.Open();
                            cmd5.Connection = con4;
                            cmd5.CommandText = "update log set bg =" + bg + " where id=" + maxlog;
                            cmd5.ExecuteNonQuery();
                            //      MessageBox.Show("Checkpoint4");
                            //linking a question to every button 
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.ToString());
                        }


                        try
                        {
                            OdbcConnection con8 = new OdbcConnection(@"DSN=mad1");
                            OdbcCommand cmd8 = new OdbcCommand();
                            OdbcCommand cmd7 = new OdbcCommand();
                            con8.Open();
                            cmd8.Connection = con8;
                            cmd7.Connection = con8;
                            cmd8.CommandText = "select min(id) from que";
                            cmd7.CommandText = " select max(id) from que";
                            OdbcDataReader dr8 = cmd8.ExecuteReader();
                            while (dr8.Read())
                            {
                                qmin = Int32.Parse(dr8[0].ToString());
                            }
                            OdbcDataReader dr7 = cmd7.ExecuteReader();
                            while (dr7.Read())
                            {
                                qmax = Int32.Parse(dr7[0].ToString());
                            }

                            con8.Close();
                        }
                        catch (Exception e2)
                        {
                            MessageBox.Show(e2.ToString());
                        }
                    //    MessageBox.Show("Checkpoint5");

                        //assigning questions to buttons
                       

                        for (int i = 1; i <= 16; i++)
                        {
                             rgen : Random r1 = new Random();
                             int rand = r1.Next(qmin, qmax+1);
                            if(questionsarr.Contains(rand))
                            {
                                goto rgen;
                            }
                            else
                            {
                                try
                                {
                                    questionsarr[i] = rand;
                                    OdbcConnection con5 = new OdbcConnection(@"DSN=mad1");
                                    OdbcCommand cmd11 = new OdbcCommand();
                                    con5.Open();
                                    cmd11.Connection = con5;
                                    cmd11.CommandText = "update log set button" + i + " = " + rand + " where id = " + maxlog;
                                    cmd11.ExecuteNonQuery();
                                }
                                catch (Exception ex2)
                                {
                                    MessageBox.Show(ex2.ToString());
                                }
                            }
                        }


                      //  MessageBox.Show("Checkpoint6");
                        int[] buttonflag = new int[17];

                        for (int i = 1; i <= 16; i++)
                        {
                            buttonflag[i] = 9;
                        }

                        this.Hide();
                        Form7 f7 = new Form7(textBox1.Text,maxlog,bg,questionsarr,buttonflag);
                        f7.Show();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(" An error occured !!  sorry for inconvenience !! \n Please press 'go to test' button again ");
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("Please enter a valid name!!! ");
                }
            }
            else
            {
                MessageBox.Show("There should be sixteen questions and 1 picture in the database!! \n Please add sufficient number of questions !!! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
