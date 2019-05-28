using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit13_3
{
    public class Cards : CollectionBase, ICloneable
    {
        public void Add(Card newCrad) => List.Add(newCrad);
        public void Remove(Card oldCrad) => List.Remove(oldCrad);
        public Card this[int cardIndex]
        {
            get { return (Card)List[cardIndex]; }
            set { List[cardIndex] = value; }
        }
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        public bool Contains(Card card) => InnerList.Contains(card);
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in List)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }
    }
}