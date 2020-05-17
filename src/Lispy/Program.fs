open System

open Interpreter

[<EntryPoint>]
let main argv =
    printfn "Lispy version 0.0.1"
    printfn "Press Ctrl+c to Exit"

    while true do
        printf "> "
        let input = Console.ReadLine()
        let result = Interpreter.evaluate input
        printfn "%s" result
    0