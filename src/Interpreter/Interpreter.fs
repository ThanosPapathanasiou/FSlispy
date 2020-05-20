module FSlispy.Interpreter

open System.IO
open FSharp.Text.Lexing
open FSlispy.Lexer

let testLexerAndParserFromString (text:string) =
  let lexbuf = LexBuffer<char>.FromString text
  let countFromParser = Parser.start tokenstream lexbuf
    
  countFromParser

let evaluate (input:string) =
  let parserOutput = testLexerAndParserFromString input
  "the word hello was included: " + (string parserOutput) + " times"