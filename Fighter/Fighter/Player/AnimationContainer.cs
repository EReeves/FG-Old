using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter
{
    class AnimationContainer
    {
        //Animation
        public Animation CurrentAnimation;
        public Dictionary<AnimationType, Animation> Animations = new Dictionary<AnimationType, Animation>();

        public enum AnimationType
        {
            Idle, MoveRight, MoveLeft, Taunt, JumpUp, JumpDown, CrouchDown, CrouchIdle, CrouchUp,
            GrappleInit, GrappleLand, jLP, jMP, jHP, jLK, jMK, jHK, sLP, sMP, sHP, sLK, sMK, sHK,
            cLP, cMP, cHP, cLK, cMK, cHK
        }
    }
}
