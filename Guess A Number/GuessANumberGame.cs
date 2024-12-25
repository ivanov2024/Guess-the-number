namespace Guess_A_Number
{
    public class GuessANumberGame
    {
        private const int MinNumber = 1;
        private const int MaxNumber = 100;
        private int _numberToGuess;

        static void Main(string[] args)
        {
            GuessANumberGame program = new();
            program.Game();
        }

        public void Game()
        {
            Console.Write($"Guess a number from {MinNumber}-{MaxNumber}: ");
            _numberToGuess = GenerateNumberToGuess();

            while (true)
            {
                int playerNumber = GetPlayerGuess();

                if (ProcessPlayerInput(playerNumber))
                {
                    Console.WriteLine("You win - you guessed the number!");
                    break;
                }
            }
        }

        private int GenerateNumberToGuess()
        {
            Random random = new();
            return random.Next(MinNumber, MaxNumber + 1);
        }

        private int GetPlayerGuess()
        {
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Invalid input! Please try again: ");
                }
            }
        }

        private bool ProcessPlayerInput(int playerNumber)
        {
            if (playerNumber < MinNumber || playerNumber > MaxNumber)
            {
                Console.Write($"Please enter a number in the range {MinNumber}-{MaxNumber}: ");
                return false;
            }
            else if (playerNumber < _numberToGuess)
            {
                Console.Write("Higher!: ");
                return false;
            }
            else if (playerNumber > _numberToGuess)
            {
                Console.Write("Lower!: ");
                return false;
            }

            return true;
        }
    }
}
