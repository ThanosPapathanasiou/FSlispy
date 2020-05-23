module FSlispy.Lispy

open System
open FSlispy.Interpreter

[<EntryPoint>]
let main argv =
    printfn "Lispy version 0.0.5"
    printfn "Press Ctrl+c or type 'exit' to Exit"

    while true do
        printf "λ> "
        let input = Console.ReadLine()
        match input with 
        | "exit" -> Environment.Exit 0
        | _ -> let result = Interpreter.evaluate input
               printfn "%s" result
    0