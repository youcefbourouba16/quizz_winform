using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Quations
    {
        private String quiz_ID;
        private int  quation_Number;
        private String quation1;
        private String quation2;
        private String quation3;
        private String quation4;
        private String text;
        private String correctText;

        public Quations()
        {
        }

        public Quations(String quiz_ID, int quation_Number, string quation1, string quation2, string quation3, string quation4, string text)
        {
            this.Quiz_ID = quiz_ID;
            this.Quation_Number = quation_Number;
            this.Quation1 = quation1;
            this.Quation2 = quation2;
            this.Quation3 = quation3;
            this.Quation4 = quation4;
            this.Text = text;
        }
        public Quations( int quation_Number, string quation1, string quation2, string quation3, string quation4, string text,String correct_text)
        {
            this.Quiz_ID = quiz_ID;
            this.Quation_Number = quation_Number;
            this.Quation1 = quation1;
            this.Quation2 = quation2;
            this.Quation3 = quation3;
            this.Quation4 = quation4;
            this.CorrectText = correct_text;
            this.Text = text;
        }
        public String Quiz_ID { get => quiz_ID; set => quiz_ID = value; }
        public int Quation_Number { get => quation_Number; set => quation_Number = value; }
        public string Quation1 { get => quation1; set => quation1 = value; }
        public string Quation2 { get => quation2; set => quation2 = value; }
        public string Quation3 { get => quation3; set => quation3 = value; }
        public string Quation4 { get => quation4; set => quation4 = value; }
        public string Text { get => text; set => text = value; }
        public string CorrectText { get => correctText; set => correctText = value; }
    }
}
