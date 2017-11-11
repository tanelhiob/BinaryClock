open System
open System.Threading

let parseBinary =
    Array.unfold (fun state -> if state > 0 then Some(state % 2 = 1, state / 2) else None)

let mapBinaryToString binary =
    binary |> Array.map (sprintf "%i") |> String.concat ""
 
let binaryToChar binary =
    if binary then '#'
    else '+'

let printBinaryDigit height (binaryNumber:bool array) =
    if binaryNumber.Length - 1 < height then
        printf " "
    else
        printf "%c" (binaryToChar binaryNumber.[height])

let printClock binaryNumbers =
    let maxHeight = binaryNumbers |> Array.map Array.length |> Array.max

    for i = 0 to maxHeight - 1 do
        binaryNumbers |> Array.iter (printBinaryDigit (maxHeight - 1 - i))
        printfn ""

let handleSecondElapsed _ =

    let localDateTime = System.DateTimeOffset.UtcNow.ToLocalTime();
    let localTime = localDateTime.TimeOfDay;
    
    Console.Clear()
    printClock [|
        parseBinary (localTime.Hours / 10);
        parseBinary (localTime.Hours % 10);
        [||];
        [||];
        parseBinary (localTime.Minutes / 10);
        parseBinary (localTime.Minutes % 10);
        [||];
        [||];
        parseBinary (localTime.Seconds / 10);
        parseBinary (localTime.Seconds % 10);
    |]

[<EntryPoint>]
let main _ = 

    let timer = new System.Timers.Timer(1000.0)
    timer.AutoReset <- true
    timer.Elapsed.Add handleSecondElapsed
    

    timer.Start()
    Thread.Sleep(50000)
    timer.Stop()
    
    

    0 // return an integer exit code
