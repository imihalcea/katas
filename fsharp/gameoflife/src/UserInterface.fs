module View
 
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System
open Microsoft.Xna.Framework.Input
open Domain
 
type GameUI (cellSize:int, initalState:Cells, fUpdade:Evolve) as x =
    inherit Game()
    let mutable gameState = initalState
    let gameLogic = fUpdade
    let cellSize = cellSize
    do x.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(x)
    do graphics.SynchronizeWithVerticalRetrace <- false
    do x.TargetElapsedTime <- TimeSpan.FromSeconds(0.05)
    do graphics.ApplyChanges();
    do x.IsFixedTimeStep <- true
    let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>
 
    override x.Initialize() =
        do spriteBatch <- new SpriteBatch(x.GraphicsDevice)
        //do graphics.PreferredBackBufferWidth <- 1920;
        //do graphics.PreferredBackBufferHeight <- 1080;
        //do graphics.IsFullScreen <- true;

        do base.Initialize()
        ()
    
    override x.LoadContent() =
        ()
 
    override x.Update (gameTime) =
        if GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) then
            x.Exit()
        gameState <- gameLogic gameState 
        ()
 
    member this.DrawCell(cell:Cell)=
        let texture1px = new Texture2D(graphics.GraphicsDevice,1,1)
        do texture1px.SetData([|Color.Red|])
        let (x,y) = Grid.cellCoordinates cell
        let rect =  Rectangle(x*cellSize,y*cellSize,cellSize,cellSize)
        do spriteBatch.Draw(texture1px,rect,Color.Black)
        ()

    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.White
        do spriteBatch.Begin()
        gameState |> List.iter x.DrawCell
        do spriteBatch.End()
        ()