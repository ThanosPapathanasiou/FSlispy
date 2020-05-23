module FSlispy.Runtime

type Expression = 
  | Number of int
  | Symbol of Symbol
  | Function of (Expression list -> Expression)
  | List of Expression list
and Symbol = { Name: string}

let error func =
    sprintf "Error in function %s" func |> failwith

let math args op =
    match args with
    | Number (n) :: nbs ->
        let f x = function Number (y) -> op x y | _ -> error (op.ToString ())
        Number (List.fold f n nbs)
    | _ -> error (op.ToString ())

let Op (op:string) =
  match op with 
  | "+" -> Function ( fun args -> math args (+))
  | "-" -> Function ( fun args -> math args (-))
  | "*" -> Function ( fun args -> math args (*))
  | "/" -> Function ( fun args -> math args (/))
  | _ -> failwith (sprintf "Couldn't recognize operator: '%s'" op)

let evaluate (exp: Expression) =

  let rec evaluate' (exp: Expression) = 
    match exp with 
    | Number (_) as n -> n
    | Symbol s -> (Op (string s.Name)) // the only symbols right now are the math operators
    | List l -> 
      match l with
      | [head] -> evaluate' head
      | head :: tail ->
        match evaluate' head with 
        | Function f -> f ( tail |> List.map evaluate')
        | _ -> failwith "Failed when evaluating full list of expressions"
      | _ -> failwith "Failed when evaluating a list of expressions"
    | _ -> failwith "Failed when evaluating an expression"

  let e = evaluate' exp

  match e with 
  | Number n -> string (int n)
  | _ -> failwith "Failed when trying to convert the expression result to string"