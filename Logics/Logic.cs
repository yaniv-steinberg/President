using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using President.HandsLogics;
using President.Helper_Classes;
using President.UI_Elements;

namespace President
{
    public class Logic
    {
        public const int PLAYER_TURN = 1, RIGHT_TURN = 3, LEFT_TURN = 2;
        public const int PLAYER = 1, RIGHT_COMP = 3, LEFT_COMP = 2;
        private GameBoard gameBoard;
        private PlayerLogic playerLogic;
        private ComputerLogic compLogicRight;
        private ComputerLogic compLogicLeft;
        private KupaLogic kupaLogic;
        private DeckLogic deckLogic;
        private List<Card> cardsPassedToKupa;

        private List<Card> playerCards, rightCards, leftCards;//save
        private int passTimes = 0;//save
        private int roundType = 0;//save
        private bool fourburn = false; //save
        private int oneBurnTimes = 0;//save
        private int president = 0;
        private bool won = false;
        private bool leftWin = false;
        private bool rightWin = false;
        private bool playerWin = false;
        private int score;


        private Serializer serializer;
        private SerializedCardsLists serializedLeftCards;

        private GameMenu gameMenu;
        private bool firstTime=true;

        public Logic()
        {
            gameMenu = new GameMenu();
            gameBoard = new GameBoard();

            gameMenu.btnExit.Click += new EventHandler(btnExit_Click);
            gameMenu.btnInstructions.Click += new EventHandler(btnInstructions_Click);
            gameMenu.btnLoad.Click += new EventHandler(btnLoad_Click);
            gameMenu.btnSave.Click += new EventHandler(btnSave_Click);
            gameMenu.btnNewGame.Click += new EventHandler(btnNewGame_Click);
            gameMenu.btnResume.Click += new EventHandler(btnResume_Click);
            
            gameBoard.Load += new EventHandler(gameBoard_Load);
            gameBoard.btnStart.Click += new EventHandler(btnStart_Click);
            gameBoard.btnPlayerDone.Click += new EventHandler(btnPlayerDone_Click);
            gameBoard.KeyDown += new KeyEventHandler(gameBoard_KeyDown);
            gameBoard.btnShowHide.Click += this.btnShowHide_Click;
            gameBoard.btnMainMenu.Click += new EventHandler(btnMainMenu_Click);

            gameBoard.btnShowHide.Enabled = false;
            gameBoard.btnStart.Enabled = false;

            gameBoard.ShowDialog();
        }

        void btnResume_Click(object sender, EventArgs e)
        {
            gameMenu.Close();
        }

        void gameBoard_Load(object sender, EventArgs e)
        {
            gameMenu.ShowDialog();
        }

        void btnNewGame_Click(object sender, EventArgs e)
        {
            gameMenu.Close();
            gameBoard.btnShowHide.Enabled = true;
            if (firstTime)
            {
                Init();
                firstTime = false;
            }
            else
            {
                ResetBoard();
            }
            gameBoard.btnStart.Enabled = true;
        }

        //Saves the current game
        void btnSave_Click(object sender, EventArgs e)
        {
//            serializedLeftCards = new SerializedCardsLists();
//            serializedLeftCards.LeftCards = leftCards;
//            serializer = new Serializer();
//            serializer.SerializeObject("C:\\GameCards.txt", serializedLeftCards);
        }

        //loads the saved game
        void btnLoad_Click(object sender, EventArgs e)
        {
//            gameMenu.Close();
//            serializer.DeSerializeObject("C:\\GameCards.txt");
//            List<Card> cards = serializedLeftCards.LeftCards;
        }

        void btnInstructions_Click(object sender, EventArgs e)
        {
            Instructions instructions = new Instructions();
            instructions.ShowDialog();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            gameMenu.Close();
            CloseGameBoard();
        }

