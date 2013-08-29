using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_1
{
    public class Blok
    {
        private Surface mVideo;
        private Surface DrawableObject;
        private int x, y;
        public  Rectangle colRect;

        public Blok(Surface vid,int _x, int _y)
        {
            mVideo = vid;
            x = _x ;
            y = _y;
            DrawableObject = new Surface("blok.png");
           
            colRect = new Rectangle(x, y, 15,1);
        }

        public void Draw()
        {
            mVideo.Blit(DrawableObject, new Rectangle(x,y,15,15));
        }


    }
}
