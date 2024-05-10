namespace SpaceShooter
{
  internal class SpaceShip : GameObject, IRectangle
  {
    private Rectangle shipRect;
    private Texture2D shipTexture;
    private GameManager gameManager;
    private Bullet newBullet;

    private KeyboardState kbState;
    private TimeSpan elapsedTime;
    private TimeSpan lastShotTime = TimeSpan.Zero; 

    public Vector2 shipPos;

    //Constructer for the spaceship. Also a base constructer from the gameobject class to create the objects succesfully
    public SpaceShip(
        Texture2D pShipTexture,
        Vector2 pShipPos,
        GraphicsDeviceManager pGraphics,
        GameManager pGameManager
        )
      : base(pShipTexture, pShipPos, pGraphics)
    { //creating everything needed for the ship including the rectangle for collision.
      shipTexture = pShipTexture;
      shipPos = pShipPos;
      graphics = pGraphics;
      gameManager = pGameManager;

      shipRect = new Rectangle(
          (int)(pShipPos.X - shipTexture.Width / 2),
          (int)(pShipPos.Y - shipTexture.Height / 2),
          shipTexture.Width,
          shipTexture.Height
          );
    }

    /// <summary>
    /// Update method for this object. All from the gameobject class.
    /// </summary>
    public override void Update(GameTime pGameTime) 
    {
      if (!gameManager.resetGameStats.shouldRemove)
      {
        UpdateShipMovement(pGameTime);
        UpdateRectangle();
        FireBullet(pGameTime);
        ShipCollisionCheck();
      }
    }

    /// <summary>
    /// Universal drawing method
    /// </summary>
    public override void Draw(SpriteBatch pSpriteBatch)
    {
      DrawShip(pSpriteBatch);
    }

    /// <summary>
    /// Update the movement based on input
    /// </summary>
    private void UpdateShipMovement(GameTime pGameTime)
    {
      kbState = Keyboard.GetState();
      const float shipSpeed = 750;

      if (kbState.IsKeyDown(Keys.A))
      {
        shipPos.X -= shipSpeed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
      }
      else if (kbState.IsKeyDown(Keys.D))
      {
        shipPos.X += shipSpeed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
      }
      gameManager.shipPos = shipPos;
    }

    /// <summary>
    /// create the ship texture and draw it
    /// </summary>
    private void DrawShip(SpriteBatch pSpriteBatch)
    {
      pSpriteBatch.Draw(
          shipTexture,
          shipPos,
          null,
          Color.White,
          0f,
          new Vector2(shipTexture.Width / 2, shipTexture.Height / 2),
          Vector2.One,
          SpriteEffects.FlipVertically,
          0f
          );
    }

    /// <summary>
    ///  Fire a bullet from the position of the ship.
    /// </summary>
    private void FireBullet(GameTime pGameTime)
    {
      const float fireDelay = 0.7f;

      kbState = Keyboard.GetState();
      elapsedTime = pGameTime.TotalGameTime - lastShotTime;

      if (kbState.IsKeyDown(Keys.Space) && elapsedTime.TotalSeconds >= fireDelay)
      {
        // Set the position of the bullet to the current ship position
        newBullet = gameManager.bulletFactory.CreateBullet();
        newBullet.isActive = true; // Set isActive to true for the new bullet
        gameManager.bulletManager.BulletLs.Add(newBullet);

        lastShotTime = pGameTime.TotalGameTime;
      }

      if (newBullet != null)
      {
        gameManager.bulletManager.Update(pGameTime);
      }
    }

    /// <summary>
    /// Every frame I update the rectangle so that the collision will always work.
    /// </summary>
    public void UpdateRectangle()
    {
      shipRect.X = (int)(shipPos.X - shipTexture.Width / 2);
      shipRect.Y = (int)(shipPos.Y - shipTexture.Height / 2);

      if (shipRect.Right > graphics.PreferredBackBufferWidth)
      {
        shipPos.X = graphics.PreferredBackBufferWidth - shipTexture.Width / 2;
      }
      else if (shipRect.Left < 0)
      {
        shipPos.X = shipTexture.Width / 2;
      }
    }

    /// <summary>
    /// For each angreeh that is created in the game i loop over its list to check for collision
    /// </summary>
    private void ShipCollisionCheck()
    {
      foreach (Angreeh angreeh in gameManager.angreehManager.AngreehLs)
      {
        if (shipRect.Intersects(angreeh.enemyRect))
        {
          gameManager.resetGameStats.shouldRemove = true;
          gameManager.PlayerAlive = false;
          break;
        }
      }
    }
  }
}
