open System

let relationGraph = [
    [0; 1; 0; 0; 0; 0]
    [1; 0; 1; 1; 0; 0]
    [0; 0; 0; 0; 0; 0]
    [0; 1; 0; 0; 1; 0]
    [0; 0; 0; 0; 0; 0]
    [0; 0; 0; 0; 1; 0]
]

let getMaxR (graph: int list list): int list =
    let size = graph |> List.length
    let maxR = [| 1; 1; 1; 1; 1 |]

    for i in [0..size - 1] do
        for j in [0..size - 1] do
            if graph.[i].[j] = 1 then
                if graph.[j].[i] = 0 then
                    maxR.[j] <- 0
                if graph.[j].[i] = 1 && maxR.[i] = 0 then
                    maxR.[j] <- 0;

    maxR |> List.ofArray

let print (matrix: int list list): unit =
    let size = matrix |> List.length
    for i in [0..size - 1] do
        for j in [0..size - 1] do
            relationGraph.[i].[j] |> printf " %d " |> ignore
        printfn "" |> ignore

[<EntryPoint>]
let main (args: string array): int =
    printf "Processing graph:"
    relationGraph |> print
    printfn "MaxR vector:"
    relationGraph |> getMaxR |> List.iter (fun x -> x |> printf " %d ")
    0