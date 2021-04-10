using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace President
{
    class Deck
    {
        public Card [] cardsA = new Card[52];
        public Deck()
        {
            for(int i = 0; i <= 51; i++)
            {  
                cardsA[i] = new Card(i + 1);
            }
        }

        //shuffles the deck
        public void ShuffleCards() 
        {
            cardsA = Shuffler.Shuffle(cardsA);
        }
    }
}
