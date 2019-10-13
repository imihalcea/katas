module Domain

type CellInfo = (int * int)

type Cell = 
|Dead of CellInfo 
|Live of CellInfo

type Cells = list<Cell>


module Grid=
    type Evolve = Cells -> Cells
    type private EvolveCell = Cell -> list<Cell> -> Cell

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

module GoL = 
    type Init = (int*int) -> list<Cell> -> Cells
    type Run = unit -> unit
    
    let init : Init = 
        fun size cells -> cells
            