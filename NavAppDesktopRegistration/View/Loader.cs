using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavAppDesktopRegistration
{
    public partial class Loader : Form
    {
        Random rnd = new Random();
        Login l = new Login();
        public Loader()
        {
            InitializeComponent();
            Timer _timer = new Timer(); // Set up the timer for 3 seconds
            _timer.Interval = 150;
            _timer.Tick += LoaderProgressBarAnimation;
            _timer.Enabled = true;
        }

        void LoaderProgressBarAnimation(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
            if (progressBar1.Value < 100)
            {
                try
                {
                    progressBar1.Value += rnd.Next(1, 8);
                }
                catch (Exception ex)
                {
                    progressBar1.Value = 100;
                }
            }
            else
            {
                Program.LoaderClose = true;
                this.Close();
            }
        }
      
    }
}
