using Laba1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1_oop;
namespace lab1_oop
{
    public class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }

        public Game(GameAccount player1, GameAccount player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        // Розпочати гру між гравцями.
        public void StartGame()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Ласкаво просимо до гри!\n");

            // Введення імен гравців та початкового рейтингу.
            Console.Write("Введіть ім'я першого гравця: ");
            player1.userName = Console.ReadLine().Trim();

            Console.Write("Введіть ім'я другого гравця: ");
            player2.userName = Console.ReadLine().Trim();

            Console.Write("\nВведіть початковий рейтинг: ");
            int startRating = Convert.ToInt32(Console.ReadLine());
            while (startRating <= 0)
            {
                Console.WriteLine("Початковий рейтинг повинен бути більше 0");
                Console.Write("Введіть початковий рейтинг: ");
                startRating = Convert.ToInt32(Console.ReadLine());
            }
            player1.currentRating = startRating;
            player2.currentRating = startRating;

            // Початок гри.
            Play();
        }

        // Метод, що виконує гру між гравцями.
        public void Play()
        {
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.Write("Введіть рейтинг на який граєте: ");
            int rating = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (rating < 0)
            {
                Console.WriteLine("Некоректне значення. Введіть додатнє число.");
                Play();
                return;
            }
            if (rating > player1.currentRating - 1 || rating > player2.currentRating - 1)
            {
                Console.WriteLine("У одного з гравців недостатньо рейтингу.");
                Play();
                return;
            }

            // Симуляція кидання кубиків і визначення переможця.
            Random random = new Random();
            int player1Roll = random.Next(1, 7);
            int player2Roll = random.Next(1, 7);
            Console.WriteLine($"{player1.userName} кинув кубик і випало {player1Roll}");
            Console.WriteLine($"{player2.userName} кинув кубик і випало {player2Roll}");
            if (player1Roll > player2Roll)
            {
                player1.WinGame(player2.userName, rating);
                player2.LoseGame(player1.userName, rating);
                Console.WriteLine($"Переміг {player1.userName}!");
                player1.GetStats();
                player2.GetStats();
            }
            if (player1Roll < player2Roll)
            {
                player2.WinGame(player1.userName, rating);
                player1.LoseGame(player2.userName, rating);
                Console.WriteLine($"Переміг {player2.userName}!");
                player1.GetStats();
                player2.GetStats();
            }
            if (player1Roll == player2Roll)
            {
                Console.WriteLine("Нічия");
            }

            // Питання про гру ще раз.
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.Write("Хочете зіграти ще одну гру? (Так/Ні): ");
            string playAgainResponse = Console.ReadLine().Trim();

            bool playAgain = true;
            if (!playAgainResponse.Equals("Так", StringComparison.OrdinalIgnoreCase))
            {
                playAgain = false;
            }
            if (playAgain) Play();
        }
    }
}
