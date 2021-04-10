using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace President.HandsLogics
{
    class KupaLogic
    {
        private KupaUI kupaUI;
        private Card lastCard;

        private List<Card> kupaCards = new List<Card>();


        //builds the stock's logic
        public KupaLogic(KupaUI kupaUI) 
        {
            this.kupaUI = kupaUI;
        }

        public KupaUI KupaUI
        {
            get { return kupaUI; }
        }
     
        //adds the cards to the stock
        public void AddCardsToKupa(List<Card> cards) 
        {
            kupaCards.AddRange(cards);
            int j = 1;

            if(cards.Count() == 1)
            {
                cards[0].CardState = Card.CardStateEnum.FaceUp;
                cards[0].Selected = false;
                cards[0].Clickable = false;
                kupaUI.RoundType = 1;
                kupaUI.AddCard(cards[0], j);
                lastCard = cards[0];
            }

            if(cards.Count() == 2)
            {
                foreach(Card card in cards)
                {
                    card.CardState = Card.CardStateEnum.FaceUp;
                    card.Selected = false;
                    card.Clickable = false;
                    kupaUI.RoundType = 2;
                    kupaUI.AddCard(card, j);
                    lastCard = card;
                    j++;
                }
            }

            if (cards.Count() == 3)
            {
                foreach (Card card in cards)
                {
                    card.CardState = Card.CardStateEnum.FaceUp;
                    card.Selected = false;
                    card.Clickable = false;
                    kupaUI.RoundType = 3;
                    kupaUI.AddCard(card, j);
                    lastCard = card;
                    j++;
                }

            }

            if (cards.Count() == 4)
            {
                foreach (Card card in cards)
                {
                    card.CardState = Card.CardStateEnum.FaceUp;
                    card.Selected = false;
                    card.Clickable = false;
                    kupaUI.RoundType = 3;
                    kupaUI.AddCard(card, j);
                    lastCard = card;
                    j++;
                }
            }
        }

        public List<Card> KupaCards
        {
            get { return kupaCards; }
            set { kupaCards = value; }
        }

        public Card LastCard
        {
            get { return lastCard; }
        }

        public void DeleteAllKupaCards()
        {
            foreach(Card kupaCard in kupaCards)
            {
                kupaUI.CardArea.Controls.Remove(kupaCard);
            }

            kupaUI.Reset();
            kupaCards.Clear();
        }
    }
}

