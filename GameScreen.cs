using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace AnimatedProjectICS4U
{
    public partial class GameScreen : UserControl
    {
        //Necessary variables for the game
        bool spaceDown;
        bool escapeDown;
        Dinosaur dinoMan;
        Obstacle obstacles;
        List<PictureBox> obstacleList = new List<PictureBox>();
        int difficulty = MenuScreen.difficulty;
        public static double finalScore;
        MediaPlayer sound = new MediaPlayer();

        public GameScreen()
        {
            InitializeComponent();
            GameInitialize();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            dinoMan.JumpPhysics(spaceDown);
            obstacles.MoveObstacle(this.Width);

            scoreLabel.Text = $"Score: {Math.Round(obstacles.scoring)}";

            if (obstacles.CheckIntersection(dinoMan))
            {
                finalScore = Math.Round(obstacles.scoring);
                gameTimer.Stop();

                Form1.ChangeScreen(this, new GameOver());
            }
            if (spaceDown)
            {
                sound.Stop();
                sound.Play();
            }




        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.Escape:
                    escapeDown = false;
                    break;


            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.Escape:
                    escapeDown = true;
                    break;
            }
        }
        /// <summary>
        /// Initializes the game 
        /// </summary>
        private void GameInitialize()
        {


            obstacleList.Add(obstacle2);
            obstacleList.Add(obstacle1);
            sound.Open(new Uri(Application.StartupPath + "/Resources/jump.mp3"));

            mainCharacter.Top = 355;

            Cursor.Hide();


            dinoMan = new Dinosaur(mainCharacter);
            obstacles = new Obstacle(obstacleList, difficulty);


        }
    }
}
