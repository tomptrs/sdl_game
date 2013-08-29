using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Graphics.Sprites;

namespace App_1
{
    public class Manager
    {
        
        Surface mVideo;
       
        public byte[,] intTileArray = new byte[,]
        {
            {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1}
        };

        public Blok[,] spriteTileArray = new Blok[4,30];

        private Hero mHero;
        private Enemy mEnemy;
        private List<Enemy> enemies;
        SpriteCollection col;
        
        private StateObject stateObj = StateObject.Instance;

        
//14:      myTimer.Interval = 1000;
//15:      myTimer.Start();

        private int teller = 0;
        public Manager()
        {

            mVideo = Video.SetVideoMode(500, 500);
            mHero = new Hero(mVideo);
            
            //start with 10 enemies

            mEnemy = new Enemy(mVideo);
            enemies = new List<Enemy>();
            enemies.Add(mEnemy);
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));
            enemies.Add(new Enemy(mVideo));

            col = new SpriteCollection();
            col.Add(mHero);
            
            col.EnableKeyboardEvent();

            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 30; j++)
                {

                    if (intTileArray[i, j] == 1)
                    {
                        spriteTileArray[i, j] = new Blok(mVideo, j * 15, (100+i*100));
                    }
 
                }
            }

           
            stateObj.onGround = false;


            System.Timers.Timer myTime = new System.Timers.Timer();
            myTime.Elapsed += myTime_Elapsed;

            myTime.Interval = 5000;
            myTime.Start();
            Events.Tick += Events_Tick;
            Events.Run();
        }

        void myTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            enemies[teller].start = true;
            teller++;
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (spriteTileArray[i, j] != null)
                        spriteTileArray[i, j].Draw();
                }
            }

            mHero.Draw();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].start)
                    enemies[i].Draw();
            }

            CheckCollisions();


            if (stateObj.jump == false && stateObj.onGround == false)
                mHero.yVal++;

            if (mEnemy.onGround == false)
                mEnemy.yVal++;

            mVideo.Update();
            mVideo.Fill(Color.Black);

        }

       
        private void CheckCollisions()
        {

            stateObj.onGround = false;
            mEnemy.onGround = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (spriteTileArray[i, j] != null)
                    {
                        //bij raken
                        if (spriteTileArray[i, j].colRect.IntersectsWith(mHero.colRect))
                        {
                            stateObj.onGround = true;

                            if (stateObj.jump)
                            {
                                stateObj.jump = false;
                            }
                        }

                        for (int k = 0; k < enemies.Count; k++)
                        {
                            if (spriteTileArray[i, j].colRect.IntersectsWith(enemies[k].colRect))
                            {
                                enemies[k].onGround = true;

                            }

 
                        }
                        //bij raken grond met enemy
                                            }
                        


                }

               
            }
            
        }
    }
}
