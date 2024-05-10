namespace SpaceShooter
{
  internal class ResetGameStats
  {
    private GameManager gm;

    public bool shouldRemove;
    
    public ResetGameStats(GameManager pGameManager) => this.gm = pGameManager;

    /// <summary>
    /// Reset all the game stats so that there are no conflicts on new game start.
    /// </summary>
    public void GameResetter()
    {
      gm.GameObjList.Clear();
      gm.angreehManager.AngreehLs.Clear();
      gm.bulletManager.BulletLs.Clear();

      gm.shipPos = new Vector2(
          gm.graphics.PreferredBackBufferWidth / 2,
          gm.graphics.PreferredBackBufferHeight - 200
          );
      gm.angreehFactory.enemyPos = new Vector2(
          gm.graphics.PreferredBackBufferWidth / 2,
          gm.graphics.PreferredBackBufferHeight - 1000
          );
      gm.bulletFactory.bulletPos = gm.shipPos;

      Angreeh angreeh = new Angreeh(gm.shipTexture, gm.angreehFactory.enemyPos, gm.graphics, gm);
      Bullet bullet = new Bullet(gm.bulletTexture, gm.bulletFactory.bulletPos, gm.graphics, gm);
      SpaceShip spaceShip = new SpaceShip(gm.shipTexture, gm.shipPos, gm.graphics, gm);

      gm.GameObjList.Add(bullet);
      gm.GameObjList.Add(spaceShip);
      gm.GameObjList.Add(angreeh);

      gm.scoreManager.ResetScore();
      
      shouldRemove = false;
      gm.angreehManager.destroyedAngreeh = false;
      gm.gameStateManager.gameStarted = false;
      gm.PlayerAlive = true;
      gm.gameStateManager.shouldGameReset = false;
      gm.drawText.drawInitialText = true;

      if (gm.GameResult == GameResult.Win)
      {
        gm.gameStateManager.waveCount += 1;
        gm.gameStateManager.waveHighScore = gm.gameStateManager.waveCount;
        gm.angreehFactory.angreehSpawnDelay -= 0.1f;
      }

      else if (gm.GameResult == GameResult.Lose)
      {
        float oldDelay = 0.7f;
        gm.gameStateManager.waveCount = 1;
        gm.angreehFactory.angreehSpawnDelay = oldDelay;
      }
    }

    public void Destroy(GameObject pObj)
    {
      if (shouldRemove)
      {
        gm.GameObjList.Remove(pObj);
      }
    }
  }
}
