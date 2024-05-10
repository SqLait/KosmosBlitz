namespace SpaceShooter
{
  internal class BulletFactory
  {
    private GameManager gm;

    public Vector2 bulletPos;

    public BulletFactory(GameManager pGameManager) => this.gm = pGameManager;

    /*Cleaner way of creating bullets*/
    public Bullet CreateBullet()
    {
      Bullet newBullet = new Bullet(
            gm.bulletTexture,
            gm.shipPos, // Use shipPos as the bullet position
            gm.graphics,
            gm
      );
      return newBullet;
    }
    
  }
}
