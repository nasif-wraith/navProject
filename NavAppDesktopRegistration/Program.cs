using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavAppDesktopRegistration
{
    static class Program
    {
        public static bool LoaderClose { get; set; }
        public static bool RegiClose { get; set; }
        public static UserModel CurrentUser { get; set; }
        public static RegistrationFormMain Regiform { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoaderClose = false;
            RegiClose = false;
            Application.Run(new Loader());
            if (LoaderClose)
            {
                Application.Run(new Login());
            }
            //Application.Run(new Loader());
        }
    }
}
