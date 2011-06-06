#region File Description
/*
-------------------------------------------------------------------------------
Copyright (c) 2011 Daniel Sefton

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
//-----------------------------------------------------------------------------*/
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace XNASpriteManagement
{
	class PlayerSprite : AnimatedSprite
	{
		private int speed = 3; // Player speed

		public PlayerSprite(String name, Texture2D texture, int frameCount, int framesPerSec)
			: base(name, texture, frameCount, framesPerSec)
		{
		}

		public sealed override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			// Set the bounds to the window width/height.
			Vector2 bounds = new Vector2(
				((Game1)SpriteManager.Game).Graphics.PreferredBackBufferWidth,
				((Game1)SpriteManager.Game).Graphics.PreferredBackBufferHeight);

			// Move the player with WASD.
			KeyboardState key1 = Keyboard.GetState();
			if (key1.IsKeyDown(Keys.D))
			{
				// Note: We must use Rect.Width here rather than Texture.Width, 
				// otherwise it will use the whole width of the sprite sheet.
				if (Position.X <= bounds.X - Rect.Width)
					Position.X += speed;
			}
			else if (key1.IsKeyDown(Keys.A))
			{
				if (Position.X >= 0)
					Position.X -= speed;
			}
			else if (key1.IsKeyDown(Keys.W))
			{
				if (Position.Y >= 0)
					Position.Y -= speed;
			}
			else if (key1.IsKeyDown(Keys.S))
			{
				if (Position.Y <= bounds.Y - Rect.Height)
					Position.Y += speed;
			}
		}
	}
}