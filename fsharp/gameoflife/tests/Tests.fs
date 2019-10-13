module Tests

open System
open Xunit
open Domain

[<Fact>]
let ``when no cell then read cell returns Dead cell`` () =
    let grid = GoL.init (100,100) []
    let cell = Grid.read grid (5,5)
    Assert.True((Grid.isDead cell))

[<Fact>]
let ``should read Live cell`` () =
    let grid = GoL.init (100,100) [Live(5,5)]
    let cell = Grid.read grid (5,5)
    Assert.True((Grid.isLive cell))
