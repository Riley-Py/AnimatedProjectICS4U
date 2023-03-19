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
    public partial class GameScreen : UserControl
    {
        bool wDown;
        Dinosaur dinoMan;
        Obstacle obstacles;
        List<PictureBox> obstacleList = new List<PictureBox>();
        int difficulty = MenuScreen.difficulty;
        public static double finalScore;

        public GameScreen()
        {
            InitializeComponent();
            GameInitiaize();
           


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            dinoMan.JumpPhysics(wDown);
            obstacles.MoveObstacle(this.Width);

            scoreLabel.Text = $"Score: {Math.Round(obstacles.scoring)}";

            if (obstacles.CheckIntersection(dinoMan))
            {
                finalScore = Math.Round(obstacles.scoring);
                gameTimer.Stop();
                
                Form1.ChangeScreen(this, new GameOver());         
            }
           
                                                     

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Space:
                    wDown = false;
                    break;

            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    wDown = true;
                    break;
            }
        }
        private void GameInitiaize()
        {
            
            
            obstacleList.Add(obstacle2);
            obstacleList.Add(obstacle1);

            mainCharacter.Top = 354;


            dinoMan = new Dinosaur(mainCharacter);
            obstacles = new Obstacle(obstacleList, difficulty);


        }
    }
}
