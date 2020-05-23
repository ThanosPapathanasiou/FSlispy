module FSlispy.Interpreter

open FSharp.Text.Lexing
open FSlispy.Lexer

let evaluate (input:string) =
  let lexbuf = LexBuffer<char>.FromString input
  let expression = Parser.lispy tokenize lexbuf
  let value = Runtime.evaluate expression
  value