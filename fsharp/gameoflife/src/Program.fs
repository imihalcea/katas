open System
open View
open Domain


[<EntryPoint>]
let main argv =
    let blinker = [Live(50,50);Live(50,51);Live(50,52)]
    let grid = GoL.init blinker
    use g = new GameUI(5, grid, Grid.evolve)
    g.Run()
    0
