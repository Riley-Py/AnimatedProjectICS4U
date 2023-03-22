using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media;


namespace AnimatedProjectICS4U
{
    internal class Dinosaur
    {
        int jumpHeight;
        double force = 12;
        public PictureBox dino;
       

       
        
        


        public Dinosaur(PictureBox _dino)
        {
            
            dino = _dino;
            
            
        }
        public void JumpPhysics(bool spaceDown, MediaPlayer player)
        {
            

            dino.Top += jumpHeight;
            if (spaceDown && force > 0)
            {
                jumpHeight = -10;
                force -= 1.15;
            } 
            else
            {
                jumpHeight = 10;
                spaceDown = false;
            }
            if (dino.Top > 354 && spaceDown == false)
            {
                force = 12;
                dino.Top = 355;
                jumpHeight = 0;

            }
            if (spaceDown && dino.Top > 354)
            {
                player.Stop();
                player.Play();

            }



        }
      
    }
}
