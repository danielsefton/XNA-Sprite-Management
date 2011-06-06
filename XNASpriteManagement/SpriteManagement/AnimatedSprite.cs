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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace XNASpriteManagement
{
	public class AnimatedSprite : Sprite
	{
		#region Fields

		protected int frameCount;
		protected int frame = 0;
		protected int frameWidth = 0;

		private float timePerFrame;
		private bool paused = false;
		private float timeElapsed;

		#endregion


		#region Properties

		public int FrameWidth
		{
			get { return frameWidth; }
		}
		public bool IsPaused
		{
			get { return paused; }
		}
		public override Rectangle Rect
		{
			get
			{
				if (rectangle == Rectangle.Empty)
					return new Rectangle(0, 0, FrameWidth, Texture.Height);

				return rectangle;
			}
			set { rectangle = value; }
		}

		#endregion


		#region Initialisation

		public AnimatedSprite(String name, Texture2D texture, int frameCount, int framesPerSec)
			: base(name, texture)
		{
			this.frameCount = frameCount;
			this.timePerFrame = 1f / framesPerSec;
		}

		public AnimatedSprite(String name, Texture2D texture, Vector2 position,
			Color colour, Vector2 origin, float rotation, Vector2 scale, float depth,
			int frameCount, int framesPerSec)
			: base(name, texture, position, colour, origin, rotation, scale, depth)
		{
			this.frameCount = frameCount;
			this.timePerFrame = 1f / framesPerSec;
		}

		public override void Initialize() { }

		#endregion


		#region Update and Draw

		public override void Update(GameTime gameTime)
		{
			if (!paused)
			{
				timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

				if (timeElapsed > timePerFrame)
				{
					frame++;
					frame = frame % frameCount;
					timeElapsed -= timePerFrame;
				}
			}

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			if (Visible)
			{
				frameWidth = Texture.Width / frameCount;
				Rectangle sourceRect = new Rectangle(frameWidth * frame, 0,
					frameWidth, Texture.Height);
				spriteBatch.Draw(Texture, Position, sourceRect, Colour,
					Rotation, Origin, Scale, SpriteEffects, Depth);
			}
		}

		#endregion


		#region Animation Control

		/// <summary>
		/// Resets the animation.
		/// </summary>
		public void Reset()
		{
			frame = 0;
			timeElapsed = 0f;
		}

		/// <summary>
		/// Stops the animation.
		/// </summary>
		public void Stop()
		{
			Pause();
			Reset();
		}

		/// <summary>
		/// Plays the animation.
		/// </summary>
		public void Play()
		{
			paused = false;
		}

		/// <summary>
		/// Pauses the animation.
		/// </summary>
		public void Pause()
		{
			paused = true;
		}

		#endregion
	}
}