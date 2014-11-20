using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Fighter
{
    class Program
    {
        public static RenderWindow Window;
        public delegate void ClientDelegate();
        public static ClientDelegate OnUpdate, OnDraw;

        //Debug
        public static bool DebugHitBoxDraw = true;

        //TempDebug
        public static Player ply;

        static void Main(string[] args)
        {
            ContextSettings contextSettings = new ContextSettings()
            {
                DepthBits = 32,
                AntialiasingLevel = 8
            };
            Window = new RenderWindow(new VideoMode(700, 500), "NotAsGoodAsStreetFighterButBetterThanMarvelVSCapcom", Styles.Default, contextSettings);
            Window.SetActive();
            Window.SetFramerateLimit(30);
            Window.Closed += delegate(object sender, EventArgs e) { Window.Close(); };

            //Debug temp
            Window.MouseButtonPressed += (object sender, MouseButtonEventArgs e) => {
                if (e.Button == Mouse.Button.Left)
                    ply.PlayAnimationIfUnique(AnimationContainer.AnimationType.sLP);
            };

            DebugLoad();

            while (Window.IsOpen())
            {
                Window.Clear(new Color(100, 100, 100));
                Window.DispatchEvents();

                if (OnUpdate != null)
                    OnUpdate.Invoke();
                if (OnDraw != null)
                    OnDraw.Invoke();

                Window.Display();
            }
        }

        private static void DebugLoad()
        {


            ply = new Player();         
            ply.Position = new Vector2f(200, 200);
            ply.Texture = new Texture("Data/Sprites/Ryu.png");
            ply.Scale = new Vector2f(2, 2);
            ply.AnimationContainer.Animations[AnimationContainer.AnimationType.Idle] = new Animation(
                ply.Texture, new Vector2i(2,0), new Vector2i(50, 104), 3, ply);
            ply.AnimationContainer.Animations[AnimationContainer.AnimationType.Idle].Interval = 4;
            ply.AnimationContainer.CurrentAnimation = ply.AnimationContainer.Animations[AnimationContainer.AnimationType.Idle];

            ply.AnimationContainer.Animations[AnimationContainer.AnimationType.sLP] = new Animation(
                ply.Texture, new Vector2i(0, 115), new Vector2i(57, 104), 2, ply);
            ply.AnimationContainer.Animations[AnimationContainer.AnimationType.sLP].Interval = 1;
            ply.AnimationContainer.Animations[AnimationContainer.AnimationType.sLP].ManualFrameSize =
                new Vector2i[] { new Vector2i(50, 104), new Vector2i(64, 104), new Vector2i(53, 104) };
            ply.AnimationContainer.Animations[AnimationContainer.AnimationType.sLP].ManualFrameStartY =
                new int[] { 116,116,116 };

            ply.Start();

            InputTEST input = new InputTEST();
        }
    }
}
