namespace SpaceShooter
{
  internal class AngreehFactory
  {
    private GameManager gm;
    private TimeSpan elapsedTime;
    private TimeSpan lastShotTime = TimeSpan.Zero;
    private Angreeh angreeh;

    public Vector2 enemyPos;

    public float angreehSpawnDelay = 0.7f;

    public AngreehFactory(GameManager pGameManager) => this.gm = pGameManager;

    /*Returning the new build angreeh for cleaner management.*/
    public Angreeh CreateAngreeh()
    {
      Angreeh angreeh = new Angreeh(
          gm.shipTexture,
          enemyPos,
          gm.graphics,
          gm
      );
      return angreeh;
    }

    public void SpawnAngreeh(GameTime pGameTime)
    {
      elapsedTime = pGameTime.TotalGameTime - lastShotTime;

      if (elapsedTime.TotalSeconds >= angreehSpawnDelay)
      {
        angreeh = CreateAngreeh();
        gm.angreehManager.AngreehLs.Add(angreeh);
        angreeh.isActive = true;

        lastShotTime = pGameTime.TotalGameTime;
      }

      gm.angreehManager.Update(pGameTime);
    }
  }
}
