using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DB_connect;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class question : Form
    {
        int questionNumber1;
        List<Quations> quations = new List<Quations>();
        Quiz quiz = new Quiz();
        public question(int questionNumber, List<Quations> quations1,Quiz quiz)
        {
            InitializeComponent();
            questionNumber1 = questionNumber;
            quations=quations1;
            lb_number.Text=questionNumber1.ToString();
            this.quiz.Quiz_name = quiz.Quiz_name;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private Quations createQuation(RichTextBox text,TextBox option1, TextBox option2,
                                      TextBox option3, TextBox option4, Label Q_number)
        {
            String correctAnser="";
            if (rb_a.Checked) correctAnser = option1.Text;
            if (rb_b.Checked) correctAnser = option2.Text;
            if (rb_c.Checked) correctAnser = option3.Text;
            if (rb_d.Checked) correctAnser = option4.Text;

            return new Quations(Convert.ToInt16(Q_number.Text),
                                            option1.Text,option2.Text,option3.Text,
                                            option4.Text,text.Text, correctAnser);

        }
        private Boolean validation()
        {
            if (tb_option1.Text == "") return false;
            if (tb_option2.Text == "") return false;
            if (tb_option3.Text == "") return false;
            if (tb_option4.Text == "") return false;
            if (text.Text == "") return false;
            
            return true;

        }
        private Boolean validateRadioButton()
        {
            if (!rb_a.Checked && !rb_b.Checked && !rb_c.Checked && !rb_d.Checked)
            {
                MessageBox.Show("choose the coorect option");
                return false;
            }
            else return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!validation())
            {
                MessageBox.Show("fill champs first");
                return;
            }
            if(!validateRadioButton())
            {
                return;
            }
            
                Quations q1 = createQuation(text, tb_option1, tb_option2, tb_option3, tb_option4, lb_number);
                quations.Add(q1);
                questionNumber1++;
                question frm = new question(questionNumber1, quations, quiz);
                frm.Show();
                this.Close();
            
            
            
           
            

        }
        
        private void btn_start_Click(object sender, EventArgs e)
        {


            if (validation()) ///ida m3mrin
            {

                if (!validateRadioButton()) //validation machi m3mra
                {
                    MessageBox.Show("choose the correct option");
                    return;
                }
                else
                {
                    Quations q1 = createQuation(text, tb_option1, tb_option2, tb_option3, tb_option4, lb_number);
                    quations.Add(q1);
                    addQuizzName frmaddq = new addQuizzName(quations, quiz);
                    frmaddq.Show();
                    this.Close();
                }
                
            }
            else {
                addQuizzName frmaddq = new addQuizzName(quations, quiz);
                frmaddq.Show();
                this.Close();
            }
            

                
            
            
            
            

        }
    }
}
