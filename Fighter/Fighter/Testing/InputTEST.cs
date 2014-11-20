//Evan Reeves 17/01/2014 6:48 PM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Fighter
{
	public class InputTEST
	{
		public InputTEST()
		{
			Program.Window.JoystickButtonPressed += new EventHandler<JoystickButtonEventArgs>(Program_Window_JoystickButtonPressed);
			Program.Window.JoystickMoved += new EventHandler<JoystickMoveEventArgs>(Program_Window_JoystickMoved);
			Program.Window.KeyPressed += new EventHandler<KeyEventArgs>(Program_Window_KeyPressed);
			
			Program.OnUpdate += KeyboardInput;
		}
		
		public void KeyboardInput()
		{

		}

		void Program_Window_KeyPressed(object sender, KeyEventArgs e)
		{
			
		}

		void Program_Window_JoystickMoved(object sender, JoystickMoveEventArgs e)
		{
			//Todo map to everything.
			Player.Direction dir = Player.Direction.Right;
			if(e.Axis == Joystick.Axis.X && e.Position == 1)
				dir = Player.Direction.Right;
			
			if(e.JoystickId == 0)
			{
	
			}
				
		}

		void Program_Window_JoystickButtonPressed(object sender, JoystickButtonEventArgs e)
		{
			//if(e.JoystickId == 0)
				 
		}
	}
}
