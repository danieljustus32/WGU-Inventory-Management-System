using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968_PA_Task
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static Form1 mainScreen = new Form1();
        [STAThread]
        static void Main()
        {
            Part p = new Inhouse(1, "Whatever", 1.00M, 1, 1, 10, 123);
            Product z = new Product(1, "Product", 1.00M, 1, 1, 10);
            Inventory.addPart(p);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainScreen);
        }
    }
}
