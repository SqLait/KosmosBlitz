using System.Collections.Generic;

namespace SpaceShooter
{
  internal class AngreehManager : BaseManager
  {
    private List<Angreeh> angreehLs = new List<Angreeh>();
    public List<Angreeh> AngreehLs { get => angreehLs; set => angreehLs = value; }
    public bool destroyedAngreeh;

    public AngreehManager(GameManager pGameManager) : base(pGameManager) {}

    /*Loop over all the enemies in the list of enemies*/
    public override void ListLoop(SpriteBatch pSpriteBatch)
    {
      foreach (Angreeh i in angreehLs)
      {
        i.DrawEnemy(pSpriteBatch);
      }
    }

    public override void Update(GameTime pGameTime)
    {
      for (int i = 0; i < angreehLs.Count; i++)
      {
        angreehLs[i].MoveAngreeh(pGameTime);
        angreehLs[i].UpdateRectangle();

        if (angreehLs[i].enemyPos.Y < 0)
        {
          angreehLs.RemoveAt(i);
          i--;
        }
      }
    }
  }
}
