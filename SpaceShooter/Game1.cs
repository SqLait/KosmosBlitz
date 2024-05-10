global using System;
global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
  public class Game1 : Game
  {
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Texture2D shipTexture;
    private Vector2 shipPos;
    private Texture2D bulletTexture;
    private Vector2 bulletPos = Vector2.Zero;
    private Vector2 enemyPos;

    private GameManager gameManager;
    private ScreenLogic screenLogic = new ScreenLogic();
    private SpaceShip spaceShip;
    private Bullet bullet;
    private Angreeh angreeh;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      screenLogic.EnableFullScreen(graphics, Content, IsMouseVisible);
    }

    /// <summary>
    /// Spawn the player and the enemy.
    /// </summary>
    protected override void Initialize()
    {
      // TODO: Add your initialization logic here
      shipPos = new Vector2(
          graphics.PreferredBackBufferWidth / 2,
          graphics.PreferredBackBufferHeight - 200
          );
      enemyPos = new Vector2(
          graphics.PreferredBackBufferWidth / 2,
          graphics.PreferredBackBufferHeight - 1000
          );
      base.Initialize();
    }

    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);

      shipTexture = Content.Load<Texture2D>("Shippy");
      bulletTexture = Content.Load<Texture2D>("Star");

      // TODO: use this.Content to load your game content here
      gameManager = new GameManager(shipTexture, bulletTexture, graphics);

      gameManager.drawText.textFont = Content.Load<SpriteFont>("text"); // sprite font to display text.

      angreeh = new Angreeh(shipTexture, enemyPos, graphics, gameManager);
      bullet = new Bullet(bulletTexture, bulletPos, graphics, gameManager); // giving the list of angreehs so I can check for collision per index
      spaceShip = new SpaceShip(shipTexture, shipPos, graphics, gameManager);

      gameManager.GameObjList.Add(bullet); // add all the objects to a list to update them at the same time.
      gameManager.GameObjList.Add(spaceShip);
      gameManager.GameObjList.Add(angreeh);
    }

    protected override void Update(GameTime pGameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      gameManager.initializeGame.GameRunner(pGameTime, spriteBatch, bullet, spaceShip); // Kind of messy but here is the function I call to update all game objects at once

      base.Update(pGameTime);
    }

    protected override void Draw(GameTime pGameTime)
    {
      GraphicsDevice.Clear(Color.DarkSlateGray); // background color.

      // TODO: Add your drawing code here
      spriteBatch.Begin(); // draw everything at once.
      gameManager.drawText.DrawTextOnScreen(spriteBatch);
      for (int i = 0; i < gameManager.GameObjList.Count; i++)
      {
        gameManager.GameObjList[i].Draw(spriteBatch); // Get the index and call the draw function from that list entry.
      }
      spriteBatch.End();

      base.Draw(pGameTime);
    }
  }
}
