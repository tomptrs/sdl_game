using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_1
{
    public class Enemy
    {

        private Surface mVideo;
        private Circle mCir;
        private int x, y, rad;
        public Rectangle colRect;
        private int velocityX=2, velocityY=1;

        public bool onGround = false;
        public bool start = false;
        public int yPosBeforeJump = 0;
       

        public int xVal { get { return x; } 
            set 
            {
                x = value;
                colRect.X = x;
            }
        }

        public int yVal
        {
            get { return y; }
            set
            {
                y = value;
                colRect.Y= y+rad;
            }
        }
        public Enemy(Surface vid)
        {
            mVideo = vid;
            x = 150;
            y=50;
            rad = 20;
            Random rand = new Random();

            if (rand.NextDouble() >= 0.5)
                velocityX = 2;
            else
                velocityX = -2;
            mCir = new Circle((short)x, (short)y, (short)rad);
            colRect = new Rectangle(x, y+rad , 20, 1);
        }

       


        public void Draw()
        {
            if(onGround)
                xVal += velocityX;

            if (xVal < 0 || xVal > 500)
                velocityX *= -1;
            yVal = (short)y;
            mCir.PositionX = (short)xVal;
            mCir.PositionY = (short)yVal;
           
            mCir.Draw(mVideo, Color.Red);
        }
       
    }
}
