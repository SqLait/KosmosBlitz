namespace SpaceShooter
{
  internal class GameStateManager
  {
    private GameManager gm;

    public bool shouldGameReset = false;
    public bool gameStarted;

    private int minimumScore = 25;
    public int waveCount = 1;
    public int waveHighScore = 1;

    public GameStateManager(GameManager pGameManager) => this.gm = pGameManager;
 
    public void ConditionChecker() //manage gamestate by if statements.
    {
      if (gm.scoreManager.Score >= minimumScore && gm.PlayerAlive)
      {
        shouldGameReset = true;
        gameStarted = false;
        gm.GameResult = GameResult.Win;
      }
      else if (gm.scoreManager.Score < minimumScore && !gm.PlayerAlive)
      {
        shouldGameReset = true;
        gameStarted = false;
        gm.GameResult = GameResult.Lose;
      }
    }
  }
}
