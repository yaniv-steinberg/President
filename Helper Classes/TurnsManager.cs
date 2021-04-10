using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace President
{
    public static class TurnsManager
    {
        private static int turn;
        //defines the first player
        public static void SetFirstTurn(int first) 
        {
            turn = first;
        }

        //returns the current turn
        public static int GetCurrentTurn() 
        {
            return turn;
        }
        
        //advance one turn to the next player
        public static void AdvanceTurn() 
        {
            turn = (turn % 3) + 1;
        }

        //goes to the previous turn
        public static void BackTurn()
        {
            AdvanceTurn();
            AdvanceTurn();
        }
    }
}
