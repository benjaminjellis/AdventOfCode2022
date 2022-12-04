let getInput path = System.IO.File.ReadAllLines(path)

let split (sep: string) (x: string) = x.Split(sep)

let parseInput input =
    input
    |> String.concat "|"
    |> split ("||")
    |> Seq.map (split "|")
    |> Seq.map (fun x -> x |> Seq.map int)

let part1 =
    getInput "../../../ProblemInputs/day1.txt"
    |> parseInput
    |> Seq.map Seq.sum
    |> Seq.max

let part2 =
    getInput "../../../ProblemInputs/day1.txt"
    |> parseInput
    |> Seq.map Seq.sum
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum

[<EntryPoint>]
let main _ =
    let part1Ans = part1
    let part2Ans = part2
    printfn "%i" part1Ans
    printfn "%i" part2Ans
    0
