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

        #region Variables, classes, mediaplayer
        bool spaceDown;
        Dinosaur dinoMan;
        Obstacle obstacles;
        List<PictureBox> obstacleList = new List<PictureBox>();
        int difficulty = MenuScreen.difficulty;
        public static double finalScore;
        MediaPlayer sound = new MediaPlayer(); 
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            GameInitialize();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
           
            dinoMan.JumpPhysics(spaceDown, sound);
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
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = false;
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
               
            }
        }
        /// <summary>
        /// Initializes the game with necessary values
        /// </summary>
        private void GameInitialize()
        {
            Random position = new Random();

            for (int i = 0; i < 6; i++)
            {
                PictureBox obstacleExample = new PictureBox();
                obstacleExample.Size = new Size(100, 100);
                obstacleExample.SizeMode = PictureBoxSizeMode.AutoSize;
                obstacleExample.Image = new Bitmap(Properties.Resources.obstacle_1);
                obstacleExample.Location = new Point((obstacleExample.Width + position.Next(300, 600)), 355);
                obstacleExample.Left = obstacleExample.Left * position.Next(10, 18);
                this.Controls.Add(obstacleExample);
                obstacleList.Add(obstacleExample);
                obstacleExample.Show();
            }
            sound.Open(new Uri(Application.StartupPath + "/Resources/jump.mp3"));

            mainCharacter.Top = 355;

            Cursor.Hide();

            dinoMan = new Dinosaur(mainCharacter);
            obstacles = new Obstacle(obstacleList, difficulty);


        }
    }
}
