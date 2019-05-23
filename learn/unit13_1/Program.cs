using System;

namespace unit13_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            try
            {
                Card myCard = deck1.GetCard(60);
            }
            catch (CardOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.DeckContents[0]);
            }
        }
    }
}
