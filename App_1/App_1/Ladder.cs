using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_1
{
    public class Ladder:bgObject
    {

        private Surface mVideo;
      
        private int x, y, rad;
        //public Rectangle colRect;
        private Surface bground;
       

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
        public Ladder(Surface vid,int x,int y)
        {
            mVideo = vid;
            bground = new Surface("Ladder.gif");
            xVal = x-50;
            yVal = y-100;
            colRect = new Rectangle(x-50, y-100, 50, 100);
        }

        public override void Draw()
        {
            mVideo.Blit(bground, new Point(xVal, yVal));
        }

        //public void Draw()
        //{
        //    mVideo.Blit(bground, new Point(xVal, yVal));
        ////}
    }
}
