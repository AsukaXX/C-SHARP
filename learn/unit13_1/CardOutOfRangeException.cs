using System;

namespace unit13_1
{
    public class CardOutOfRangeException : Exception
    {
        private Cards deckContents;
        public Cards DeckContents
        {
            get { return deckContents; }
        }
        public CardOutOfRangeException(Cards sourceDeckContents) : base("There are only 52 cards int the deck.")
        {
            deckContents = sourceDeckContents;
        }
    }
}