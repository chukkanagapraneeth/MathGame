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
            MathGame game = new MathGame();
            game.Menu();
        }
    }
}
