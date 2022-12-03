open System
open System.IO

//1 : A for Rock, B for Paper, and C for Scissors
//2 : X for Rock, Y for Paper, and Z for Scissors

// score
// shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors)
// outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won)

type Play = Rock | Paper | Scissors
    with 
    static member parse (c:char) = 
        match c with 
        | 'A' | 'X' -> Rock
        | 'B' | 'Y' -> Paper
        | 'C' | 'Z' -> Scissors
        | _ -> failwith "invalid input"

    static member score (theirs:Play) (ours:Play) =
        match theirs, ours with 
        | Rock, Rock -> 3 + 1
        | Rock, Paper -> 6 + 2
        | Rock, Scissors -> 0 + 3
        
        | Paper, Rock -> 0 + 1
        | Paper, Paper -> 3 + 2
        | Paper, Scissors -> 6 + 3

        | Scissors, Rock -> 6 + 1
        | Scissors, Paper -> 0 + 2
        | Scissors, Scissors -> 3 + 3

__SOURCE_DIRECTORY__ + "/input"
|> File.ReadLines
|> Seq.where (String.IsNullOrWhiteSpace >> not)
|> Seq.map (fun line -> 
    let round = line[0] |> Play.parse, line[2] |> Play.parse
    round ||> Play.score
    )
|> Seq.sum