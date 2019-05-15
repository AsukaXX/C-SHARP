using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace unit11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Deck myDeck = new Deck();
            myDeck.Shuffle();
            for (int i = 0; i < 52; i++)
            {
                Card tempCard = myDeck.GetCard(i);
                Write(tempCard.ToString());
                if (i != 51)
                    Write(", ");
                else
                    WriteLine();
            } */
            /* Deck deck1 = new Deck();
            Deck deck2 = (Deck)deck1.Clone();
            WriteLine($"The first card in the original deck is {deck1.GetCard(0)}");
            WriteLine($"The first card in the cloned deck is {deck2.GetCard(0)}");
            deck1.Shuffle();
            WriteLine("Original deck shuffled.");
            WriteLine($"The first card in the original deck is {deck1.GetCard(0)}");
            WriteLine($"The first card in the cloned deck is {deck2.GetCard(0)}"); */
            Card.isAceHigh = true;
            WriteLine("Aces are high.");
            Card.userTrumps = true;
            Card.trump = Suit.Club;
            WriteLine("Clubs are trumps.");
            Card card1, card2, card3, card4, card5;
            card1 = new Card(Suit.Club, Rank.Five);
            card2 = new Card(Suit.Club, Rank.Five);
            card3 = new Card(Suit.Club, Rank.Ace);
            card4 = new Card(Suit.Club, Rank.Ten);
            card5 = new Card(Suit.Club, Rank.Ace);
            WriteLine($"{card1.ToString()} == {card2.ToString()} ? {card1 == card2}");
            WriteLine($"{card1.ToString()} != {card3.ToString()} ? {card1 != card3}");
            WriteLine($"{card1.ToString()}.Equals({card4.ToString()}) ? " + $"{card1.Equals(card4)}");
            WriteLine($"Card.Equals({card3.ToString()}, {card4.ToString()}) ? " + $"{Card.Equals(card3, card4)}");
            WriteLine($"{card1.ToString()} > {card2.ToString()} ? {card1 > card2}");
            WriteLine($"{card1.ToString()} <= {card3.ToString()} ? {card1 <= card3}");
            WriteLine($"{card1.ToString()} > {card4.ToString()} ? {card1 > card4}");
            WriteLine($"{card4.ToString()} > {card1.ToString()} ? {card4 > card1}");
            WriteLine($"{card5.ToString()} > {card4.ToString()} ? {card5 > card4}");
            WriteLine($"{card4.ToString()} > {card5.ToString()} ? {card4 > card5}");
            ReadKey();
        }
    }
}
