using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.DB_connect
{
    public class Db_connect
    {
        public static SqlConnection con=new SqlConnection();
        public static void connect()
        {
            if (con.State== ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = "Data Source=DESKTOP-KNG9Q9T\\SQLEXPRESS;Initial Catalog=Quiz;User ID=root;Password=06122099youcef";
                con.Open();
            }
        }
        public static void deconnect()
        {
            if (con.State == ConnectionState.Open )
            {
                con.Close();
            }
        }
       public static SqlCommand cmd;
        public static void add_quiz(Quiz quiz)
        {
            try
            {
                connect();
                String query_quiz = $"insert into quiz(quiz_name) values ('{quiz.Quiz_name}')";
                cmd = new SqlCommand(query_quiz, con);
                cmd.ExecuteNonQuery();
                foreach (Quations qestion in quiz.List_quation)
                {
                    String query_question = $"insert into quation " +
                        $"(quiz_name,text,quation1,quation2,quation3,quation4,quation_Number,correctOption)\r\n " +
                        $" values ('{quiz.Quiz_name}','{qestion.Text}','{qestion.Quation1}'," +
                        $"'{qestion.Quation2}','{qestion.Quation3}','{qestion.Quation4}',{qestion.Quation_Number},'{qestion.CorrectText}')";
                    MessageBox.Show(query_question);
                    cmd = new SqlCommand(query_question, con);
                    cmd.ExecuteNonQuery();
                }
                deconnect();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        public static List<Quiz> loadQuizes()
        {
            String sql = "select * from quiz ";
            List<Quiz> quizes = new List<Quiz>();
            try
            {
                connect();
                cmd = new SqlCommand(sql, con);
                SqlDataReader dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    Quiz quiz = new Quiz();
                    quiz.Quiz_name = dr.GetString(0);
                    quizes.Add(quiz);

                }
                dr.Close();
                deconnect();
                return quizes;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }
            

        }
        public static Quiz load_quiz(String quiz_name)
        {
            String sql = $"select * from quation where quiz_name='{quiz_name}'";
            try
            {
                connect();
                cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                Quiz quiz = new Quiz(quiz_name);
                while (dr.Read())
                {

                    Quations q = new Quations();
                    q.Quiz_ID = quiz_name;
                    q.Quation1 = dr.GetString(3); //option 1
                    q.Quation2 = dr.GetString(2);//option 2
                    q.Quation3 = dr.GetString(1);//option 3
                    q.Quation4 = dr.GetString(0);//option 4
                    q.Text = dr.GetString(4);
                    q.Quation_Number = dr.GetInt32(6);
                    q.CorrectText = dr.GetString(8);
                    quiz.List_quation.Add(q);

                }
                dr.Close();
                deconnect();
                return quiz;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }
            

        }
    }
}
