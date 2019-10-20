open System
open View
open Domain


[<EntryPoint>]
let main argv =
    let blinker = [Live(25,25);Live(25,26);Live(25,27)]
    let glider = [Live(7,6);Live(8,7);Live(8,8);Live(7,8);Live(6,8)]
    let grid = GoL.init glider
    use g = new GameUI(5, grid, Grid.evolve)
    g.Run()
    0
