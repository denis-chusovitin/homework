//Chusovitin Denis Copyrights (c) 2014
//Simplify of expressions

module Expr

type Expr = 
    | Const of int 
    | Var of string 
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

let rec simpl expr = 
    let simpl' expr =
        match expr with
        | Add (Const x, Const y) -> Const (x + y)
        | Sub (Const x, Const y) -> Const (x - y)
        | Mul (Const x, Const y) -> Const (x * y)
        | Div (Const x, Const y) -> Const (x / y)
        | Add (exp, Const 0) | Add (Const 0, exp) -> simpl exp
        | Sub (Var x, Var y) when x = y -> Const 0
        | Mul (Const 0, _) | Mul (_, Const 0) -> Const 0                  
        | Mul (exp, Const 1) | Mul (Const 1, exp) -> simpl exp
        | Div (exp, Const 1) -> simpl exp
        | _ -> expr

    match expr with
    | Add (a, b) -> simpl' (Add (simpl a, simpl b))
    | Sub (a, b) -> simpl' (Sub (simpl a, simpl b))
    | Mul (a, b) -> simpl' (Mul (simpl a, simpl b))
    | Div (a, b) -> simpl' (Div (simpl a, simpl b))
    | _ -> expr



printfn "%A" (simpl (Add(Div(Const 2, Mul(Const 1, Const 1)), Const 0))) 

