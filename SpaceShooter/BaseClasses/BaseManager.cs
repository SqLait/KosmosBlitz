namespace SpaceShooter
{
  internal abstract class BaseManager
  {
    //Implemented for the Angreeh and bullet manager.
    protected GameManager gm;

    public BaseManager(GameManager pGameManager) => gm = pGameManager;

    public abstract void ListLoop(SpriteBatch pSpriteBatch); //loop over a list containing GameObjects.
    public abstract void Update(GameTime pGameTime); //Update them throughout the programs life cycle.
  }
}
