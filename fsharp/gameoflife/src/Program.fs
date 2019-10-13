// Learn more about F# at http://fsharp.org

open System
open View
open Domain

[<EntryPoint>]
let main argv =
    use g = new GameUI()
    g.Run()
    0
