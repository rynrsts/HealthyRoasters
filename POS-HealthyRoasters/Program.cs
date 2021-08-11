using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_HealthyRoasters
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());//Receipt("6 Items\nSubtotal: Php 160.00\nGrand Total Price: Php 160.00\nChange: Php 160.00\nVAT Amount: Php 160.00\nVAT Sale: Php 160.00"));
        }
    }
}
