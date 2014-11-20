using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Fighter
{
    class Player : Sprite
    {
    	public PlayerState State = PlayerState.Idle;
        public AnimationContainer AnimationContainer = new AnimationContainer();
        public bool PlayerFlipped = false;
        
        public enum PlayerState{
    		Idle,
    		Jump,
    		MoveRight,
    		MoveLeft,
    		Startup,
    		Attack,
    		Recovery	
    	}

        public Player()
        {
            Program.OnUpdate += Update;
            Program.OnDraw += Draw;
        }

        private void Draw()
        {
            Draw(Program.Window, RenderStates.Default);
        }

        private void Update()
        {
            AnimationUpdate();
        }

        public void Start()
        {
            PlayAnimation(AnimationContainer.AnimationType.Idle);
            State = PlayerState.Idle;
        }

        //Animation


        public void PlayAnimation(AnimationContainer.AnimationType animt)
        {
            Animation anim = AnimationContainer.Animations[animt];

            if (anim.BlockedTransferStates != null)
                foreach (PlayerState st in anim.BlockedTransferStates)
                {
                    if (st == State)
                        return;
                }

            AnimationContainer.CurrentAnimation = anim;
            Texture = anim.SpriteSheet;
            anim.Reset();
            tick = 0;
        }
        
        public void PlayAnimationIfUnique(AnimationContainer.AnimationType animt)
        {
            if (AnimationContainer.CurrentAnimation == AnimationContainer.Animations[animt])
        		return;
        	else
        		PlayAnimation(animt);
        }

        private int tick = 0;
        private void AnimationUpdate()
        {           
            Animation anim = AnimationContainer.CurrentAnimation;

            if(anim.ManualFrameSize != null)
            {
                int framestartleft = 0;
                for (int i = 0; i < anim.CurrentFrame;i++ )
                {
                    framestartleft += anim.ManualFrameSize[i].X;
                }

                TextureRect = new IntRect(anim.FrameStart.X + framestartleft,
                    anim.FrameStart.Y, anim.ManualFrameSize[anim.CurrentFrame].X, anim.ManualFrameSize[anim.CurrentFrame].Y);
            }
            else
                TextureRect = new IntRect(anim.FrameStart.X + (anim.FrameSize.X * anim.CurrentFrame),anim.FrameStart.Y, anim.FrameSize.X, anim.FrameSize.Y);
            
            anim.UpdateHitBoxes();

            if(anim.ManualIntervals != null)
            {
                //If it fails here then there aren't the right amount of Manual Intervals.
                if(tick > anim.ManualIntervals[anim.CurrentFrame])
                {
                    anim.CurrentFrame++;
                    tick = 0;
                    anim.FrameChangeUpdate();
                }
            }
            else if(tick > anim.Interval)
            {
                anim.CurrentFrame++;
                tick = 0;
                anim.FrameChangeUpdate();
            }
            tick++;

            if (anim.CurrentFrame > anim.FrameCount)
            {
                anim.Reset();
                if (AnimationContainer.Animations.ContainsKey(AnimationContainer.AnimationType.Idle))
                    PlayAnimation(AnimationContainer.AnimationType.Idle);
                return;
            }
        }
        
        //Movement Test
        public enum Direction{Up,Right,Left}
        
        public void MoveInDirection(Direction direction)
        {
        	switch(direction)
        	{
        		case Direction.Up:
        			//Jump
        			break;
        			
        		case Direction.Right:
        			Position += Vec2.Right * 5;
        			PlayAnimationIfUnique(AnimationContainer.AnimationType.MoveRight);
        			break;
        			
        		case Direction.Left:
        			Position += Vec2.Left * 5;
        			PlayAnimationIfUnique(AnimationContainer.AnimationType.MoveLeft);
        			break;       	
        	}
        
        }
    }


}
