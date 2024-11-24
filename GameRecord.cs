using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class GameRecord
    {
        public string Question {  get; set; }
        public int UserAnswer { get; set; }
        public int CorrectAnswer { get; set; }
        public bool IsCorrect => UserAnswer == CorrectAnswer;

        public override string ToString()
        {
            return $"{Question} | Your Answer: {UserAnswer} | Correct Answer: {CorrectAnswer} | Result: {IsCorrect}";
        }
    }
}
