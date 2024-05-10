namespace SpaceShooter
{
  internal static class DrawingExtensions //simple way to draw the rectangle box.
  {
    /*
     * NOTE: This is for test purposes only, if you ever experience issues related to collision you can use this.
     */
    public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color)
    {
      Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
      texture.SetData(new Color[] { color });

      // Draw top line
      spriteBatch.Draw(texture, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 1), color);

      // Draw bottom line
      spriteBatch.Draw(texture, new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 1), color);

      // Draw left line
      spriteBatch.Draw(texture, new Rectangle(rectangle.Left, rectangle.Top, 1, rectangle.Height), color);

      // Draw right line
      spriteBatch.Draw(texture, new Rectangle(rectangle.Right, rectangle.Top, 1, rectangle.Height + 1), color);
    }
  }
}
