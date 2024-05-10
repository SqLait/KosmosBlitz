namespace SpaceShooter
{
  internal class GameObject
  {
    protected GraphicsDeviceManager graphics;
    protected Vector2 position;
    protected Texture2D texture;

    // A simple blueprint for all the gameobjects in the game.
    public GameObject(Texture2D pTexture, Vector2 pPosition, GraphicsDeviceManager pGraphics)
    {
      position = pPosition;
      texture = pTexture;
      graphics = pGraphics;
    }

    public virtual void LoadContent() { }

    public virtual void Initialize() { }

    public virtual void Update(GameTime pGameTime) { }

    public virtual void Draw(SpriteBatch pSpriteBatch) { }
  }
}
