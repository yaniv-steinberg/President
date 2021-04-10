using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using President.Logics;

namespace President
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Logic();
        }
    }
}