        public void Init()
        {
            score = 0;
            roundType = 0;
            president = 0;

            fourburn = false;
            passTimes = 0;

            leftWin = false;
            rightWin = false;
            playerWin = false;
            won = false;

            playerCards = new List<Card>();
            rightCards = new List<Card>();
            leftCards = new List<Card>();
            deckLogic = new DeckLogic();
            for (int i = 0; i < 52; i++)
            {
                if (i <= 17)
                    playerCards.Add(deckLogic.getdeck.cardsA[i]);
                else if (i <= 34)
                    rightCards.Add(deckLogic.getdeck.cardsA[i]);
                else if (i <= 51)
                    leftCards.Add(deckLogic.getdeck.cardsA[i]);
            }



            KupaUI kupaUI = gameBoard.KupaUI;
            kupaLogic = new KupaLogic(kupaUI);            

            ComputerHand computerHandRight = gameBoard.RightHand;
            compLogicRight = new ComputerLogic(computerHandRight);
            compLogicRight.AddCardsToComputerHand(rightCards);

            
            ComputerHand computerHandLeft = gameBoard.LeftHand;
            compLogicLeft = new ComputerLogic(computerHandLeft);            
            compLogicLeft.AddCardsToComputerHand(leftCards);

            PlayerHand playerHand = gameBoard.PlayerHand;
            playerLogic = new PlayerLogic(playerHand);            
            playerLogic.AddCardsToPlayerHand(playerCards);

            playerLogic.PlayerCardsClickable = false;
            playerLogic.HighestCardType = Card.CardTypeEnum.Ace;

        }

        void btnMainMenu_Click(object sender, EventArgs e)
        {
            gameMenu.ShowDialog();            
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            compLogicLeft.SwapCardsState();
            compLogicRight.SwapCardsState();
        }
        
