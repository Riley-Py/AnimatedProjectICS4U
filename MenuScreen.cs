using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatedProjectICS4U
{
    public partial class MenuScreen : UserControl
    {
       public static int difficulty;
        public MenuScreen()
        {
            InitializeComponent();

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //Speed of projectiles (bushes)
            difficulty = 10;

            Form1.ChangeScreen(this, new GameScreen());

            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
