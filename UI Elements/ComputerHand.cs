using System.Drawing;
using System.Windows.Forms;

namespace President
{
    public class ComputerHand : UserControl
    {
        private FlowLayoutPanel cardArea;


        public ComputerHand() //פעולת בנייה ליד המחשב
        {
            InitializeComponent();
        }

        public void ClearCards() //פעולה שמנקה את הקלפים ביד
        {
            cardArea.Controls.Clear();
        }

        public void RemoveCard(Card card) //פעולה שמוחקת את הקלף שהתקבל מהיד
        {
            cardArea.Controls.Remove(card);
        }

        public Panel CardArea
        {
            get { return cardArea; }
        }


        public void AddCard(Card card, int x) //הפעולה מוסיפה קלף ליד המחשב
        {
            cardArea.Controls.Add(card);
            card.Location = new Point(10, x);
            Refresh();
        }

       

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cardArea = new System.Windows.Forms.FlowLayoutPanel();
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
            this.cardArea.TabIndex = 0;
            // 
            // ComputerHand
            // 
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.cardArea);
            this.Name = "ComputerHand";
            this.ResumeLayout(false);

        }
    }
}