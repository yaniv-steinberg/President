using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace President.UI_Elements
{
    public partial class GameBoard : Form
    {
        public GameBoard()
        {
            InitializeComponent();            
        }

  
        public ComputerHand RightHand
        {
            get { return this.rightComputerHand; }
        }

        public ComputerHand LeftHand
        {
            get { return leftComputerHand; }
        }

        public PlayerHand PlayerHand
        {
            get { return this.playerHand; }
        }

        public KupaUI KupaUI
        {
            get { return this.kupaUI; }
        }


        public void Message(string message)
        {
            MessageBox.Show(message);
        }

      

      

//        private void GameBoard_Load(object sender, EventArgs e) //TODO: remove
//        {
//            GameMenu splashScreen = new GameMenu(true);
//            splashScreen.ShowDialog();
//        }

//        private void menuItemExit_Click(object sender, EventArgs e)
//        {
//
//            Close();
//        }
//
//        private void menuItemAbout_Click(object sender, EventArgs e)
//        {
//            GameMenu splashScreen = new GameMenu(false);
//            splashScreen.ShowDialog();
//        }

    

       

        

    }
}
