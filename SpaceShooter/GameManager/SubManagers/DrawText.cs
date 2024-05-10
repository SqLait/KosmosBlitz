namespace SpaceShooter
{
  internal class DrawText
  {
    private GameManager gm;

    public SpriteFont textFont; 
    public bool drawInitialText = true;

    public DrawText(GameManager pGameManager) => this.gm = pGameManager;

    public void DrawTextOnScreen(SpriteBatch pSpriteBatch)
    {
      if (drawInitialText)
      {
        GameState(pSpriteBatch);
      }
      else if (gm.gameStateManager.gameStarted && gm.GameResult == GameResult.None) //Draw score if game is running
      {
        pSpriteBatch.DrawString(
            textFont,
            $"Score: {gm.scoreManager.Score}\nWave: {gm.gameStateManager.waveCount}",
            new Vector2(10, 10),
            Color.White
            );
      }
    }
    private void GameState(SpriteBatch pSpriteBatch) //what text should be printed in what state
    {
      switch (gm.GameResult)
      {
        case GameResult.Win:
          pSpriteBatch.DrawString(
            textFont,
            $"You won the game!\nPress <Enter> to advance to wave: {gm.gameStateManager.waveCount}, or <Esc> to leave.",
            new Vector2(100, 200),
            Color.White
            );
          break;

        case GameResult.Lose:
          pSpriteBatch.DrawString(
            textFont,
            $"Looks like you died my friend!\n\nDied on Wave: {gm.gameStateManager.waveHighScore}\n\nPress <Enter> to play again or <Esc> to leave.",
            new Vector2(100, 200),
            Color.White
            );
          break;

        default:
          pSpriteBatch.DrawString(
            textFont,
            "Welcome to\n\n -KosmosBlitz-\n\n Kill 25 ships to progress to the next wave!\n\n Move with A & D and fire with SPACE.\n\nPress <Enter> to start or <Esc> to exit.",
            new Vector2(100, 200),
            Color.White
            );
          break;
      }
    }
  }
}
