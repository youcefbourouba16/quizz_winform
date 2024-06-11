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
    public partial class addQuizzName : Form
    {
        List<Quations> qs = new List<Quations>();
        Quiz quiz = new Quiz();
        public addQuizzName(List<Quations> quations,Quiz quiz)
        {
            InitializeComponent();
            qs = quations;
            this.quiz= quiz;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            quiz.Quiz_name = tb_quizName.Text;
            quiz.List_quation = qs;
            Db_connect.add_quiz(quiz);
            main frm = new main();
            frm.Show();
            this.Close();
            

        }
    }
}
