using System.Collections;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello, Please enter your name..");
            string? name = Console.ReadLine();
            DateTime date = DateTime.Now;

            Console.WriteLine("------------------------------");
            
            Console.WriteLine($"Welcome to Math Game {(String.IsNullOrWhiteSpace(name) ? Environment.UserName : name)}, It's {date} right now, Hope you fun playing the game.\n");
            
            Console.WriteLine("-------------MENU-------------\n");
            
            Console.WriteLine($@"To start the game, Please choose one of the option from below:
                
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                E - Exit
            
            ");

            string? gameInput = Console.ReadLine();
            List<string> acceptedInputs = new List<string>() {"a", "s", "m", "d", "A", "S", "M", "D", "E", "e" };
            while (!acceptedInputs.Contains(gameInput))
            {
                Console.WriteLine($@"To start the game, Please choose one of the option from below:
                
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                E - Exit
            
                ");
                gameInput = Console.ReadLine();

            }

            if ((gameInput == "E") || (gameInput == "e"))
            {
                Console.WriteLine("Thanks for playing");
                Environment.Exit(0);
            }
            else
            {
                bool play = true;
                while (play)
                {
                    int ans = Questions(gameInput);
                    string? userAnswer = Console.ReadLine();
                    int userAnswerToInt = Int32.TryParse(userAnswer, out int val) ? val : 0;
                    if (ans == userAnswerToInt)
                    {
                        Console.WriteLine("Congrats, it's the right answer!");
                    }
                    else
                    {
                        Console.WriteLine("Boo Boo! you lost.");
                        play = false;
                    }

                }

            }

            Console.WriteLine("Thanks for playing");
        }

        public static int Questions(string input)
        {
            int numberA = RandomNumberGenerator.GetInt32(1, 100);
            int numberB = RandomNumberGenerator.GetInt32(1, 100);
            string inputSymbol = Symbol(input);

            int Operator(int numA, int numB, string op)
            {
                return input switch
                {
                    "A" or "a" => numA + numB,
                    "S" or "s" => numA - numB,
                    "M" or "m" => numA * numB,
                    "D" or "d" => numA / numB,
                    _ => throw new ArgumentException("Invalid input")
                };
            }

            string Symbol(string input)
            {
                return input switch
                {
                    "A" or "a" => "+",
                    "S" or "s" => "-",
                    "M" or "m" => "*",
                    "D" or "d" => "/",
                    _ => throw new ArgumentException("Invalid input")
                };
            }

            Console.WriteLine($"What's {numberA} {inputSymbol} {numberB} ?");
            return Operator(numberA, numberB, input);
        }
    }
}
