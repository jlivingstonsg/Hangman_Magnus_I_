using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman_Magnus_I_
{
    class Program
    {

     


        static void Main()
        {
            var keepAlive = true;
            while (keepAlive)
            {
                try
                {
                    Console.WriteLine("------------------------------------------  ");
                    Console.WriteLine("Hangman.   ");
                    Console.WriteLine("------------------------------------------  ");
                    Console.Write("Start game with y or n to exit): ");
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch (Char.ToLower(ch))
                    {               
                        case 'y':                    
                            RunHangman();
                            break;
                        case 'n':
                            keepAlive = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That is not a valid assignment letter or word!");
                            break;
                    }
                    Console.ResetColor();
                    Console.WriteLine("Hit any key to continue!");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid assignment letter or word!");
                    Console.ResetColor();
                }

            }//while (keepAlive)
            //---------------------------------------------------------------------------------
        }//static void Main(string[] args)

        private static void RunHangman()
        {



            Random random = new Random((int)DateTime.Now.Ticks);

            string[] wordBank = { "MANGO", "GRAPES", "BANANA", "APPLE", "ORANGE", "PEAR" };

            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];  //Get a word
            Console.WriteLine("--Secret word:  " + wordToGuess + "  --");  //   Facit skrivs ut
            string wordToGuessUppercase = wordToGuess.ToUpper();
            StringBuilder displayToPlayer = new StringBuilder(50);     
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');
            Console.WriteLine("Word to guess:  " + displayToPlayer.ToString());
            List<char> correctGuesses   = new List<char>();
            StringBuilder incorrectGuesses = new StringBuilder(50);               //List<char> incorrectGuesses = new List<char>();

            int lives = 10;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;
            string stringincorrectGuesses = " ";

            while (!won && lives > 0)
            {
                Console.Write("Guess what fruit. '{0}' time/s, letter or word: ", lives);
                input = Console.ReadLine().ToUpper();
                if (1 == input.Length)
                {               
                        guess = input[0];
                        char[] charincorrectGuesses = stringincorrectGuesses.ToCharArray();
                        if (correctGuesses.Contains(guess))
                        {
                            Console.WriteLine("You've already tried '{0}', and it was correct!", guess);                    
                            continue;
                        }
                        else if (charincorrectGuesses.Contains(guess))  //Contains(guess)
                        {
                            Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                            continue;
                        }
                        //-----------------------Next----------------------------------------
                        if (wordToGuessUppercase.Contains(guess))
                        {
                            correctGuesses.Add(guess);

                            for (int i = 0; i < wordToGuess.Length; i++)
                            {
                                if (wordToGuessUppercase[i] == guess)
                                {
                                    displayToPlayer[i] = wordToGuess[i];
                                    lettersRevealed++;
                                }
                            }

                            if (lettersRevealed == wordToGuess.Length)
                                won = true;
                        }
                        else
                        {
                            incorrectGuesses.Append(guess);  //.Add(guess)
                            stringincorrectGuesses = incorrectGuesses.ToString();                            
                            Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                            lives--;
                        }
                        Console.WriteLine("Word to guess:  " + displayToPlayer.ToString());
                }//f (1 == input.Length)
                else
                {
                    if (1 < input.Length)
                    {
                        if (input == wordToGuess)
                        {
                            won = true;
                        }
                        else
                        {
                            Console.WriteLine("Nope,  '{0}' is the wrong word!", input);
                            lives--;
                        }

                    }
                    else
                    {
                        Console.WriteLine("You need to press a letter key. Try again.  ");

                    }
                }

            }//while (!won && lives > 0)

            if (won)
                Console.WriteLine("----------You won!------------");
            else
                Console.WriteLine("You lost! It was '{0}'", wordToGuess);

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();








        }//private static void RunHangman()


       




    }//class Program
}//namespace Hangman_Magnus_I_
