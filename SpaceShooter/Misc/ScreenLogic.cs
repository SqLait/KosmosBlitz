namespace SpaceShooter
{
  internal class ScreenLogic
  {
    /*With the use of the dynamic type, I don't have to find a crazy work around to get variables from the Game class.
     * All that dynamic does is that it allows me to create a variable in this context where I can easily pass
     * 2 Game based variables, and the type will be the type of the variable passed as a parameter.
     */
    public void EnableFullScreen(GraphicsDeviceManager pGraphics, dynamic pContent, dynamic pIsMouseVisible)
    {
      pContent.RootDirectory = "Content";
      pIsMouseVisible = false;

      pGraphics.PreferredBackBufferWidth = GraphicsAdapter
        .DefaultAdapter
        .CurrentDisplayMode
        .Width;
      pGraphics.PreferredBackBufferHeight = GraphicsAdapter
        .DefaultAdapter
        .CurrentDisplayMode
        .Height;

      pGraphics.IsFullScreen = true;

      pGraphics.HardwareModeSwitch = true;

      pGraphics.ApplyChanges();
    }
  }
}
