using System.Drawing;
using System.Windows.Forms;

namespace President
{
    public class KupaUI : UserControl
    {
        private int deckNum;
        private int roundType = 1;
        private int y1, y2, y3;
        private Panel cardArea;

        public KupaUI()
        {
            InitializeComponent();
            Load += new System.EventHandler(KupaUI_Load);
        }

        void KupaUI_Load(object sender, System.EventArgs e)
        {
            Reset();

        }

        public Panel CardArea
        {
            get { return cardArea; }
        }

        public int RoundType
        {
            set { roundType = value; }
        }


        public void AddCard(Card card, int deckNum) //פעולה שמוסיפה את הקלף שהתקבל לחבילה הנתונה
        {
            this.deckNum = deckNum;
            AddCard(card);
        }
        public void Reset()
        {
            y1 = cardArea.Height - 75;
            y2 = cardArea.Height - 75;
            y3 = cardArea.Height - 75;
        }

        private void AddCard(Card card) //פעולה שמוסיפה את הקלף שהתקבל
        {
            Point mid;
            if (roundType == 1)
            {
                mid = new Point((cardArea.Width / 2) - card.Width / 2, y1);
                y1 -= 20;
            }
            else
            {
                if (roundType == 2)
                {
                    if (deckNum == 1)
                    {
                        mid = new Point((cardArea.Width / 3) - card.Width / 2, y1);
                        y1 -= 20;
                    }
                    else
                    {
                        mid = new Point((cardArea.Width * 2 / 3) - card.Width / 2, y2);
                        y2 -= 20;
                    }

                }

                else // שלוש חבילות
                {
                    if (deckNum == 1)
                    {
                        mid = new Point((cardArea.Width / 2) - card.Width / 2, y1);
                        y1 -= 20;
                    }
                    else
                    {
                        if (deckNum == 2)
                        {
                            mid = new Point((cardArea.Width * 1 / 4) - card.Width / 2, y2);
                            y2 -= 20;
                        }
                        else
                        {
                            mid = new Point((cardArea.Width * 3 / 4) - card.Width / 2, y3);
                            y3 -= 20;
                        }
                    }
                }
            }
            card.Location = mid;
            cardArea.Controls.Add(card);
            card.BringToFront();

        }

        private void InitializeComponent()
        {
            this.cardArea = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cardArea
            // 
            this.cardArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardArea.AutoScroll = true;
            this.cardArea.BackColor = System.Drawing.Color.Green;
            this.cardArea.Location = new System.Drawing.Point(14, 14);
            this.cardArea.Name = "cardArea";
            this.cardArea.Size = new System.Drawing.Size(122, 123);
            this.cardArea.TabIndex = 1;
            // 
            // KupaUI
            // 
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.cardArea);
            this.Name = "KupaUI";
            this.ResumeLayout(false);

        }
    }
}