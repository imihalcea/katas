module View
 
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System
open Microsoft.Xna.Framework.Input
 
type GameUI () as x =
    inherit Game()
 
    do x.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(x)
    do graphics.SynchronizeWithVerticalRetrace <- true
    do x.TargetElapsedTime <- TimeSpan.FromSeconds(0.15)
    do x.IsFixedTimeStep <- true
    let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>
 
    override x.Initialize() =
        do spriteBatch <- new SpriteBatch(x.GraphicsDevice)
        do graphics.PreferredBackBufferWidth <- 1920;
        do graphics.PreferredBackBufferHeight <- 1080;
        do graphics.IsFullScreen <- true;
        do graphics.ApplyChanges();
        do base.Initialize()
        ()
    
    override x.LoadContent() =
        ()
 
    override x.Update (gameTime) =
        if GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) then
            x.Exit()
        ()
 
    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.CornflowerBlue
        ()