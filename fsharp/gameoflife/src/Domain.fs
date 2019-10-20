module Domain

type CellInfo = (int * int)

type Cell = 
|Dead of CellInfo 
|Live of CellInfo

type Cells = list<Cell>

type Evolve = Cells->Cells

module Grid=
    let cellCoordinates cell=
        match cell with
            |Live c -> c
            |Dead c-> c

    let isLive cell =
        match cell with
            |Live _ -> true
            |_-> false

    let isDead cell =
        not(isLive cell)

    let private cellPredicate coords =
        fun cell ->
                match cell with
                    |Live c -> c=coords
                    |Dead c -> c=coords

    let private findCell cells coord =
           List.tryFind (cellPredicate coord) (cells) 

    let obtainCell grid coords =
        let cell = findCell grid coords
        match cell with
            | Some c -> c
            | None -> Dead(coords)

    let private findCells grid coords =
        coords |> List.map (fun c -> (obtainCell grid c))
    
    let obtainNeighbors grid cell =
        let (x,y) = cellCoordinates cell
        [(x-1,y-1); (x-1,y); (x,y-1); (x-1,y+1); (x+1,y-1); (x,y+1); (x+1,y); (x+1,y+1)] |>
        List.filter (fun (x,y)->x>=0 && y>=0) |>
        findCells grid
    
    let numberOfLivingNeighbors grid cell =
        (grid,cell) ||> obtainNeighbors 
        |> List.filter isLive 
        |> List.length

    let evolveCell cells cell=
        let (x,y) = cellCoordinates cell
        match (numberOfLivingNeighbors cells cell) with
        |n when (n=3 && (isDead cell)) -> Live(x,y)
        |n when (isLive cell) && (n=2 || n=3) -> Live(x,y)
        |_ -> Dead(x,y)
   
    let evolve : Evolve =
        fun cells -> 
            cells 
            |> List.collect (fun c -> obtainNeighbors cells c)
            |> List.append cells
            |> List.distinct
            |> List.map (fun c -> evolveCell cells c)
            |> List.filter isLive

module GoL = 
    type Init = list<(int*int)> -> Cells
    type Run = unit -> unit
    
    let init : Init = 
        fun cells -> 
            cells |> List.map (fun c -> Live(c))
            