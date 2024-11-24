using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class MathGame
    {
        private readonly List<GameRecord> _history = new List<GameRecord>();

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Math Game Menu:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. View History");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayGame(Operation.Addition);
                        break;
                    case "2":
                        PlayGame(Operation.Subtraction);
                        break;
                    case "3":
                        PlayGame(Operation.Multiplication);
                        break;
                    case "4":
                        PlayGame(Operation.Division);
                        break;
                    case "5":
                        ShowHistory(); 
                        break;
                    case "6":
                        Console.WriteLine("Thanks for playing!");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice, please enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public (int numberA , int numberB, int correctAnswer, string question) GenerateQuestion(Operation operation)
        {
            int numberA, numberB, correctAnswer;
            string question;

            do
            {
                numberA = RandomNumberGenerator.GetInt32(0, 100);
                numberB = RandomNumberGenerator.GetInt32(0, 100);
            } while (operation == Operation.Division && (numberB == 0 || numberA % numberB != 0));

            switch (operation)
            {
                case Operation.Addition:
                    correctAnswer = numberA + numberB;
                    question = $"{numberA} + {numberB}";
                    break;
                case Operation.Subtraction:
                    correctAnswer = numberA - numberB;
                    question = $"{numberA} - {numberB}";
                    break;
                case Operation.Multiplication:
                    correctAnswer = numberA * numberB;
                    question = $"{numberA} * {numberB}";
                    break;
                case Operation.Division:
                    correctAnswer = numberA / numberB;
                    question = $"{numberA} / {numberB}";
                    break;
                default:
                    throw new InvalidOperationException("Operation Not Supported");
            }
            return (numberA, numberB, correctAnswer, question);
        }

        public void ShowHistory()
        {
            Console.Clear();
            if(_history.Count == 0)
            {
                Console.WriteLine("No records found, please play a game! Press enter to continue.");
                Console.ReadLine();
            }
            else
            {
                foreach(var item in _history)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Press enter to continue!");
                Console.ReadLine();
            }
        }

        public void PlayGame(Operation op)
        {
            Console.Clear();
            Console.WriteLine($"You Selected {op}, Solve the 5 Questions.");
            int score = 0;

            for(int i = 1; i <= 5; i++)
            {
                var(numberA, numberB, correctAnswer, question) = GenerateQuestion(op);
                Console.WriteLine($"Question {i} : {question}");
                Console.WriteLine("Your Answer: ");
                int usrAnswer;
                while(!int.TryParse(Console.ReadLine(), out usrAnswer))
                {
                    Console.WriteLine("Invalid Input, please enter an number.");
                }

                var record = new GameRecord
                {
                    Question = question,
                    UserAnswer = usrAnswer,
                    CorrectAnswer = correctAnswer
                };

                _history.Add(record);
                if (record.IsCorrect)
                {
                    Console.WriteLine("Your answer is correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong Answer, the correct answer is {correctAnswer}!");
                }
            }

            Console.WriteLine($"\nGame Over!, You scored {score}/5.");
            Console.WriteLine("Please enter to return to main menu.");
            Console.ReadLine();
        }
    }
}