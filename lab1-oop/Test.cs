using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1_oop;

namespace lab1_oop
{
    public class Test
    {
        public static void Start()
        {
            GameAccount player1 = new GameAccount();
            GameAccount player2 = new GameAccount();
            Game game = new Game(player1, player2);

            // Розпочинаємо гру.
            game.StartGame();

            // Виводимо статистику гравців після завершення гри.
            player1.GetStats();
            player2.GetStats();
        }
    }
}
