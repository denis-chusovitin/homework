module Tests

open Regex
open NUnit.Framework

[<TestFixture>]
type Tests() =
    [<Test>]
    member x.Test1() = 
        Assert.AreEqual(regexp "qwerty123@soap.com", true, "error")
    [<Test>]
    member x.Test2() = 
        Assert.AreEqual(regexp "qw.ert.y123@so.ap.com", true, "error")
    [<Test>]
    member x.Test3() = 
        Assert.AreEqual(regexp "123qwerty123@soap.com", false, "error")
    [<Test>]
    member x.Test4() = 
        Assert.AreEqual(regexp "qwe..rty123@soap.com", false, "error")
    [<Test>]
    member x.Test5() = 
        Assert.AreEqual(regexp "qwerty123soap.com", false, "error")
    [<Test>]
    member x.Test6() = 
        Assert.AreEqual("a@b.cc", true, "error")
    [<Test>]
    member x.Test7() = 
        Assert.AreEqual("vasya.pupkun@soap.com", true, "error")
    [<Test>]
    member x.Test8() = 
        Assert.AreEqual("my@domain.info", true, "error")
    [<Test>]
    member x.Test9() = 
        Assert.AreEqual("_.1@mail.com", true, "error")
    [<Test>]
    member x.Test10() = 
        Assert.AreEqual("paints_department@hermitage.museum", true, "error")
    [<Test>]
    member x.Test11() = 
        Assert.AreEqual("a@b.c", false, "error")
    [<Test>]
    member x.Test12() = 
        Assert.AreEqual("a..b@mail.ru", false, "error")
    [<Test>]
    member x.Test13() = 
        Assert.AreEqual(".a@mail.ru", false, "error")
    [<Test>]
    member x.Test14() = 
        Assert.AreEqual("yo@domain.somedomain", false, "error")
    [<Test>]
    member x.Test15() = 
        Assert.AreEqual("1@mail.ru", false, "error")
