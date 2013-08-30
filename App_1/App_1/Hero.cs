using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_1
{
    public class Hero: Sprite
    {
        private Surface mVideo;
        private Circle mCir;
        private int x, y, rad;
        public Rectangle colRect;
        private int velocityX=5, velocityY=5;
        int tijd = 0;
        private StateObject stateObj = StateObject.Instance;

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
        public Hero(Surface vid)
        {
            mVideo = vid;
            x = 380;
            y=320;
            rad = 20;
            mCir = new Circle((short)x, (short)y, (short)rad);
            colRect = new Rectangle(x, y+rad , 20, 1);
        }

        public int jump(int tijd, int lastYpos, bool highjump)
        {
            double value = (highjump == true) ? 4.4 : 1.9;
            int result = -(int)((value * Math.Sin(0.8) * tijd) - (0.5 * 0.1 * (tijd * tijd)) + lastYpos);
            
            return result;
        }


        public void Draw()
        {
            if (down)
            {
                if (key == SdlDotNet.Input.Key.LeftArrow)
                    xVal = xVal - velocityX;

                if (key == SdlDotNet.Input.Key.RightArrow)
                    xVal = xVal + velocityY;

                if (key == SdlDotNet.Input.Key.UpArrow && stateObj.onLadder == true)
                    yVal-=5;

                if (key == SdlDotNet.Input.Key.DownArrow && stateObj.onLadder == true)
                    yVal++;



            }

            if (stateObj.jump == true)
            {
                int tempY = jump(tijd, yVal, true);
                tijd++;
                Console.WriteLine(tempY);
                
                yVal = tempY;

                if (tempY >= stateObj.yPosBeforeJump)
                {
                    stateObj.jump = false;
                    tijd = 0;
                    yVal = stateObj.yPosBeforeJump;
                }                  
 
            }

            mCir.PositionX = (short)x;
            mCir.PositionY = (short)y;
            
            mCir.Draw(mVideo, Color.Yellow);
        }


        SdlDotNet.Input.Key key;
        bool down = false;
        public override void Update(SdlDotNet.Input.KeyboardEventArgs args)
        {
            //base.Update(args);

            if (args.Down)
            {
                down = true;

                if (args.Key == SdlDotNet.Input.Key.LeftArrow)
                    key = SdlDotNet.Input.Key.LeftArrow;

                if (args.Key == SdlDotNet.Input.Key.RightArrow)
                    key = SdlDotNet.Input.Key.RightArrow;

                if (args.Key == SdlDotNet.Input.Key.UpArrow)
                    key = SdlDotNet.Input.Key.UpArrow;

                if (args.Key == SdlDotNet.Input.Key.DownArrow)
                    key = SdlDotNet.Input.Key.DownArrow;

                if (args.Key == SdlDotNet.Input.Key.Space)
                {
                    stateObj.jump = true;
                    stateObj.yPosBeforeJump = yVal;
                    key = SdlDotNet.Input.Key.Space;
                    tijd = 0;
                }
            }
            else
                down = false;
        }

       


    }
}
