using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace President
{
    public static class Shuffler
    {
        // Based on Fisher-Yates Shuffle algorithm.
        // Taken from http://www.dotnetperls.com/shuffle, with some changes.

        static Random random = new Random();
    
        //shuffles the given deck
        public static Card[] Shuffle(Card[] cards) 
        {
            var random = Shuffler.random;
            for (int i = cards.Length; i > 1; i--)
            {
                // chooses a random num to swap
                int j = random.Next(i); // 0 <= j <= i - 1 
                // swaps
                Card tmp = cards[j];
                cards[j] = cards[i - 1];
                cards[i - 1] = tmp;
            }

            return cards;
        }
    }
}
