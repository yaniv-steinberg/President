using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;

namespace President.HandsLogics
{
    class ComputerLogic
    {
        private List<Card> cardsInComputerHand;
        private ComputerHand computerHand;
        private Card.CardStateEnum face=Card.CardStateEnum.FaceDown;

        public ComputerLogic(ComputerHand computerHand)
        {
            this.computerHand = computerHand;
        }
        public void ChooseStartSelectedCards(List<Card>cards)
        {
            int j = 0;
            bool check = false;
            List<Card> tempList;
            Card minCard;
            Card maxCard = cards.Max();
            List<Card> tempList2;

            if(check == false)//check for four
            {
                while(j <= 12 && j <= (int)maxCard.CardType && check == false)
                {
                    tempList = cards.Where(c => (int)c.CardType >= j && (int)c.CardType != 1).ToList();

                    minCard = tempList.Min();
                    tempList2 = cards.Where(c => c.CardType == minCard.CardType).ToList();
                    if(tempList2.Count() == 4 && check == false)
                    {
                        foreach(Card card in tempList2)
                                card.Selected = true;
                        check = true;
                    }
                    j++;
                } 

                if(check == false)//check for three
                { 
                    j = 0;
                    while(j <= 12 && j <= (int)maxCard.CardType && check == false)
                    {
                        tempList = cards.Where(c => (int)c.CardType >= j && (int)c.CardType != 1).ToList();

                        minCard = tempList.Min();
                        tempList2 = cards.Where(c => c.CardType == minCard.CardType).ToList();
                        if(tempList2.Count() == 3 && check == false)
                        {
                            foreach(Card card in tempList2)
                                    card.Selected = true;
                            check = true;
                        }
                        j++;
                    }
                }

                 if(check == false)//check for two
                { 
                    j = 0;
                    while(j <= 12 && j <= (int)maxCard.CardType && check == false)
                    {
                        tempList = cards.Where(c => (int)c.CardType >= j && (int)c.CardType != 1).ToList();

                        minCard = tempList.Min();
                        tempList2 = cards.Where(c => c.CardType == minCard.CardType).ToList();
                        if(tempList2.Count() == 2 && check == false)
                        {
                            foreach(Card card in tempList2)
                                    card.Selected = true;
                            check = true;
                        }
                        j++;
                    }
                }

                 if(check == false)//selected one
                 {
                     tempList = cards.Where(c => (int)c.CardType != 1).ToList();
                     minCard = tempList.Min();
                     minCard.Selected = true;
                 }
            }
        }
        
        public ComputerHand LogicHand 
        {
            get { return computerHand; }
        }

        //adds the list of cards to the computer's hand
        public void AddCardsToComputerHand(List<Card> cards)
        {
            //sort the cards
            cardsInComputerHand = cards;
            cardsInComputerHand.Sort();

            int x = 20;

            computerHand.ClearCards();
            foreach(Card card in cardsInComputerHand)
            {               
                computerHand.AddCard(card, x);
                x = x + 80;
                card.CardState = face;
            }

        }

        //deletes the card from the computer hand
        public void RemoveCard(Card card) 
        {
            computerHand.RemoveCard(card);
        }
        
        //chooses the selected cards according to game's logic
        public void ChooseSelectedCard(List<Card> cards, Card.CardTypeEnum type, int roundtype) 
        {
            bool check = false;
            List<Card> tempList;
            List<Card> tempList2 = null;
            Card minCard;

            if(roundtype == 1)
            {
                tempList = cards.Where(c => c.CardType >= type && (int)c.CardType != 1).ToList();
                minCard = tempList.Min();

                if(minCard != null)
                    minCard.Selected = true;
            }
            else if(roundtype == 2)
            {
                int i = 0;
                int j = (int)type;

                while(j < 13 && check == false) 
                {
                    tempList = cards.Where(c => c.CardType >= type && (int)c.CardType != 1 && (int)c.CardType >= j).ToList();
                    minCard = tempList.Min();
                    if(minCard != null)
                       tempList2 = cards.Where(c => c.CardType == minCard.CardType).ToList(); 
                    if(tempList2 != null && tempList2.Count() > 1)
                    {
                        foreach(Card card in tempList2)
                            if(i < 2)
                            {
                                card.Selected = true;
                                i++;
                            }
                        check = true;
                    }
                    j++;
                }
            }

            else if(roundtype == 3)
            {
                int i = 0;
                int j = (int)type;

                while(j < 13 && check == false)
                {
                    tempList = cards.Where(c => c.CardType >= type && (int)c.CardType != 1 && (int)c.CardType >= j).ToList();
                    minCard = tempList.Min();

                    if(minCard != null)
                       tempList2 = cards.Where(c => c.CardType == minCard.CardType).ToList(); 
                    if(tempList2 != null && tempList2.Count() > 2)
                    {
                        foreach(Card card in tempList2)
                            if(i < 3)
                            {
                                card.Selected = true;
                                i++;
                            }
                        check = true;
                    }
                    j++;
                }
            }
        }

        //sorts the cards on computer's hand
        public void SortCards()
        {
            cardsInComputerHand.Sort();
        }

        public Card.CardStateEnum Face
        {
            get { return face; }
            set { face = value; }
        }

        public void SwapCardsState()
        {
            foreach (Card card in cardsInComputerHand)
            {
                if (card.CardState == Card.CardStateEnum.FaceDown)
                {
                    card.CardState = Card.CardStateEnum.FaceUp;
                    face = Card.CardStateEnum.FaceUp;
                }
                else
                {
                    card.CardState = Card.CardStateEnum.FaceDown;
                    face = Card.CardStateEnum.FaceDown;
                }
            }
        }
    }
}