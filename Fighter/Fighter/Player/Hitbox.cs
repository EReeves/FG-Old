using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Fighter
{
    class Hitbox
    {
        public IntRect Rectangle;
        private IntRect localRectangle;
        public Player ParentPlayer;
        Vector2f[] localFramePositions;

        public Hitbox(IntRect _localRectangle, Player _parentPlayer, int frameCount)
        {
            localFramePositions = new Vector2f[frameCount];
            localRectangle = _localRectangle;
            ParentPlayer = _parentPlayer;
            SyncRectangleWithPlayer();
        }

        private void Update()
        {
            SyncRectangleWithPlayer();
        }

        private void Draw()
        {
            
        }

        public void SetLocalPositionAtFrame(int frame)
        {
            localRectangle = new IntRect((int)localFramePositions[frame - 1].X, (int)localFramePositions[frame - 1].Y, localRectangle.Width, localRectangle.Height);
        }

        private void SyncRectangleWithPlayer()
        {
            Rectangle.Left = localRectangle.Left + (int)ParentPlayer.Position.X;
            Rectangle.Top = localRectangle.Top + (int)ParentPlayer.Position.Y;
        }

    }
}