        void gameBoard_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.F2)
            {
                compLogicLeft.SwapCardsState();
                compLogicRight.SwapCardsState();
            }
        }

        private void btnPlayerDone_Click(object sender, EventArgs e)
        {
            bool okmove = true;
            fourburn = false;
            Card burnchecktwo = new Card(1);
            Card burncheckfour;
            cardsPassedToKupa = playerCards.Where(c => c.Selected).ToList();

            if(kupaLogic.KupaCards.Count != 0 && cardsPassedToKupa.Count != 0)
            {
                bool containsTwo =
                       cardsPassedToKupa.Where(c => c.CardType == Card.CardTypeEnum.Two).ToList().Count > 0;
                if(!containsTwo)
                    if(cardsPassedToKupa.Count != roundType)
                    {
                        okmove = false;
                        switch(roundType)
                        {
                            case 1:
                                gameBoard.Message("You must put one card only!");
                                break;
                            default:
                                gameBoard.Message("you must put " + roundType + " cards only!");
                                break;
                                
                        }
                    }
            }
            if(okmove==true)
            {

                foreach(Card card in cardsPassedToKupa)
                    card.Clickable = false;

                switch(cardsPassedToKupa.Count)
                {
                    case 0:
                        { 
                            passTimes++;
                            gameBoard.txtMessages.Text = "Player Passed His Turn...";
                        }
                        break;
                    case 1:
                        {
                            roundType = 1;
                            passTimes = 0;
                            burnchecktwo = cardsPassedToKupa[0];
                            if (kupaLogic.KupaCards.Count == 0 ||
                                cardsPassedToKupa[0].CardType != kupaLogic.LastCard.CardType)
                                oneBurnTimes = 0;
                            else if (cardsPassedToKupa[0].CardType == kupaLogic.LastCard.CardType)
                                oneBurnTimes++;

                        }
                        break;
                    case 2:
                        {
                            roundType = 2;
                            passTimes = 0;
                            if (kupaLogic.KupaCards.Count > 0)
                            {
                                burncheckfour = kupaLogic.LastCard;
                                if (burncheckfour.CardType == cardsPassedToKupa[0].CardType)
                                    fourburn = true;
                            }
                        }
                        break;
                    case 3:
                        {
                            roundType = 3;
                            passTimes = 0;
                        }
                        break;
                    case 4:
                        {
                            fourburn = true;
                        }
                        break;
                }

                foreach(Card card in cardsPassedToKupa)
                {
                    playerLogic.RemoveCard(card);
                    playerCards.Remove(card);
                }

                kupaLogic.AddCardsToKupa(cardsPassedToKupa);
                cardsPassedToKupa.Clear();

                playerCards.Sort();
                playerCards = playerCards.Where(c => !c.Selected).ToList();
                gameBoard.Refresh();
                
                if(fourburn == true)
                {
                    DeleteAllKupaCardsSet();
                    playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                }
                if(oneBurnTimes == 3)
                {
                    Thread.Sleep(1000);
                    kupaLogic.DeleteAllKupaCards();
                    TurnsManager.BackTurn();
                    oneBurnTimes = 0;
                    playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                }
                if(burnchecktwo.CardType == Card.CardTypeEnum.Two)
                {
                    Thread.Sleep(1000);
                    kupaLogic.DeleteAllKupaCards();
                    TurnsManager.BackTurn();
                    playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                    gameBoard.txtMessages.Text = "Player Burned The Deck";
                }
                if(playerCards.Count == 0)
                {
                    won = true;
                    president = PLAYER;
                    playerWin = true;
                }
                gameBoard.Refresh();
                checkWinners();

                if(won==false)
                {
                    TurnsManager.AdvanceTurn(); 
                    Thread.Sleep(1000);
                    UpdateUIBehaviours();
                    SystemSounds.Beep.Play();
                    ComputerMoves();
                    if(passTimes == 2)
                    {
                        Thread.Sleep(1000);
                        kupaLogic.DeleteAllKupaCards();
                        playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameBoard.btnShowHide.Enabled = true;
            gameBoard.btnStart.Enabled = false;
            playerLogic.PlayerCardsClickable = true;
            TurnsManager.SetFirstTurn(FirstPlayer());
            UpdateUIBehaviours();
            ComputerMoves();
        }

        private void UpdateUIBehaviours()
        {
            switch (TurnsManager.GetCurrentTurn())
            {
                case PLAYER_TURN:
                    playerLogic.LogicHand.BackColor = Color.Blue;
                    compLogicLeft.LogicHand.BackColor = Color.Gold;
                    compLogicRight.LogicHand.BackColor = Color.Gold;
                    gameBoard.txtMessages.Text = "Player's Turn...";
                    gameBoard.btnPlayerDone.Enabled = true;
                    gameBoard.lblPlayerNameLabel.Text = "Player's Turn";
                    gameBoard.Refresh();
                    
                    break;
                case LEFT_TURN:
                    playerLogic.LogicHand.BackColor = Color.Gold;
                    compLogicLeft.LogicHand.BackColor = Color.Blue;
                    compLogicRight.LogicHand.BackColor = Color.Gold;
                    gameBoard.txtMessages.Text = "Left Computer's Turn...";
                    gameBoard.btnPlayerDone.Enabled = false;
                    gameBoard.lblPlayerNameLabel.Text = "Left Computer's Turn";
                    gameBoard.Refresh();

                    break;
                case RIGHT_TURN:
                    playerLogic.LogicHand.BackColor = Color.Gold;
                    compLogicLeft.LogicHand.BackColor = Color.Gold;
                    compLogicRight.LogicHand.BackColor = Color.Blue;
                    gameBoard.txtMessages.Text = "Right Computer's Turn...";
                    gameBoard.btnPlayerDone.Enabled = false;
                    gameBoard.lblPlayerNameLabel.Text = "Right Computers's Turn";
                    gameBoard.Refresh();

                    break;
            }
        }


        private void ComputerMoves()
        {
            while (won == false && TurnsManager.GetCurrentTurn() != PLAYER_TURN)     
            {                    
                fourburn = false;
                Card burncheckfour = null;
                bool HighestCardChangeCheck = false;
                Thread.Sleep(1000);
                switch(TurnsManager.GetCurrentTurn())
                {
                    case LEFT_TURN:
                        {
                            if(!leftWin)
                            {
                                if(passTimes == 2)
                                {
                                    kupaLogic.DeleteAllKupaCards();
                                    gameBoard.Refresh();
                                    Thread.Sleep(1000);
                                    HighestCardChangeCheck = true;
                                }

                                if(kupaLogic.KupaCards.Count != 0)
                                {
                                    compLogicLeft.ChooseSelectedCard(leftCards, kupaLogic.LastCard.CardType, roundType);
                                }
                                else
                                {
                                    compLogicLeft.ChooseStartSelectedCards(leftCards);
                                }

                                cardsPassedToKupa = leftCards.Where(c => c.Selected).ToList();
                                foreach(Card card in cardsPassedToKupa)
                                {
                                    compLogicLeft.RemoveCard(card);
                                    leftCards.Remove(card);
                                }

                                if(cardsPassedToKupa.Count() > 0)
                                {
                                    passTimes = 0;
                                    
                                    leftCards.Sort();
                                    
                                    if(cardsPassedToKupa.Count == 1)
                                    {
                                        if(kupaLogic.KupaCards.Count == 0 ||
                                            cardsPassedToKupa[0].CardType != kupaLogic.LastCard.CardType)
                                            oneBurnTimes = 0;
                                        else if(cardsPassedToKupa[0].CardType == kupaLogic.LastCard.CardType)
                                            oneBurnTimes++;
                                    }

                                    if(kupaLogic.KupaCards.Count > 0)
                                    {
                                        burncheckfour = kupaLogic.LastCard;
                                    }

                                    roundType = cardsPassedToKupa.Count();
                                    kupaLogic.AddCardsToKupa(cardsPassedToKupa);
                                    
                                    compLogicLeft.AddCardsToComputerHand(leftCards);
                                    gameBoard.Refresh();
                                    Thread.Sleep(1000);
                                    if(cardsPassedToKupa.Count == 4)
                                    {
                                        kupaLogic.DeleteAllKupaCards();
                                        TurnsManager.BackTurn();
                                        HighestCardChangeCheck = true;
                                    }
                                    if(cardsPassedToKupa.Count == 2)
                                    {
                                        if(kupaLogic.KupaCards.Count > 1)
                                        {
                                            if(burncheckfour != null &&
                                                burncheckfour.CardType == cardsPassedToKupa[0].CardType)
                                            {
                                                gameBoard.Refresh();
                                                kupaLogic.DeleteAllKupaCards();
                                                TurnsManager.BackTurn();
                                                HighestCardChangeCheck = true;
                                            }
                                        }
                                    }
                                    if(oneBurnTimes == 3)
                                    {
                                        kupaLogic.DeleteAllKupaCards();
                                        TurnsManager.BackTurn();
                                        oneBurnTimes = 0;
                                        HighestCardChangeCheck = true;
                                    }
                                }
                                else
                                {
                                    Card tempcard = new Card(1);
                                    foreach(Card card in leftCards)
                                        if(card.CardType == Card.CardTypeEnum.Two)
                                            tempcard = card;
                                    if(tempcard.CardId != 1)
                                    {
                                        cardsPassedToKupa.Add(tempcard);
                                        leftCards.Sort();
                                        leftCards = leftCards.Where(c => c != tempcard).ToList();
                                        compLogicLeft.RemoveCard(cardsPassedToKupa[0]);
                                        leftCards.Remove(cardsPassedToKupa[0]);
                                        kupaLogic.AddCardsToKupa(cardsPassedToKupa);
                                        compLogicLeft.SortCards();
                                        compLogicLeft.AddCardsToComputerHand(leftCards);
                                        gameBoard.txtMessages.Text = "Left Computer Burned The Deck.";
                                        gameBoard.Refresh();
                                        Thread.Sleep(1000);
                                        kupaLogic.DeleteAllKupaCards();
                                        TurnsManager.BackTurn();
                                        HighestCardChangeCheck = true;
                                    }
                                    else
                                    {
                                        gameBoard.txtMessages.Text = "Left Computer Passed Is Turn...";
                                        gameBoard.Refresh();
                                        passTimes++;
                                        Thread.Sleep(1000);
                                    }
                                }
                                if(HighestCardChangeCheck == true)
                                    playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                                else
                                    playerLogic.HighestCardType = kupaLogic.LastCard.CardType;
                                if(leftCards.Count == 0)
                                {
                                    won = true;
                                    president = LEFT_COMP;
                                    leftWin = true;
                                    playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                                }
                            }
                            else
                                passTimes++;
                            checkWinners();
                            break;
                        }

                    case RIGHT_TURN:
                        {
                            if(!rightWin)
                            {
                                if(passTimes == 2)
                                {
                                    kupaLogic.DeleteAllKupaCards();
                                    HighestCardChangeCheck = true;
                                    gameBoard.Refresh();
                                    Thread.Sleep(1000);
                                }

                                if(kupaLogic.KupaCards.Count != 0)
                                {
                                    compLogicRight.ChooseSelectedCard(rightCards, kupaLogic.LastCard.CardType, roundType);
                                }
                                else
                                {
                                    compLogicRight.ChooseStartSelectedCards(rightCards);
                                }
                                cardsPassedToKupa = rightCards.Where(c => c.Selected).ToList();
                                foreach(Card card in cardsPassedToKupa)
                                {
                                    compLogicRight.RemoveCard(card);
                                    rightCards.Remove(card);
                                }
                                if(cardsPassedToKupa.Count() > 0)
                                {
                                    passTimes = 0;
                                    rightCards.Sort();
                                    if(cardsPassedToKupa.Count == 1)
                                    {
                                        if(kupaLogic.KupaCards.Count == 0 ||
                                            cardsPassedToKupa[0].CardType != kupaLogic.LastCard.CardType)
                                            oneBurnTimes = 0;
                                        else if(cardsPassedToKupa[0].CardType == kupaLogic.LastCard.CardType)
                                            oneBurnTimes++;
                                    }
                                    rightCards = rightCards.Where(c => !c.Selected).ToList();
                                    if(kupaLogic.KupaCards.Count > 0)
                                        burncheckfour = kupaLogic.LastCard;
                                    
                                    roundType = cardsPassedToKupa.Count;
                                    kupaLogic.AddCardsToKupa(cardsPassedToKupa);
                                    compLogicRight.SortCards();
                                    compLogicRight.AddCardsToComputerHand(rightCards);
                                    gameBoard.Refresh();
                                    Thread.Sleep(1000);
                                    if(cardsPassedToKupa.Count == 4)
                                    {
                                        kupaLogic.DeleteAllKupaCards();
                                        TurnsManager.BackTurn();
                                        HighestCardChangeCheck = true;
                                    }
                                    if(cardsPassedToKupa.Count == 2)
                                    {
                                        if(kupaLogic.KupaCards.Count > 1)
                                        {
                                            if(burncheckfour != null &&
                                                burncheckfour.CardType == cardsPassedToKupa[0].CardType)
                                            {
                                                gameBoard.Refresh();
                                                kupaLogic.DeleteAllKupaCards();
                                                TurnsManager.BackTurn();
                                                HighestCardChangeCheck = true;
                                            }
                                        }
                                    }
                                    if(oneBurnTimes == 3)
                                    {
                                        kupaLogic.DeleteAllKupaCards();
                                        TurnsManager.BackTurn();
                                        oneBurnTimes = 0;
                                        HighestCardChangeCheck = true;
                                    }
                                }

                                else
                                {
                                    Card tempcard = new Card(1);
                                    foreach(Card card in rightCards)
                                        if((int)card.CardType == 1)
                                            tempcard = card;
                                    if(tempcard.CardId != 1)
                                    {
                                        cardsPassedToKupa.Add(tempcard);
                                        rightCards.Sort();
                                        rightCards = rightCards.Where(c => c != tempcard).ToList();
                                        compLogicRight.RemoveCard(cardsPassedToKupa[0]);
                                        rightCards.Remove(cardsPassedToKupa[0]);
                                        kupaLogic.AddCardsToKupa(cardsPassedToKupa);
                                        compLogicRight.SortCards();
                                        compLogicRight.AddCardsToComputerHand(rightCards);
                                        gameBoard.txtMessages.Text = "Right Computer Burned The Deck.";
                                        gameBoard.Refresh();
                                        Thread.Sleep(1000);
                                        kupaLogic.DeleteAllKupaCards();
                                        TurnsManager.BackTurn();
                                        HighestCardChangeCheck = true;
                                    }
                                    else
                                    {
                                        gameBoard.txtMessages.Text = "Right Computer Passed Is Turn...";
                                        gameBoard.Refresh();
                                        passTimes++;
                                        Thread.Sleep(1000);
                                    }
                                }
                                if(HighestCardChangeCheck == true)
                                    playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                                else
                                    playerLogic.HighestCardType = kupaLogic.LastCard.CardType;//check maybe don't need tp indent inside 'else'
                                if(rightCards.Count == 0)
                                {
                                    won = true;
                                    president = RIGHT_COMP;
                                    rightWin = true;
                                    playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                                }
                            }
                            else
                                passTimes++;
                            checkWinners();
                            break;
                        }
                }
                gameBoard.Refresh();
                SystemSounds.Beep.Play();
                TurnsManager.AdvanceTurn();
                UpdateUIBehaviours();
            }
            if(playerWin)
            {
                passTimes++;
                TurnsManager.AdvanceTurn();
            }
        }

        public int FirstPlayer()
        {
            if(
                playerCards.Where(
                    c => (c.CardType == Card.CardTypeEnum.Three) && (c.CardSuit == Card.CardSuitsEnum.Clubs)).ToList().
                    Count() > 0)
                return 1;
            if(
                rightCards.Where(
                    c => (c.CardType == Card.CardTypeEnum.Three) && (c.CardSuit == Card.CardSuitsEnum.Clubs)).ToList().
                    Count() > 0)
                return 3;
            return 2;
        }


        private void ResetBoard()
        {
            gameBoard.btnShowHide.Enabled = false;
            won = false;
            roundType = 0; //save

            president = 0;

            fourburn = false; //save
            passTimes = 0; //save

            leftWin = false;
            rightWin = false;
            playerWin = false;

            playerCards = new List<Card>(); //save
            rightCards = new List<Card>(); //save
            leftCards = new List<Card>(); //save
            deckLogic = new DeckLogic(); //save

            gameBoard.btnStart.Enabled = true;
            gameBoard.btnPlayerDone.Enabled = false;

            for(int i = 0; i < 52; i++)
            {
                if(i <= 17)
                    playerCards.Add(deckLogic.getdeck.cardsA[i]);
                else if(i <= 34)
                    rightCards.Add(deckLogic.getdeck.cardsA[i]);
                else if(i <= 51)
                    leftCards.Add(deckLogic.getdeck.cardsA[i]);
            }

            kupaLogic.DeleteAllKupaCards();
            KupaUI kupaUI = gameBoard.KupaUI;
            kupaLogic = new KupaLogic(kupaUI);

            ComputerHand computerHandRight = gameBoard.RightHand;
            compLogicRight = new ComputerLogic(computerHandRight);
            compLogicRight.AddCardsToComputerHand(rightCards);


            ComputerHand computerHandLeft = gameBoard.LeftHand;
            compLogicLeft = new ComputerLogic(computerHandLeft);
            compLogicLeft.AddCardsToComputerHand(leftCards);

            PlayerHand playerHand = gameBoard.PlayerHand;
            playerLogic = new PlayerLogic(playerHand);
            playerLogic.AddCardsToPlayerHand(playerCards);

            playerLogic.PlayerCardsClickable = false;

            gameBoard.txtMessages.Text = "";
            gameBoard.lblPlayerNameLabel.Text = "";

            gameBoard.Refresh();
        }

        public void checkWinners()
        {
            if(won == true)
            {
                gameBoard.btnPlayerDone.Enabled = false;
                playerLogic.PlayerCardsClickable = false;
                gameBoard.Message("The President Is: " + ConvertNumToName(president) + "!" + "\r\n" + "                  Gameover!");
                kupaLogic.DeleteAllKupaCards();
                playerLogic.HighestCardType = Card.CardTypeEnum.Ace;
                gameBoard.btnPlayerDone.Enabled = false;
                MakePlayerScore();
            }
        }

        public string ConvertNumToName(int num)
        {
            switch (num)
            {
                case 1: return "Player";
                case 2: return "Left Computer";
                case 3: return "Right Computer";
                default: return "";
            }
        }

        public void DeleteAllKupaCardsSet()
        {
            Thread.Sleep(1000);
            kupaLogic.DeleteAllKupaCards();
            TurnsManager.BackTurn();
        }

        public void MakePlayerScore()
        {
            int score = 150;
            if(president == 1)
            {
                score = score + 150;
                foreach(Card card in leftCards)
                    score = score + 10;
                foreach(Card card in rightCards)
                    score = score + 10;
            }
            else
            {
                foreach(Card card in leftCards)
                    score = score - 10;
                foreach(Card card in rightCards)
                    score = score - 10;
            }
            this.score = score;
        }

        public void CloseGameBoard()
        {
            gameBoard.Close();
        }
    }
}

