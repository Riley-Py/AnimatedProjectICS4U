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
    public partial class GameOver : UserControl
    {
        public GameOver()
        {
            InitializeComponent();
            //Shows final score
            scoreLabel.Text = $"Score: {GameScreen.finalScore}";
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //Goes back to menu screen
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Exits the application
            Application.Exit();
        }
    }
}
