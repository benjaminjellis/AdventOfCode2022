let getInput path = System.IO.File.ReadAllLines(path)

let rock = 1
let paper = 2
let scissors = 3
let win = 6
let loss = 0
let draw = 3

let calcResult element =
    match element with
    // rock + rock = draw
    | "A X" -> rock + draw
    // rock + paper = win
    | "A Y" -> paper + win
    // rock + siscors = loss
    | "A Z" -> scissors + loss
    // paper + rock = loss
    | "B X" -> rock + loss
    // paper + paper = draw
    | "B Y" -> paper + draw
    // paper + scissors = loss
    | "B Z" -> scissors + win
    // scissors + rock = win
    | "C X" -> rock + win
    // scissors + paper = loss
    | "C Y" -> paper + loss
    // scissors + scissors = draw
    | "C Z" -> scissors + draw
    | _ -> failwith "Unexpected chars, not a handled combination"

let calcResultPart2 element =
    match element with
    // rock + loss = sicssors + loss
    | "A X" -> scissors + loss
    // rock + draw = rock + draw
    | "A Y" -> rock + draw
    // rock + win = paper + win
    | "A Z" -> paper + win
    // paper + loss = rock + loss
    | "B X" -> rock + loss
    // paper + draw = paper + draw
    | "B Y" -> paper + draw
    // paper + win = rock + win
    | "B Z" -> scissors + win
    // scissors + loss = paper + loss
    | "C X" -> paper + loss
    // scissors + draw = scissors + draw
    | "C Y" -> scissors + draw
    // scissors + win = paper + win
    | "C Z" -> rock + win
    | _ -> failwith "Unexpected chars, not a handled combination"

let part1 =
    getInput "../../../ProblemInputs/day2.txt"
    |> Seq.map (fun x -> calcResult x)
    |> Seq.sum

let part2 =
    getInput "../../../ProblemInputs/day2.txt"
    |> Seq.map (fun x -> calcResultPart2 x)
    |> Seq.sum


[<EntryPoint>]
let main _ =
    let part1Ans = part1
    let part2Ans = part2
    printfn "Part 1 ans: %i" part1Ans
    printfn "Part 2 ans: %i" part2Ans
    0
