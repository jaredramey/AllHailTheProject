using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class User
    {
        private static int nextID = 1;

        public int ID
        {
            get
            {
                return mID;
            }

        }
        private int mID;
        

        public User()
        {
            mID = nextID++;
        }
    }
}
