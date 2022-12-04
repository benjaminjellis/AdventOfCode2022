let getInput path = System.IO.File.ReadAllLines(path)

let split (sep: string) (x: string) = x.Split(sep)

let parseInput input =
    input
    |> String.concat "|"
    |> split ("||")
    |> Seq.map (split "|")
    |> Seq.map (fun x -> x |> Seq.map int)

let part1 =
    let input = getInput "../../../ProblemInputs/day1.txt"
    let parsedInput = parseInput input
    let calories = parsedInput |> Seq.map Seq.sum
    let maxCalories = calories |> Seq.max
    maxCalories

let part2 =
    let input = getInput "../../../ProblemInputs/day1.txt"
    let parsedInput = parseInput input
    let calories = parsedInput |> Seq.map Seq.sum
    let top3CalroiesSum = calories |> Seq.sortDescending |> Seq.take 3 |> Seq.sum
    top3CalroiesSum

[<EntryPoint>]
let main _ =
    let part1Ans = part1
    let part2Ans = part2
    printfn "%i" part1Ans
    printfn "%i" part2Ans
    0
