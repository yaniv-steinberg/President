using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace President
{
    class DeckLogic
    {
        Deck deck;

        //initialize a new deck
        public DeckLogic() 
        {
            this.deck = new Deck();
            this.deck.ShuffleCards();
        }
        public Deck getdeck
        {
            get { return deck; }
        }
    }
}
