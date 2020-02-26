module BinaryRelations.Program

let printMatrix (matrix: int list list): unit =
    let size = matrix |> List.length
    for i in [0..size - 1] do
        for j in [0..size - 1] do
            matrix.[i].[j] |> printf " %d " |> ignore
        printfn "" |> ignore

let printVector (vector: int list): unit =
    vector |> List.iter (fun x -> x |> printf " %d " |> ignore)

let getMaxR (graph: int list list): int list =
    let size = graph |> List.length
    let maxR = [| for i in [0..size-1] do 1 |]

    for i in [0..size - 1] do
        for j in [0..size - 1] do
            if graph.[i].[j] = 1 then
                if graph.[j].[i] = 0 then
                    maxR.[j] <- 0
                if graph.[j].[i] = 1 && maxR.[i] = 0 then
                    maxR.[j] <- 0

    maxR |> List.ofArray

let getMaxR1 (graph: int list list): int list =
    let size = graph |> List.length
    let maxR = [| for i in [0..size-1] do 1 |]

    for i in [0..size - 1] do
        for j in [0..size - 1] do
            let neverDominated = true
            if graph.[i].[j] = 1 then
                if graph.[j].[i] = 0 then
                    maxR.[j] <- 0


                if graph.[j].[i] = 1 && maxR.[i] = 0 then
                    maxR.[j] <- 0

    maxR |> List.ofArray

[<EntryPoint>]
let main (args: string array): int =
    let matrix = Data.relationGraph1
    printfn "Processing graph:" |> ignore
    matrix |> printMatrix |> ignore
    printfn "MaxR vector:"
    matrix |> getMaxR |> printVector
    0