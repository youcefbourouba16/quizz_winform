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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class answers : Form
    {
        Quiz q = new Quiz();
        int quation_number;
        int score;
        public answers(Quiz quiz,int quation,int score)
        {
            InitializeComponent();
            quation_number = quation;
            this.score = score;
            q = Db_connect.load_quiz(quiz.Quiz_name);
            if (q.List_quation.Count == 0)
            {
                MessageBox.Show("error");
                main frm = new main();
                frm.Show();
                


            }
            else if (quation<q.List_quation.Count)
            {
                lb_text.Text = q.List_quation[quation].Text;
                btn_1.Text = q.List_quation[quation].Quation1;
                btn_2.Text = q.List_quation[quation].Quation2;
                btn_3.Text = q.List_quation[quation].Quation3;
                btn_4.Text = q.List_quation[quation].Quation4;
            }
            
            
           

        }

        private void btn_skip_Click(object sender, EventArgs e)
        {
            quation_number++;
            if (quation_number < q.List_quation.Count)
            {
                answers frm = new answers(q, quation_number, score);

                frm.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("quize_ended");
                main frm = new main();
                frm.Show();
                this.Close();
            }
            
            
        }
        private Boolean checkTrue(System.Windows.Forms.Button btn)
        {
          
            if (btn.Text == q.List_quation[quation_number].CorrectText )
            {
                return true;
            }else
            {
                return false;
            }
        }
        private void finilisation()
        {
            quation_number++;
            if (quation_number < q.List_quation.Count)
            {
                answers frm = new answers(q, quation_number, score);

                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("quize_ended" + score);
                main frm = new main();
                frm.Show();
                this.Close();
            }
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            
            if (checkTrue(btn_1))
            {
                score = score + 5;
            }
            else
            {
                if (score>0)
                {
                    score = score - 5;
                }
            }
            finilisation();
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (checkTrue(btn_2))
            {
                score = score + 5;
            }
            else
            {
                if (score > 0)
                {
                    score = score - 5;
                }
            }
            finilisation();
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (checkTrue(btn_3))
            {
                score = score + 5;
            }
            else
            {
                if (score > 0)
                {
                    score = score - 5;
                }
            }
            finilisation();
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (checkTrue(btn_1))
            {
                score = score + 5;
            }
            else
            {
                if (score > 0)
                {
                    score = score - 5;
                }
            }
            finilisation();
        }
    }
}
