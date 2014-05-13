module Tests

open PointSets
open NUnit.Framework

let rec compare set1 set2 = 
    match set1 with
    | Empty -> set1 = set2
    | Point (a, b) -> match set2 with
                      | Point(c, d) -> (a == c) && (b == d) 
                      | _ -> false
    | Line (a, b) -> match set2 with
                     | Line(c, d) -> (a == c) && (b == d)
                     | _ -> false
    | VertLine x -> match set2 with
                    | VertLine y -> x == y
                    | _ -> false
    | LineSegment ((x1, y1), (x2, y2)) -> match set2 with
                                          | LineSegment ((x3, y3), (x4, y4)) -> ((x1 == x3) && (x2 == x4) && (y1 == y3) && (y2 == y4)) ||
                                                                                ((x1 == x4) && (x2 == x3) && (y1 == y4) && (y2 == y3))
                                          | _ -> false

[<TestFixture>]
type Tests() =
    [<Test>]
    member x.Test1() = 
        Assert.AreEqual((compare (interset (Point (0.0, 0.0)) (Point (0.0, 0.0))) (Point (0.0, 0.0))), true, "error")
    [<Test>]
    member x.Test2() = 
        Assert.AreEqual((compare (interset (Point (0.0, 0.0)) (Point (1.0, 6.8))) (Point (0.0, 0.0))), false, "error")
    [<Test>]
    member x.Test3() = 
        Assert.AreEqual((compare (interset (Point (5.3, 12.03)) (Line (1.1, 6.2))) (Point (5.3, 12.03))), true, "error")
    [<Test>]
    member x.Test4() = 
        Assert.AreEqual((compare (interset (Point (5.3, 12.03)) (Line (1.0, 6.2))) (Point (5.3, 12.03))), false, "error")
    [<Test>]
    member x.Test5() = 
        Assert.AreEqual((compare (interset (Point (5.3, 12.03)) (VertLine (1.1))) (Point (5.3, 12.03))), true, "error")
    [<Test>]
    member x.Test6() = 
        Assert.AreEqual((compare (interset (Point (5.3, 12.03)) (VertLine (1.1))) (Point (3.3, 12.03))), false, "error")
    [<Test>]
    member x.Test7() = 
        Assert.AreEqual((compare (interset (Point (5.3, 5.05185)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Point (5.3, 5.05185))), true, "error")
    [<Test>]
    member x.Test8() = 
        Assert.AreEqual((compare (interset (Point (0.5, 3.39259)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Point (0.5, 3.39259))), false, "error")
    [<Test>]
    member x.Test9() = 
        Assert.AreEqual((compare (interset (Point (5.3, 4.32)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Point (5.3, 4.32))), true, "error")
    [<Test>]
    member x.Test10() = 
        Assert.AreEqual((compare (interset (Line (5.4, 4.33)) (Line (5.4, 4.33))), (Line (5.4, 4.33))), true, "error")
    [<Test>]
    member x.Test11() = 
        Assert.AreEqual((compare (interset (Line (5.4, 4.33)) (Line (5.4, 44.3))), (Empty)), true, "error")
    [<Test>]
    member x.Test12() = 
        Assert.AreEqual((compare (interset (Line (5.4, 4.33)) (Line (6.4, 0.32))), (Point (4.01, 25.984))), true, "error")
    [<Test>]
    member x.Test13() = 
        Assert.AreEqual((compare (interset (Line (5.4, 4.33)) (VertLine (6.4))), (Point (6.4, 38.89))), true, "error")
    [<Test>]
    member x.Test14() = 
        Assert.AreEqual((compare (interset (Line (0.345679, 3.21975)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (LineSegment ((1.1, 3.6), (9.2, 6.4)))), true, "error")
    [<Test>]
    member x.Test15() = 
        Assert.AreEqual((compare (interset (Line (0.0651663, 5.80047)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Point (9.2, 6.4))), true, "error")
    [<Test>]
    member x.Test16() = 
        Assert.AreEqual((compare (interset (Line (3.0, 4.0)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Empty)), true, "error")
    [<Test>]
    member x.Test17() = 
        Assert.AreEqual((compare (interset (VertLine (3.0)) (VertLine (3.0))), (VertLine (3.0))), true, "error")
    [<Test>]
    member x.Test18() = 
        Assert.AreEqual((compare (interset (VertLine (3.0)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Point (3.0, 3.65679))), true, "error")
    [<Test>]
    member x.Test19() = 
        Assert.AreEqual((compare (interset (VertLine (1.0)) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Empty)), true, "error")
    [<Test>]
    member x.Test20() = 
        Assert.AreEqual((compare (interset (LineSegment ((1.1, 3.6), (9.2, 6.4))) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (LineSegment ((1.1, 3.6), (9.2, 6.4)))), true, "error")
    [<Test>]
    member x.Test21() = 
        Assert.AreEqual((compare (interset (LineSegment ((-1.0, 1.0), (1.0, 7.0))) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Empty)), true, "error")
    [<Test>]
    member x.Test22() = 
        Assert.AreEqual((compare (interset (LineSegment ((0.0, 3.21975), (9.2, 6.4))) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (LineSegment ((1.1, 3.6), (9.2, 6.4)))), true, "error")
    [<Test>]
    member x.Test23() = 
        Assert.AreEqual((compare (interset (LineSegment ((0.0, 5.80047), (9.2, 6.452133))) (LineSegment ((1.1, 3.6), (9.2, 6.4)))), (Point (9.2, 6.4))), true, "error")

