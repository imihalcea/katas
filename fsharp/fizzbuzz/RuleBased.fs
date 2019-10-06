module RuleBased
//This implementation is based on a set of rules given as input.

type RuleResult= 
    |Label of string
    |Number of int

let applyRule rule n = 
    let (factor,label) = rule
    if n % factor = 0 then
        Label label
    else
        Number n

let aggregateResults result1 result2 = 
    match result1, result2 with
    | Label l1,Label l2 -> Label (l1 + l2)
    | Number _,Label l  -> Label l
    | Label l,Number _ -> Label l
    | Number n,Number _ -> Number n

let formatResult result=
    match result with
        |Label label -> sprintf "%s" label
        |Number n -> sprintf "%i" n

let fizzbuzzWithRules rules = 
    fun n ->
        rules
        |> List.map (fun rule -> applyRule rule n)
        |> List.reduce aggregateResults
        |> formatResult

