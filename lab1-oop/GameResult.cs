using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_oop
{
    public class GameResult
    {
        public string _opponentName { get; }
        public bool _won { get; }
        public int _ratingChange { get; }

        public GameResult(string opponentName, bool won, int ratingChange)
        {
            _opponentName = opponentName;
            _won = won;
            _ratingChange = ratingChange;
        }
    }
}
