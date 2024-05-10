namespace SpaceShooter
{
  internal class InitializeGame
  {
    private GameManager gm;
    public InitializeGame(GameManager pGameManager) => this.gm = pGameManager;
    
    public void StartGame() //start game succesfully
    {
      KeyboardState _kbState = Keyboard.GetState();

      if (_kbState.IsKeyDown(Keys.Enter))
      {
        gm.gameStateManager.gameStarted = true;
        gm.drawText.drawInitialText = false;
        gm.GameResult = GameResult.None;
        gm.gameStateManager.waveHighScore = gm.gameStateManager.waveCount;
      }
    }

    /// <summary>
    /// This is what the game does every frame
    /// </summary>
    public void GameRunner(GameTime pGameTime, SpriteBatch pSpriteBatch, Bullet pBullet, SpaceShip pSpaceShip)
    {
      StartGame();
      if (gm.gameStateManager.gameStarted)
      {
        pBullet.bulletPos = pSpaceShip.shipPos;
        gm.bulletFactory.bulletPos = pSpaceShip.shipPos;
        for (int i = 0; i < gm.GameObjList.Count; i++)
        {
          gm.GameObjList[i].Update(pGameTime);
        }
        gm.resetGameStats.Destroy(pSpaceShip);
        gm.scoreManager.UpdateScore();
      }

      pSpriteBatch.Begin();

      gm.gameStateManager.ConditionChecker();

      pSpriteBatch.End();

      if (gm.gameStateManager.shouldGameReset || !gm.PlayerAlive)
      {
        gm.resetGameStats.GameResetter();
      }
    }
  }
}
