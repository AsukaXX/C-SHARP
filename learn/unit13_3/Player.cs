using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit13_3
{
    public class Player
    {
        public string Nmae { get; private set; }
        public Cards PlayHand { get; private set; }
        private Player() { }
        public Player(String name)
        {
            Nmae = name;
            PlayHand = new Cards();
        }
        public bool HasWon()
        {
            bool won = true;
            Suit match = PlayHand[0].suit;
            for (int i = 1; i < PlayHand.Count; i++)
            {
                won &= PlayHand[i].suit == match;
            }
            return won;
        }
    }
}