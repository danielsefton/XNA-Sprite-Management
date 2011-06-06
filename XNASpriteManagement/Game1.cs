using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNASpriteManagement
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		SpriteManager spriteManager;
		Texture2D spriteTexture, animatedSpriteTexture, playerTexture;

		public GraphicsDeviceManager Graphics
		{
			get { return graphics; }
		}

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			// Add the SpriteManager component.
			spriteManager = new SpriteManager(this);
			Components.Add(spriteManager);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// Load the textures.
			spriteTexture = Content.Load<Texture2D>("TestSprite");
			animatedSpriteTexture = Content.Load<Texture2D>("TestAnimatedSprite");
			playerTexture = Content.Load<Texture2D>("TestPlayerSprite");

			// Create a standard sprite, rotated in code.
			Sprite sprite = spriteManager.CreateSprite("TestSprite", spriteTexture);
			sprite.Origin = new Vector2(spriteTexture.Width / 2, spriteTexture.Height / 2);
			sprite.Position = new Vector2(sprite.Origin.X + 100, sprite.Origin.Y + 100);
			sprite.RotationVelocity = 0.01f;

			// Create an animated sprite with a 6 frame sprite sheet.
			Sprite animatedSprite = spriteManager.CreateSprite(
				new AnimatedSprite("TestAnimatedSprite", animatedSpriteTexture, 6, 6));
			animatedSprite.Position = new Vector2(300, 100);

			// Create a controllable sprite. Notice the inheritance; a nice use of
			// polymorphism & encapsulation here.
			Sprite playerSprite = spriteManager.CreateSprite(
				new PlayerSprite("TestPlayerSprite", playerTexture, 6, 6));
			playerSprite.Position = new Vector2(500, 100);
			// Tags are a method for linking together one or more sprites.
			// Usage: spriteManager.GetSpriteWithTag("player");
			playerSprite.Tag = "player";
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
