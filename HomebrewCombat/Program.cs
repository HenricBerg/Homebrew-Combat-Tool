using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomebrewCombat
{
    static class Program
    {
        public static MainWindow mainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]



        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm = new MainWindow());

        }


    }
}

