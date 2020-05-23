module InterpreterTests

open NUnit.Framework
open FsUnit
open FSlispy.Interpreter


let basicOperations =  
    [
        "1"             , "1"
        "+ 1 1"         , "2"
        "- 2 1"         , "1"
        "- 1 2"         , "-1"
        "* 9 0"         , "0"
        "* 0 9"         , "0"
        "* 0 0"         , "0"
        "* 3 3"         , "9"
        "/ 8 3"         , "2"
        "/ 6 3"         , "2"
        "/ 5 3"         , "1"
        "/ 5 6"         , "0"
    ] |> List.map (fun (expr, eval) -> TestCaseData(expr, eval))

[<TestCaseSource("basicOperations")>]
let ``Basic arithmetic operations`` (lispExpression, expectedEvaluation) = 
    lispExpression |> evaluate |> should equal expectedEvaluation



let basicExpressions = 
    [
        "(+ 1 1)"                 , "2"
        "(+ (+ 1 1) (- 3 5))"     , "0"
    ] |> List.map (fun (expr, eval) -> TestCaseData(expr, eval))

[<TestCaseSource("basicExpressions")>]
let ``Basic expressions`` (lispExpression, expectedEvaluation) = 
    lispExpression |> evaluate |> should equal expectedEvaluation



let applyFunctionToNparameters = 
    [
        "+ 1 1 1"                 , "3"
        "(+ 1 2 3)"               , "6"
        "(+ (+ 1 2) (+ 1 2) 3)"   , "9"
        "(- 1 2 3)"               , "-4"
    ] |> List.map (fun (expr, eval) -> TestCaseData(expr, eval))

[<TestCaseSource("applyFunctionToNparameters")>]
let ``Apply a function to N parameters`` (lispExpression, expectedEvaluation) = 
    lispExpression |> evaluate |> should equal expectedEvaluation    