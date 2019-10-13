module Domain

type CellInfo = (int * int)

type Cell = 
|Dead of CellInfo 
|Live of CellInfo

type Grid = {Size:(int * int); Cells:list<Cell>;}

module Grid =
    type Evolve = Cell -> list<Cell> -> Cell
    
    let private findCell grid coords =
        let predicate = 
            fun cell ->
                match cell with
                    |Live c -> c=coords
                    |Dead c -> c=coords

        let found = grid.Cells |> List.filter predicate
        if found.Length>0 then
            Some(found.Head)
        else
            None


    let read grid coords =
        let cell = findCell grid coords
        match cell with
            | Some c -> c
            | None -> Dead(coords)
    
    let isLive cell =
        match cell with
            |Live _ -> true
            |_-> false

    let isDead cell =
        not(isLive cell)
    
    

module GoL = 
    type Init = (int*int) -> list<Cell> -> Grid
    type Run = unit -> unit
    
    let init : Init = 
        fun gridSize cells ->
            {Size=gridSize; Cells=cells}