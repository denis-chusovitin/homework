module Tests

open Regex
open NUnit.Framework

[<TestFixture>]
type Tests() =
    [<Test>]
    member x.Test1() = 
        Assert.IsTrue(isEmail "qwerty123@soap.com", "error")
    [<Test>]
    member x.Test2() = 
        Assert.IsTrue(isEmail "qw.ert.y123@so.ap.com", "error")
    [<Test>]
    member x.Test3() = 
        Assert.IsFalse(isEmail "123qwerty123@soap.com", "error")
    [<Test>]
    member x.Test4() = 
        Assert.IsFalse(isEmail "qwe..rty123@soap.com", "error")
    [<Test>]
    member x.Test5() = 
        Assert.IsFalse(isEmail "qwerty123soap.com", "error")
    [<Test>]
    member x.Test6() = 
        Assert.IsTrue(isEmail "a@b.cc", "error")
    [<Test>]
    member x.Test7() = 
        Assert.IsTrue(isEmail "vasya.pupkun@soap.com", "error")
    [<Test>]
    member x.Test8() = 
        Assert.IsTrue(isEmail "my@domain.info", "error")
    [<Test>]
    member x.Test9() = 
        Assert.IsTrue(isEmail "_.1@mail.com", "error")
    [<Test>]
    member x.Test10() = 
        Assert.IsTrue(isEmail "paints_department@hermitage.museum", "error")
    [<Test>]
    member x.Test11() = 
        Assert.IsFalse(isEmail "a@b.c", "error")
    [<Test>]
    member x.Test12() = 
        Assert.IsFalse(isEmail "a..b@mail.ru", "error")
    [<Test>]
    member x.Test13() = 
        Assert.IsFalse(isEmail ".a@mail.ru", "error")
    [<Test>]
    member x.Test14() = 
        Assert.IsFalse(isEmail "yo@domain.somedomain", "error")
    [<Test>]
    member x.Test15() = 
        Assert.IsFalse(isEmail "1@mail.ru", "error")
