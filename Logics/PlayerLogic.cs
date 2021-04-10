using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace President.HandsLogics
{
    class PlayerLogic
    {
        private List<Card> cardsInPlayerHand;
        private PlayerHand playerHand;
        private Card.CardTypeEnum highestCardType = Card.CardTypeEnum.Ace;

        public PlayerLogic(PlayerHand playerHand) 
        {
            this.playerHand = playerHand;        
        }

        public Card.CardTypeEnum HighestCardType
        {
            set { highestCardType = value; }
        }

        public PlayerHand LogicHand
        {
            get { return playerHand; }
        }

        public bool PlayerCardsClickable 
        {
            set
            {
                foreach(Card card in cardsInPlayerHand)
                    card.Clickable = value;
            }
        }

        //adds cards to the players hand
        public void AddCardsToPlayerHand(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                card.OnCardClicked += new Delegates.CardClickedEventHandler(card_OnCardClicked);
                card.Clickable = true; 
            }

            // sort the cards
            cardsInPlayerHand = cards;
            cardsInPlayerHand.Sort();

            int x = 3;

            playerHand.ClearCards();
            foreach(Card card in cardsInPlayerHand)
            {
                playerHand.AddCard(card, x);
                x = x + 55;
            }

        }

        bool card_OnCardClicked(Card senderCard)
        {
            if (senderCard.Selected)
                return false;
            List<Card> selectedCards = cardsInPlayerHand.Where(c=> c.Selected).ToList();
            if(senderCard.CardType == Card.CardTypeEnum.Two && selectedCards.Count > 0)
                return false;

            List<Card> selectedSameTypeCards =
                cardsInPlayerHand.Where(c => c.CardType == senderCard.CardType && c.Selected).ToList();

            if(cardsInPlayerHand.Where(c => c.Selected).ToList().Count == 0 && (senderCard.CardType >= highestCardType || senderCard.CardType == Card.CardTypeEnum.Two))
                return true;

            if(selectedSameTypeCards.Count > 0 && (senderCard.CardType >= highestCardType || senderCard.CardType == Card.CardTypeEnum.Two))
                return true; // selected
            
            

            return false; // not selected
        }

        //deletes the given card from the players hand
        public void RemoveCard(Card card) 
        {
            playerHand.RemoveCard(card);
        }

        //sorts the player's cards
        public void SortCards()
        {
            cardsInPlayerHand.Sort();
        }
    }
}