using System.Collections.Generic;

namespace SpaceShooter
{
  internal class BulletManager : BaseManager
  {
    private List<Bullet> bulletLs = new List<Bullet>();
    public List<Bullet> BulletLs { get => bulletLs; set => bulletLs = value; }

    public BulletManager(GameManager pGameManager) : base(pGameManager) {}

    public override void ListLoop(SpriteBatch pSpriteBatch)
    {
      foreach (Bullet i in bulletLs)
      {
        i.DrawBullet(pSpriteBatch);
      }
    }

    public override void Update(GameTime pGameTime) //here i update the bullets and the rectangle.
    {
      for (int i = 0; i < bulletLs.Count; i++)
      {
        bulletLs[i].MoveBullets(pGameTime);
        bulletLs[i].UpdateRectangle();

        if (bulletLs[i].bulletPos.Y < 0)
        {
          bulletLs.RemoveAt(i); //if a bullet needs to be removed i skip over an index to make sure i do not read an empty entry.
          i--;
        }
      }
    }

    public void HandleCollisions() //check for collision between the angreeh and the bullet.
    {
      for (int i = gm.angreehManager.AngreehLs.Count - 1; i >= 0; i--)
      {
        for (int j = bulletLs.Count - 1; j >= 0; j--)
        {
          if (bulletLs[j].bulletRect.Intersects(gm.angreehManager.AngreehLs[i].enemyRect))
          {
            gm.scoreManager.IncrementScore();
            gm.angreehManager.AngreehLs.RemoveAt(i);
            bulletLs.RemoveAt(j);
            return;
          }
        }
      }
    }
  }
}
