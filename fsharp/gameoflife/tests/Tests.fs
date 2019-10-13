module Tests

open System
open Xunit
open Domain

[<Fact>]
let ``when no cell then read cell returns Dead cell`` () =
    let grid = GoL.init (100,100) []
    let cell = Grid.obtainCell grid (5,5)
    Assert.True((Grid.isDead cell))

[<Fact>]
let ``should read Live cell`` () =
    let grid = GoL.init (100,100) [Live(5,5)]
    let cell = Grid.obtainCell grid (5,5)
    Assert.True((Grid.isLive cell))

[<Fact>]
let ``should obtain Dead cell`` () =
    let grid = GoL.init (100,100) [Dead(5,5)]
    let cell = Grid.obtainCell grid (5,5)
    Assert.True((Grid.isDead cell))

[<Fact>]
let ``should obtain neighbors of one cell``()=
    let grid = GoL.init (100,100) [Live(5,5)]
    let cells = Grid.obtainNeighbors grid grid.[0]
    do Console.WriteLine cells.Length
    Assert.Equal(8,cells.Length)

[<Fact>]
let ``should obtain neighbors of one cell on the edge``()=
    let grid = GoL.init (100,100) [Live(0,0)]
    let cells = Grid.obtainNeighbors grid grid.[0]
    do Console.WriteLine cells.Length
    Assert.Equal(3,cells.Length)