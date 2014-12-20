module TestConvex

open Convex
open NUnit.Framework

[<TestFixture>]
type Tests() =
    [<Test>]
    member x.Test1() =
        Assert.IsTrue(isConvex [|{X = 0; Y = 0}; {X = 0; Y = 4}; {X = 2; Y = 3}; {X = 4; Y = 0}|])
    [<Test>]
    member x.Test2() =
        Assert.IsTrue(isConvex [|{X = 0; Y = 0}; {X = 0; Y = 4}; {X = 3; Y = 2}; {X = 4; Y = 0}|])
    [<Test>]
    member x.Test3() =
        Assert.IsTrue(isConvex [|{X = 0; Y = 0}; {X = 0; Y = 4}; {X = 6; Y = 7}; {X = 4; Y = 0}|])
    [<Test>]
    member x.Test4() =
        Assert.IsTrue(isConvex [|{X = 0; Y = 0}; {X = 2; Y = 4}; {X = 2; Y = 0}; {X = 1; Y = -1}|])
    [<Test>]
    member x.Test5() =
        Assert.IsFalse(isConvex [|{X = 0; Y = 0}; {X = 0; Y = 4}; {X = 2; Y = 1}; {X = 4; Y = 0}|])
    [<Test>]
    member x.Test6() =
        Assert.IsTrue(isConvex [|{X = 0; Y = 0}; {X = 0; Y = -4}; {X = -4; Y = -4}; {X = -4; Y = 0}|])
    [<Test>]
    member x.Test7() =
        Assert.IsFalse(isConvex [|{X = 0; Y = 0}; {X = 2; Y = 4}; {X = 2; Y = 0}; {X = 1; Y = 1}|])
    [<Test>]
    member x.Test8() =
        Assert.IsFalse(isConvex [|{X = 0; Y = 0}; {X = 1; Y = 0}; {X = 100; Y = 0}; {X = 1; Y = -1}|])
    [<Test>]
    member x.Test9() =
        Assert.IsTrue(isConvex [|{X = 1; Y = 2}; {X = 3; Y = 10}; {X = 5; Y = 8}; {X = 3; Y = -4}|])
    [<Test>]
    member x.Test10() =
        Assert.IsFalse(isConvex [|{X = 0; Y = 0}; {X = 5; Y = 5}; {X = 10; Y = 0}; {X = -5; Y = -5}|])