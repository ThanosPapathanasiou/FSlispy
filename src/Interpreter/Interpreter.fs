module FSlispy.Interpreter

open FSharp.Text.Lexing
open FSlispy.Lexer

let evaluate (input:string) =
  let lexbuf = LexBuffer<char>.FromString input
  let output = Parser.main tokenize lexbuf
  string output
