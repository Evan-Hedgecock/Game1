using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TextureAtlas;

namespace game1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
	private SpriteBatch animatedSpriteBatch;
    
    private Texture2D background;
    private Texture2D shuttle;
    private Texture2D earth;

	private float earthAngle;

    private int[] shuttlePos;

	private int playerSpeed = 30;
	private int[] playerPos;

    private SpriteFont font;
    private int score = 0;

	private AnimatedSprite animatedSprite;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        shuttlePos = [400, 400];
		playerPos = [400, 250];

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

		animatedSpriteBatch = new SpriteBatch(GraphicsDevice);

        background = Content.Load<Texture2D>("stars");
        shuttle = Content.Load<Texture2D>("shuttle");
        earth = Content.Load<Texture2D>("earth");

		Texture2D texture = Content.Load<Texture2D>("SmileyWalk");
		animatedSprite = new AnimatedSprite(texture, 4, 4);

        font = Content.Load<SpriteFont>("Score");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

		if (Keyboard.GetState().IsKeyDown(Keys.W))
			playerPos[1] -= playerSpeed;
		if (Keyboard.GetState().IsKeyDown(Keys.S))
			playerPos[1] += playerSpeed;
		if (Keyboard.GetState().IsKeyDown(Keys.A))
			playerPos[0] -= playerSpeed;
		if (Keyboard.GetState().IsKeyDown(Keys.D))
			playerPos[0] += playerSpeed;

        score++;
        shuttlePos[1] -= 1;

		earthAngle += 0.01f;

		animatedSprite.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

		Rectangle earthSourceRectangle = new Rectangle(0, 0, earth.Width, earth.Height);
		Vector2 earthOrigin = new Vector2(earth.Width / 2,  earth.Height / 2);

       _spriteBatch.Begin();
       _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.CornflowerBlue);
       _spriteBatch.Draw(earth, new Vector2(400, 240), earthSourceRectangle, Color.White, earthAngle, earthOrigin, 1.0f, SpriteEffects.None, 1);
       _spriteBatch.Draw(shuttle, new Vector2(shuttlePos[0], shuttlePos[1]), Color.White);
       _spriteBatch.DrawString(font, "Score: " + score, new Vector2(300, 50), Color.White);

       _spriteBatch.End();

		animatedSprite.Draw(_spriteBatch, new Vector2(playerPos[0], playerPos[1]));

        base.Draw(gameTime);
    }
}
