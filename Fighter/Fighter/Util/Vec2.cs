using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Fighter
{
    public static class Vec2
    {
        public static Vector2f Up
        {
            get { return new Vector2f(0, -1); }
        }

        public static Vector2f Down
        {
            get { return new Vector2f(0, 1); }
        }

        public static Vector2f Left
        {
            get { return new Vector2f(-1, 0); }
        }

        public static Vector2f Right
        {
            get { return new Vector2f(1, 0); }
        }

        public static Vector2f Zero
        {
            get { return new Vector2f(0, 0); }
        }
    }
}
