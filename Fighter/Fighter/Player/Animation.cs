using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Fighter
{
    class Animation
    {
        public bool Interruptable = false;
        public Texture SpriteSheet;
        public Vector2i FrameStart;
        public Vector2i FrameSize;
        public int[] ManualFrameStartY = null;
        public int[] ManualFrameStartX = null;
        public Vector2i[] ManualFrameSize = null;
        public int FrameCount;
        public int Interval = 1;
        public int[] ManualIntervals = null;
        public int CurrentFrame = 1;
        public Player ParentPlayer;
        public List<Hitbox> Hitboxes = new List<Hitbox>();
        public Player.PlayerState[] BlockedTransferStates;

        public Animation(Texture spriteSheet, Vector2i frameStartPos, Vector2i frameSize, int frameCount, Player parentPlayer)
        {
            FrameCount = frameCount;
            SpriteSheet = spriteSheet;
            FrameSize = frameSize;
            ParentPlayer = parentPlayer;
            FrameStart = frameStartPos;
        }

        public void FrameChangeUpdate()
        {
            if (CurrentFrame < FrameCount)
            {
                if (ManualFrameStartY != null)
                    FrameStart.Y = ManualFrameStartY[CurrentFrame];

                if (ManualFrameStartX != null)
                    FrameStart.Y = ManualFrameStartY[CurrentFrame];
            }
        }

        public void UpdateHitBoxes()
        {
            foreach (Hitbox hb in Hitboxes)
            {
                hb.SetLocalPositionAtFrame(CurrentFrame);
            }
        }

        public void Reset()
        {
            CurrentFrame = 0;
        }

    }
}
