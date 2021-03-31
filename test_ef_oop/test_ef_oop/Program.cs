using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_ef_oop.Database;
using test_ef_oop.Forms;

namespace test_ef_oop
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
            if (DBConecction.OpenConnection())
            {
                Application.Run(new frmCustomer());
            }
            else {
                Application.Exit();
            }
        }
    }
}
