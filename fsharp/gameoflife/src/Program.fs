open System
open View
open Domain


[<EntryPoint>]
let main argv =
    let grid = GoL.init Patterns.glidergun
    use g = new GameUI(8, grid, Grid.evolve)
    g.Run()
    0
