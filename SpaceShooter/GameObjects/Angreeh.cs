namespace SpaceShooter
{
  internal class Angreeh : GameObject, IRectangle
  {
    private GameManager gameManager;
    private Random randomX = new Random();
    private Texture2D enemyTexture;

    public Vector2 enemyPos;
    public Rectangle enemyRect;
    public bool isActive = false;


    public Angreeh(
        Texture2D pEnemyTexture,
        Vector2 pEnemyPos,
        GraphicsDeviceManager pGraphics,
        GameManager pGameManager
        ): base(pEnemyTexture, Vector2.Zero, pGraphics)
    {
      enemyPos = pEnemyPos;
      enemyTexture = pEnemyTexture;
      graphics = pGraphics;
      gameManager = pGameManager;

      // Set initial position to a random position on the top of the screen
      enemyPos = new Vector2(randomX.Next(graphics.PreferredBackBufferWidth), 50);

      enemyRect = new Rectangle(
          (int)(enemyPos.X - enemyTexture.Width / 2),
          (int)(enemyPos.Y - enemyTexture.Height / 2),
          enemyTexture.Width,
          enemyTexture.Height
          );
    }

    //almost all the logic here is the exact same as the bullet class.
    public override void Draw(SpriteBatch pSpriteBatch) => gameManager.angreehManager.ListLoop(pSpriteBatch);

    public override void Update(GameTime pGameTime) => gameManager.angreehFactory.SpawnAngreeh(pGameTime);

    public void DrawEnemy(SpriteBatch pSpriteBatch)
    {
      pSpriteBatch.Draw(
          enemyTexture,
          enemyPos,
          null,
          Color.Red,
          0f,
          new Vector2(enemyTexture.Width / 2, enemyTexture.Height / 2),
          Vector2.One,
          SpriteEffects.None,
          0f
          );
    }
    

    public void MoveAngreeh(GameTime pGameTime)
    {
      float enemySpeed = 600;
      if (isActive)
      {
        enemyPos.Y += enemySpeed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
      }
    }

    public void UpdateRectangle()
    {
      enemyRect.X = (int)(enemyPos.X - enemyTexture.Width / 2);
      enemyRect.Y = (int)(enemyPos.Y - enemyTexture.Height / 2);
    }
  }
}
