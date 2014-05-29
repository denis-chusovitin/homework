module Test

open Expr
open NUnit.Framework

[<TestFixture>]
type Tests() =
    [<Test>]
    member x.Test1() = 
        Assert.AreEqual(simpl (Sub(Var "x", Var "y")), (Sub(Var "x", Var "y")), "error")
    [<Test>]
    member x.Test2() = 
        Assert.AreEqual(simpl (Sub(Var "x", Var "x")), Const 0, "error")
    [<Test>]
    member x.Test3() = 
        Assert.AreEqual(simpl (Div(Mul(Add(Const 0, Const 2),Add(Const 3, Const 4)), Sub(Const 5, Const 3))), Const 7, "error")
    [<Test>]
    member x.Test4() = 
        Assert.AreEqual(simpl (Mul(Add(Var "x", Const 4), Const 0)), Const 0 , "error")
    [<Test>]
    member x.Test5() = 
        Assert.AreEqual(simpl (Sub(Mul(Const 13, Const 1), Mul(Const 5, Const 2))), Const 3, "error")
    [<Test>]
    member x.Test6() = 
        Assert.AreEqual(simpl (Add(Var "x", Var "y")), Add(Var "x", Var "y"), "error")
    [<Test>]
    member x.Test7() = 
        Assert.AreEqual(simpl (Add(Mul(Sub(Const 5, Const 2), Var "x"), Mul(Mul(Const 3, Const 2), Var "y"))), Add(Mul(Const 3, Var "x"), Mul(Const 6, Var "y")), "error")
    [<Test>]
    member x.Test8() = 
        Assert.AreEqual(simpl (Sub(Const 4, Div(Const 8, Const 4))), Const 2, "error")
    [<Test>]
    member x.Test9() = 
        Assert.AreEqual(simpl (Add(Div(Const 2, Mul(Const 1, Const 1)), Const 0)), Const 2, "error")