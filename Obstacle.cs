using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimatedProjectICS4U
{
    internal class Obstacle
    {
        #region variables that obstacle needs
        List<PictureBox> obstacles;
        int obstacleSpeed;
        public double scoring;
        #endregion
        public Obstacle(List<PictureBox> _pictureBox, int _obstacleSpeed) {


            obstacleSpeed = _obstacleSpeed;
            obstacles = _pictureBox;

        }
        /// <summary>
        /// Moves the obstacles towards the dinosaur
        /// </summary>
        /// <param name="width"></param>
        public void MoveObstacle(int width)
        {
            Random randgen = new Random();
              
            foreach(PictureBox p in obstacles)
            {
                
                p.Left -= obstacleSpeed;
                if (p.Left < -100)
                {
                    p.Left = width + randgen.Next(300, 500) + p.Width * 12;
                    scoring++;
                    
                    if (scoring % 5 == 0 && scoring != 0)
                    {
                        // Increase obstacle speed & add a tiny ammount to scoring so that it doesn't constantly speed it up when there is no remainder (as platforms are spreaded out)
                        obstacleSpeed += 5;
                        scoring += 0.000001;
                    }
                  
                }
               
            }
            
            
        }
        /// <summary>
        /// Checks to see if any intersection happens between dinosaur and obstacle
        /// </summary>
        /// <param name="dino"></param>
        /// <returns></returns>
        public bool CheckIntersection(Dinosaur dino)
        {
            foreach (PictureBox p in obstacles)
            {
                if (dino.dino.Bounds.IntersectsWith(p.Bounds))
                {
                    return true;              

                }
               
            }
            return false;
        }
    }
}
