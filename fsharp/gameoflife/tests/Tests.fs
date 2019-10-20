module Tests

open System
open Xunit
open Domain
open System.Collections.Generic

let private checkOutcome expected actual =
    expected |> List.iter (fun c -> (List.contains c actual) |> Assert.True)

[<Fact>]
let ``when no cell then read cell returns Dead cell`` () =
    let grid = GoL.init []
    let cell = Grid.obtainCell grid (5,5)
    Assert.True((Grid.isDead cell))

[<Fact>]
let ``should read Live cell`` () =
    let grid = GoL.init [Live(5,5)]
    let cell = Grid.obtainCell grid (5,5)
    Assert.True((Grid.isLive cell))

[<Fact>]
let ``should obtain Dead cell`` () =
    let grid = GoL.init [Dead(5,5)]
    let cell = Grid.obtainCell grid (5,5)
    Assert.True((Grid.isDead cell))

[<Fact>]
let ``should obtain neighbors of one cell``()=
    let grid = GoL.init [Live(5,5)]
    let cells = Grid.obtainNeighbors grid grid.[0]
    let expected = [Dead(4,4);Dead(4,5);Dead(5,4);Dead(4,6);Dead(6,4);Dead(5,6); Dead(6,5);Dead(6,6)]
    Assert.Equal(8,cells.Length)
    checkOutcome expected cells

[<Fact>]
let ``should obtain neighbors of one cell on the edge``()=
    let grid = GoL.init [Live(0,0)]
    let cells = Grid.obtainNeighbors grid grid.[0]
    let expected = [Dead(0,1);Dead(1,0);Dead(1,1)]
    Assert.Equal(3,cells.Length)
    checkOutcome expected cells

[<Fact>]
let ``Any live cell with fewer than two live neighbours dies by underpopulation test 1``()=
    let cells = GoL.init [Live(5,4)]
    let nextCells = Grid.evolve cells
    checkOutcome [] nextCells

[<Fact>]
let ``Any live cell with fewer than two live neighbours dies by underpopulation test 2``()=
    let cells = GoL.init [Live(5,4);Live(5,5)]
    let nextCells = Grid.evolve cells
    checkOutcome [] nextCells

[<Fact>]
let ``Any live cell with two live neighbours lives on to the next generation``()=
    let cells = GoL.init [Live(5,4);Live(5,5);Live(4,4); Live(7,5)]
    let nextCells = Grid.evolve cells
    checkOutcome [Live(5,4);Live(5,5);Live(4,4)] nextCells

[<Fact>]
let ``Any live cell with three live neighbours lives on to the next generation``()=
    let cells = GoL.init [Live(5,4);Live(5,5);Live(4,4);Live(4,5); Live(7,5)]
    let nextCells = Grid.evolve cells
    checkOutcome [Live(5,4);Live(5,5);Live(4,4);Live(4,5)] nextCells

[<Fact>]
let ``Any live cell with more than three live neighbours dies by overpopulation``()=
    let cells = GoL.init [Live(5,4);Live(5,5);Live(4,4);Live(4,5); Live(5,3); Live(7,5)]
    let nextCells = Grid.evolve cells
    checkOutcome [Live (5, 5); Live (4, 5); Live (5, 3)] nextCells
    ()

[<Fact>]
let ``Any dead cell with exactly three live neighbours becomes a live cell``()=
    let cells = GoL.init [Live(1,1);Live(2,1);Live(3,1)]
    let nextCells = Grid.evolve cells
    Assert.Equal<IEnumerable<Cell>>([Live(2,1);Live(2,0);Live(2,2)],nextCells)
    ()