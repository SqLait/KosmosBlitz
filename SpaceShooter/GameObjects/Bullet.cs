namespace SpaceShooter
{
  internal class Bullet : GameObject, IRectangle
  {
    private Texture2D bulletTexture;
    private GameManager gameManager;

    public Rectangle bulletRect;
    public Vector2 bulletPos;
    public bool isActive = false;

    public Bullet(
        Texture2D pBulletTexture,
        Vector2 pBulletPos,
        GraphicsDeviceManager pGraphics,
        GameManager pGameManager
        ): base(pBulletTexture, pBulletPos, pGraphics)
    {
      bulletTexture = pBulletTexture;
      bulletPos = pBulletPos;
      graphics = pGraphics;
      gameManager = pGameManager;

      bulletRect = new Rectangle(
          (int)(pBulletPos.X - bulletTexture.Width / 2),
          (int)(pBulletPos.Y - bulletTexture.Height / 2),
          bulletTexture.Width,
          bulletTexture.Height
          );
    }

    public override void Update(GameTime pGameTime)
    {
      gameManager.bulletManager.HandleCollisions();
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
      gameManager.bulletManager.ListLoop(pSpriteBatch);
    }

    public void DrawBullet(SpriteBatch pSpriteBatch)
    {
      if (isActive)
      {
        pSpriteBatch.Draw(
            bulletTexture,
            bulletPos,
            null,
            Color.White,
            0f,
            new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
            );
      }
    }

    public void MoveBullets(GameTime pGameTime)
    {
      if (isActive)
      {
        const float bulletSpeed = 650;
        bulletPos.Y -= bulletSpeed * (float)pGameTime.ElapsedGameTime.TotalSeconds; //how fast it wil move.
      }
    }

    public void UpdateRectangle()
    {
      bulletRect.X = (int)(bulletPos.X - bulletTexture.Width / 2);
      bulletRect.Y = (int)(bulletPos.Y - bulletTexture.Height / 2);
    }
  }
}
