using System.Drawing;
using System.Windows.Forms;

namespace President
{
    public class PlayerHand : UserControl
    {
        private Panel cardArea;
    
        public PlayerHand()
        {
            InitializeComponent();
        }


        public void AddCard(Card card, int x) //פעולה שמוסיפה קלף ליד השחקן
        {
            cardArea.Controls.Add(card);
            card.Location = new Point(x, 10);


        }

        public void RemoveCard(Card card) //פעולה שמוחקת את הקלף שהתקבל מהיד
        {
            cardArea.Controls.Remove(card);
        }

        public void ClearCards() //פעולה שמנקה את הקלפים ביד
        {
            cardArea.Controls.Clear();
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
            // PlayerHand
            // 
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.cardArea);
            this.Name = "PlayerHand";
            this.ResumeLayout(false);

        }
    }  
}