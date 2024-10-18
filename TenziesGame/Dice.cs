using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenziesGame
{
    public class Dice
    {
        public int DiceId;
        private int _diceNum;
        public int DiceNum {
            get
            {
                return _diceNum;
            }
        }
        public bool IsFixed { get; set; }

        private Random random = new();
        public Dice(int id) 
        {
            DiceId = id;
            RollDice();
            IsFixed = false;
        }

        public void RollDice()
        {
            if (!IsFixed)
            {
                _diceNum = random.Next(1, 7);
            }
        }
    }
}
