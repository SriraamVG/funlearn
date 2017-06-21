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
    public partial class Form9 : Form
    {
        string answer, question , name ;
        int mark,picfl;
        int[] qnos = new int[17];
        int[] buttonflag = new int[17];
        int buttonid;

        public Form9(string q, string a , string n , int m,int[] qid,int pic,int[] butfl,int butid)
        {
            InitializeComponent();
            question = q;
            answer = a;
            qnos = qid;
            picfl = pic;
            buttonflag = butfl;
            buttonid = butid;
            name = n;
            mark = m;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
           label1.Text = question;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (answer == textBox1.Text)
            {
                buttonflag[buttonid] = 4;
                MessageBox.Show("Correct Answer ");
                mark = mark + 5;
                this.Hide();
                Form7 f7 = new Form7(name, mark, qnos,picfl,buttonflag);
                f7.Show();
            }
            else
            {
                MessageBox.Show("Wrong Answer");
                this.Hide();
                Form7 f7 = new Form7(name, mark, qnos,picfl,buttonflag);
                f7.Show();
            }
                
        }
    }
}
