using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Texture2D background;
    private Texture2D shuttle;
    private Texture2D earth;

    private SpriteFont font;
    private int score = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        background = Content.Load<Texture2D>("stars");
        shuttle = Content.Load<Texture2D>("shuttle");
        earth = Content.Load<Texture2D>("earth");

        font = Content.Load<SpriteFont>("Score");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        score++;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        _spriteBatch.Begin();
        _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.CornflowerBlue);
        _spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
        _spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);
        _spriteBatch.DrawString(font, "Score: " + score, new Vector2(300, 50), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
