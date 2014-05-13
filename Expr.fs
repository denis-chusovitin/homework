﻿//Chusovitin Denis Copyrights (c) 2014
//Simplify of expressions

type Expr = 
    | Const of int 
    | Var of string 
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

let rec simpl expr = 
    match expr with
    | Add (Const x, Const y) -> Const (x + y)
    | Add (exp, Const 0) | Add (Const 0, exp) -> simpl exp
    | Sub (Var _, Var _) -> Const 0
    | Mul (_, Const 0) | Sub (Const 0, _) -> Const 0
    | Mul (exp, Const 1) | Sub (Const 1, exp) -> simpl exp
    | Div (exp, Const 1) -> simpl exp
    | _ -> expr

let res = simpl (Mul ((Add (Var "x", Const 0)), Const 1))

printfn "%A" res
