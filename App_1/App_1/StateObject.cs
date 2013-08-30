using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_1
{
    public class StateObject
    {

         private static StateObject instance;

        private StateObject() {}

        public static StateObject Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new StateObject();
                }
             return instance;
      }
   }

        public bool jump = false;

        public bool onLadder = false;

        public bool onGround = false;

        public int yPosBeforeJump = 0;
    }
}
