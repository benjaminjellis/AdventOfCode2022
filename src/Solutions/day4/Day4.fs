let getInput path = System.IO.File.ReadAllLines(path)
let split (sep: string) (x: string) = x.Split(sep)

let getPairs (x: string[]) : int[] * int[] =
    let firstPair = x[0] |> split "-" |> Array.map int
    let secondPair = x[1] |> split "-" |> Array.map int
    (firstPair, secondPair)

let findCompleteOverlap (x: string[]) : int =
    let (firstPair, secondPair) = getPairs x

    if firstPair[0] <= secondPair[0] && secondPair[1] <= firstPair[1] then
        1
    else if secondPair[0] <= firstPair[0] && firstPair[1] <= secondPair[1] then
        1
    else
        0

let findAnyOverlap (x: string[]) : int =
    let (firstPair, secondPair) = getPairs x

    if firstPair[0] < secondPair[0] && firstPair[1] < secondPair[0] then
        0
    else if firstPair[0] > secondPair[1] then
        0
    else
        1

let part1 =
    getInput "../../../ProblemInputs/day4.txt"
    |> Seq.map (fun x -> split "," x)
    |> Seq.map findCompleteOverlap
    |> Seq.sum


let part2 =
    getInput "../../../ProblemInputs/day4.txt"
    |> Seq.map (fun x -> split "," x)
    |> Seq.map findAnyOverlap
    |> Seq.sum


[<EntryPoint>]
let main _ =
    let part1Ans = part1
    let part2Ans = part2
    printfn "Part 1 ans: %i" part1Ans
    printfn "Part 2 ans: %i" part2Ans
    0
