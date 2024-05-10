namespace SpaceShooter
{
  internal class ScoreManager
  {
    private GameManager gm;
    private int score;
    public int Score { get => score; private set => score = value; }
    public ScoreManager(GameManager pGameManager) => this.gm = pGameManager;

    public void UpdateScore()
    {
      if (gm.angreehManager.destroyedAngreeh)
      {
        score++;
        gm.angreehManager.destroyedAngreeh = false;
      }
    }

    public void ResetScore() => score = 0;

    public void IncrementScore() => score++;
  }
}
