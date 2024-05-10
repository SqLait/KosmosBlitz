using System.Collections.Generic;

namespace SpaceShooter
{
  internal class GameManager
  {
    private List<GameObject> gameObjList = new List<GameObject>();
    public List<GameObject> GameObjList {get => gameObjList; set => gameObjList = value;}

    private bool playerAlive = true;
    public bool PlayerAlive {get => playerAlive; set => playerAlive = value;}


    public GraphicsDeviceManager graphics;
    public Vector2 shipPos;
    public Texture2D shipTexture;
    public Texture2D bulletTexture;

    //Introducing one of these to prevent state issues.
    public GameResult GameResult = GameResult.None;

    public ScoreManager scoreManager;
    public GameStateManager gameStateManager;
    public InitializeGame initializeGame;
    public DrawText drawText;
    public ResetGameStats resetGameStats;
    public BulletFactory bulletFactory;
    public BulletManager bulletManager;
    public AngreehManager angreehManager;
    public AngreehFactory angreehFactory;

    /// <summary>
    ///  Create one of all the subclasses in order to prevent state related issues.
    ///  Yes it will introduce more typing work but this makes the code safer and better to reason about.
    /// </summary>
    public GameManager(Texture2D pShipTexture, Texture2D pBulletTexture, GraphicsDeviceManager pGraphics)
    {
      graphics = pGraphics;
      shipTexture = pShipTexture;
      bulletTexture = pBulletTexture;

      scoreManager = new ScoreManager(this);
      gameStateManager = new GameStateManager(this);
      initializeGame = new InitializeGame(this);
      drawText = new DrawText(this);
      resetGameStats = new ResetGameStats(this);
      bulletFactory = new BulletFactory(this);
      bulletManager = new BulletManager(this);
      angreehManager = new AngreehManager(this);
      angreehFactory = new AngreehFactory(this);
    }
  }
}
