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
    public partial class Form8 : Form
    {
        string question, answer, opt1, opt2, opt3, opt4,name;
        int mark,picfl;
        int[] qnos = new int[17];
        int[] buttonflag = new int[17];
        int buttonid;


        public Form8(string q, string a, string o1, string o2, string o3, string o4, string n,int m,int[] qid,int pic,int[] butfl,int bid)
        {
            InitializeComponent();
            question = q;
            answer = a;
            opt1 = o1;
            opt2 = o2;
            opt3 = o3;
            opt4 = o4;
            mark = m;
            qnos = qid;
            picfl = pic;
            buttonflag = butfl;
            buttonid = bid;
            name = n;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
                label1.Text = question;
                radioButton1.Text = opt1;
                radioButton2.Text = opt2;
                radioButton3.Text = opt3;
                radioButton4.Text = opt4;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (radioButton1.Text == answer)
                {
                    buttonflag[buttonid] = 4;
                    mark = mark + 5;
                    MessageBox.Show("Right Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name,mark,qnos,picfl,buttonflag);
                    f7.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name, mark,qnos,picfl,buttonflag);
                    f7.Show();
                }
            }
            if (radioButton2.Checked == true)
            {
                if (radioButton2.Text == answer)
                {
                    buttonflag[buttonid] = 4;
                    mark = mark + 5;
                    MessageBox.Show("Right Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name, mark,qnos,picfl,buttonflag);
                    f7.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name, mark, qnos,picfl,buttonflag);
                    f7.Show();
                }
            }
            if (radioButton3.Checked == true)
            {
                if (radioButton3.Text == answer)
                {
                    buttonflag[buttonid] = 4;
                    mark = mark + 5;
                    MessageBox.Show("Right Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name, mark, qnos,picfl,buttonflag);
                    f7.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name, mark, qnos,picfl,buttonflag);
                    f7.Show();
                }
            }
            if (radioButton4.Checked == true)
            {
                if (radioButton4.Text == answer)
                {
                    buttonflag[buttonid] = 4;
                    mark = mark + 5;
                    MessageBox.Show("Right Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name, mark, qnos,picfl,buttonflag);
                    f7.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Answer");
                    this.Hide();
                    Form7 f7 = new Form7(name, mark, qnos,picfl,buttonflag);
                    f7.Show();
                }
            }
        }
    }
}
