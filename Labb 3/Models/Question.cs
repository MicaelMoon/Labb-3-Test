using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3.Models
{
    public class Question
    {
        public bool isQuestion = true;
        public string Statment { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }

        public Question(string statment, string[] answers, int correctAnswer)
        {
            Statment = statment;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
