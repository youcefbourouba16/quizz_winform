using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DB_connect;

namespace WindowsFormsApp1.Model
{
    public class Quiz
    {
        
        private String quiz_name;
        private List<Quations> list_quation;
        public Quiz()
        {
            
        }
        public Quiz(string quiz_name)
        {
            Quiz_name = quiz_name;
            list_quation = new List<Quations>();
        }
        public Quiz(string quiz_name, List<Quations> quations)
        {
            Quiz_name = quiz_name;
            list_quation = quations;
        }
        public string Quiz_name { get => quiz_name; set => quiz_name = value; }
        public List<Quations> List_quation { get => list_quation; set => list_quation = value; }
    }
}
