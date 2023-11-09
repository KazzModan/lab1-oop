using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_oop
{
    public class GameAccount
    {
        public string? userName { get; set; } = null; // Ім'я гравця
        public int currentRating { get; set; } // Поточний рейтинг гравця
        private List<GameResult> gameHistory; // Історія ігор гравця
        public int _gamesCount { get; set; } // Кількість ігор гравця

        // Конструктор класу GameAccount, де можливо вказати початкову кількість ігор (за замовчуванням - 0).
        public GameAccount(int gamesCount = 0)
        {
            _gamesCount = gamesCount;
            gameHistory = new List<GameResult>();
        }

        // Методи для фіксації результатів гри та оновлення статистики гравця.

        public void WinGame(string opponentName, int rating)
        {
            _gamesCount++;
            currentRating += rating;
            gameHistory.Add(new GameResult(opponentName, true, rating));
        }

        public void LoseGame(string opponentName, int rating)
        {
            _gamesCount++;
            currentRating -= rating;
            gameHistory.Add(new GameResult(opponentName, false, rating));
        }

        // Виведення статистики гравця на консоль.
        public void GetStats()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n.................................\n");
            Console.WriteLine($"ІСТОРІЯ ІГОР для {userName}:");
            for (int i = 0; i < gameHistory.Count; i++)
            {
                var result = gameHistory[i];
                String matchResult;
                if (result._won) { matchResult = "Перемога"; } else { matchResult = "Поразка"; }
                Console.WriteLine($"Гра {i + 1}: \n" +
                                  $"Опонент: {result._opponentName}\n" +
                                  $"Результат: {(matchResult)}\n" +
                                  $"Зміна рейтингу: {result._ratingChange}\n");
            }
            Console.WriteLine($"Поточний рейтинг для {userName}: {currentRating}\n" +
                              $"Кількість ігор: {_gamesCount}\n");
        }
    }
}
