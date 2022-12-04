let getInput path = System.IO.File.ReadAllLines(path)

let splitInputIntoRucksacks input =
    let inputLen = String.length input
    let middle = inputLen / 2
    let firstRucksack = input[.. middle - 1]
    let secondRucksack = input[middle..]
    (firstRucksack, secondRucksack)


let lookupScore s =
    // convert the Set of chars into an Array of chars as then take the 0th element
    let item = Set.toArray s |> fun a -> a[0]

    if int item <= int 'Z' then
        int item - int 'A' + 27
    else
        int item - int 'a' + 1


let part1 =
    getInput "../../../ProblemInputs/day3.txt"
    |> Seq.map splitInputIntoRucksacks
    |> Seq.map (fun (first, second) ->
        let fristAsSet = first |> Set.ofSeq
        let secondAsSet = second |> Set.ofSeq
        Set.intersect fristAsSet secondAsSet |> lookupScore)
    |> Seq.sum

let part2 =
    getInput "../../../ProblemInputs/day3.txt"
    |> Seq.map Set.ofSeq
    |> Seq.chunkBySize 3
    |> Seq.map Set.intersectMany
    |> Seq.map lookupScore
    |> Seq.sum


[<EntryPoint>]
let main _ =
    let part1Ans = part1
    let part2Ans = part2
    printfn "Part 1 ans: %i" part1Ans
    printfn "Part 2 ans: %i" part2Ans
    0
