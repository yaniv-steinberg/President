using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace President
{
    [Serializable()]
    public partial class Card : UserControl, IComparable, ISerializable
    {
        private int cardId;
        private Image cardImage;
        private Image cardBackImage = Images._54;
        private bool clickable;
        private CardTypeEnum cardType;
        private CardSuitsEnum cardSuit;

        private CardStateEnum cardState = CardStateEnum.FaceDown;

        
        private bool selected;


        public event Delegates.CardClickedEventHandler OnCardClicked;
      
        public Card(int cardId) //יוצרת קלף חדש ע"פ מזהה
        {
            InitializeComponent();
            this.cardId = cardId;
            this.cardSuit = (CardSuitsEnum)((cardId - (int)cardType - 1) / 13);
            this.cardType = (CardTypeEnum)((int)cardId - 1 - (int)cardSuit * 13);
            cardId = ((int)cardSuit * 13) + (int)cardType + 1;
            AssignCardImage();
            BackgroundImageLayout = ImageLayout.Center;
            
            if (cardId <= 52)
            {
                cardImage = BackgroundImage;

                Width = cardImage.Width + 5;
                Height = cardImage.Height + 5;
            }
            Click += Card_Click;



        }
       
        public Card(CardTypeEnum cardType, CardSuitsEnum cardSuit)// יוצרת קלף חדש ע"פ צורה ומספר
        {
            InitializeComponent();

            this.cardSuit = cardSuit;
            this.cardType = cardType;

            cardId = ((int) cardSuit*13) + (int) cardType + 1;
            AssignCardImage();
            BackgroundImageLayout = ImageLayout.Center;

            cardImage = BackgroundImage;
            
            Width = cardImage.Width + 5;
            Height = cardImage.Height + 5;

            Click += Card_Click;
            
        }

        public void Card_Click(object sender, EventArgs e) //פעולת לחיצה על קלף
        {
            if (clickable)
            {
                // "selected" מחזיק את הסטטוס הבחור של הקלף
                // המאורע "OnCardClicked" נורה ואז נתפס ע"י הלוגיק, הוא אמור להחליט מתי אנחנו
                // מאשרים לקלף להיות מסומן כבחור. המאורע מחזיר משתנה בוליאני
                bool allowToSelect = OnCardClicked(this);
                if (allowToSelect)
                {
                    selected = true;
                    BackColor = Color.CornflowerBlue;
                }
                else
                {
                    selected = false;
                    BackColor = Color.Transparent;
                }
            }
        }

       
     
            

        public bool Selected //פעולת החזרה ושינוי לבחירת הקלף 
        {
            get { return selected; }
            set
            {
                selected = value;
                if (value == false)
                    BackColor = Color.Transparent;
                else
                     BackColor = Color.CornflowerBlue;
            }
        }


        private void AssignCardImage()// מקצה את תמונת הקלף לקלף המתאים
        {
        
            switch (cardId)
            {
                case 1:
                    BackgroundImage = Images._1;
                    break;
                case 2:
                    BackgroundImage = Images._2;
                    break;
                case 3:
                    BackgroundImage = Images._3;
                    break;
                case 4:
                    BackgroundImage = Images._4;
                    break;
                case 5:
                    BackgroundImage = Images._5;
                    break;
                case 6:
                    BackgroundImage = Images._6;
                    break;
                case 7:
                    BackgroundImage = Images._7;
                    break;
                case 8:
                    BackgroundImage = Images._8;
                    break;
                case 9:
                    BackgroundImage = Images._9;
                    break;
                case 10:
                    BackgroundImage = Images._10;
                    break;
                case 11:
                    BackgroundImage = Images._11;
                    break;
                case 12:
                    BackgroundImage = Images._12;
                    break;
                case 13:
                    BackgroundImage = Images._13;
                    break;
                case 14:
                    BackgroundImage = Images._14;
                    break;
                case 15:
                    BackgroundImage = Images._15;
                    break;
                case 16:
                    BackgroundImage = Images._16;
                    break;
                case 17:
                    BackgroundImage = Images._17;
                    break;
                case 18:
                    BackgroundImage = Images._18;
                    break;
                case 19:
                    BackgroundImage = Images._19;
                    break;
                case 20:
                    BackgroundImage = Images._20;
                    break;
                case 21:
                    BackgroundImage = Images._21;
                    break;
                case 22:
                    BackgroundImage = Images._22;
                    break;
                case 23:
                    BackgroundImage = Images._23;
                    break;
                case 24:
                    BackgroundImage = Images._24;
                    break;
                case 25:
                    BackgroundImage = Images._25;
                    break;
                case 26:
                    BackgroundImage = Images._26;
                    break;
                case 27:
                    BackgroundImage = Images._27;
                    break;
                case 28:
                    BackgroundImage = Images._28;
                    break;
                case 29:
                    BackgroundImage = Images._29;
                    break;
                case 30:
                    BackgroundImage = Images._30;
                    break;
                case 31:
                    BackgroundImage = Images._31;
                    break;
                case 32:
                    BackgroundImage = Images._32;
                    break;
                case 33:
                    BackgroundImage = Images._33;
                    break;
                case 34:
                    BackgroundImage = Images._34;
                    break;
                case 35:
                    BackgroundImage = Images._35;
                    break;
                case 36:
                    BackgroundImage = Images._36;
                    break;
                case 37:
                    BackgroundImage = Images._37;
                    break;
                case 38:
                    BackgroundImage = Images._38;
                    break;
                case 39:
                    BackgroundImage = Images._39;
                    break;
                case 40:
                    BackgroundImage = Images._40;
                    break;
                case 41:
                    BackgroundImage = Images._41;
                    break;
                case 42:
                    BackgroundImage = Images._42;
                    break;
                case 43:
                    BackgroundImage = Images._43;
                    break;
                case 44:
                    BackgroundImage = Images._44;
                    break;
                case 45:
                    BackgroundImage = Images._45;
                    break;
                case 46:
                    BackgroundImage = Images._46;
                    break;
                case 47:
                    BackgroundImage = Images._47;
                    break;
                case 48:
                    BackgroundImage = Images._48;
                    break;
                case 49:
                    BackgroundImage = Images._49;
                    break;
                case 50:
                    BackgroundImage = Images._50;
                    break;
                case 51:
                    BackgroundImage = Images._51;
                    break;
                case 52:
                    BackgroundImage = Images._52;
                    break;
                default:
                    break;
               
                
            }
        }

        public CardTypeEnum CardType //פעולת החזרה למספר הקלף 
        {
            get { return cardType; }
        }

        public CardSuitsEnum CardSuit //פעולת החזרה לצורת הקלף 
        {
            get { return cardSuit; }
        }

        public CardStateEnum CardState //פעולת החזרה ושינוי למצב הקלף
        {
            get { return cardState; }
            set
            {
                cardState = value;
                if (value == CardStateEnum.FaceDown)
                    BackgroundImage = cardBackImage;
                else
                    BackgroundImage = cardImage;
            }
        }

        public bool Clickable //פעולת החזרה ושינוי לאפשרות ההקלקה של קלף 
        {
            get { return clickable; }
            set { clickable = value; }
        }
        public int CardId //פעולת החזרה למזהה הקלף
        {
            get { return cardId; }
        }

        public enum CardTypeEnum 
        {
            Ace = 0,
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,
            Jack = 10,
            Queen = 11,
            King = 12
        }

        public enum CardSuitsEnum
        {
            Clubs = 0,
            Diamonds = 1,
            Hearts = 2,
            Spades = 3
        }

        public enum CardStateEnum
        {
            FaceUp,
            FaceDown
        }

        public int CompareTo(object otherCard) //פעולת השוואה בין ערכי הקלפים
        {
            if(this.cardType>((Card)otherCard).cardType)
                return 1;
            else
                return -1;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("cardId", this.cardId);

        }
    }

}
