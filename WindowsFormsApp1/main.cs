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
    public partial class main : Form
    {
        List<Quations> quations = new List<Quations>();
        public main()
        {
            InitializeComponent();
            List<Quiz> quisez = Db_connect.loadQuizes();
            if (quisez.Count!=0)
            {
                comboBox1.Items.Clear();
                foreach (Quiz item in quisez)
                {
                    comboBox1.Items.Add(item);
                }
                comboBox1.SelectedIndex = 0;
                comboBox1.DisplayMember = "quiz_name";
                comboBox1.ValueMember = "quiz_name";
            }
            
        }

        private void btn_addQ_Click(object sender, EventArgs e)
        {
            Quiz newQuiz = new Quiz();
            question frm=new question(1, quations, newQuiz);
            
            frm.Show();
            this.Hide();

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            int score = 0;
            answers frm = new answers((Quiz)comboBox1.SelectedItem,0,score);
            
            frm.Show();
            this.Hide();



        }
    }
}
