//Chusovitin Denis Copyrigths (c) 2014
//Interection of set of points

module PointSets

let eps = 0.0001

let (==) a b = abs(a - b) < eps


type set =
    | Point of float*float
    | Line of float*float
    | VertLine of float
    | LineSegment of (float*float)*(float*float)
    | Empty


let intersetPointPoint (a, b) (c, d) = 
    if (a = c) && (b = d) then Point (a, b)
    else Empty

let intersetPointLine (a, b) (c, d) =
    if a*c + d == b then Point (a, b)
    else Empty

let intersetPointVertLine (a, b) c =
    if a = c then Point (a, b)
    else Empty

let intersetPointLineSegment (a, b) (c, d) (e, f) = 
    if (abs(c - a) + abs(e - a) == abs(c - e)) && (abs(d - b) + abs(f - b) == abs(d - f)) then 
        if c = e then intersetPointVertLine (a, b) c
        else intersetPointLine (a, b) ((f - d)/(e - c), c*(d - f)/(e - c) + d)
    else Empty


let intersetLineLine (a, b) (c, d) =
    if a == c then 
        if b == d then Line (a, b)
        else Empty
    else Point ((d - b)/(a - c), (b*c - d*a)/(c - a))

let intersetLineVertLine (a, b) c =
    Point (c, a*c + b)

let intersetLineLineSegment (a, b) (c, d) (e, f) =
    match intersetLineLine (a, b) ((f - d)/(e - c), (c*(d - f)/(e - c) + d)) with
    | Line _ -> LineSegment ((c, d), (e, f))
    | Point (x, y) -> intersetPointLineSegment (x, y) (c, d) (e, f)
    | _ -> Empty



let intersetVertLineVertLine a c =
    if a = c then VertLine a
    else Empty

let intersetVertLineLineSegment a (c, d) (e, f) =
    if (a = c) && (a = e) then VertLine a
    else 
        if abs(c - a) + abs(e - a) == abs(c - e) then Point (a, (a - c)*(f - d)/(e - c) + d)
        else Empty



let intersetLineSegmentLineSegment (m, n) (k, l) (c, d) (e, f) =
    let a' = k - m
    let b' = c - e
    let c' = c - m
    let d' = l - n
    let e' = d - f
    let f' = d - n

    if a'*e' == b'*d' then 
        if a'*f' == c'*d' then
            let p1 =  intersetPointLineSegment (k, l) (c, d) (e, f)
            let p2 = intersetPointLineSegment (m, n) (c, d) (e, f)
            let p3 = intersetPointLineSegment (e, f) (m, n) (k, l)
            let p4 =  intersetPointLineSegment (c, d) (m, n) (k, l)

            match (p1, p3) with
            | (Point (x1, y1), Point (x2, y2)) -> LineSegment ((x1, y1), (x2, y2))
            | (Point (x1, y1), Empty) -> match (p2, p4) with
                                         | (_, Point (x2, y2)) | (Point (x2, y2), _) -> LineSegment ((x1, y1), (x2, y2))
                                         | _ -> Empty
            | (Empty, Point(x2, y2)) -> match (p2, p4) with
                                         | (Point (x1, y1), _) | (_, Point (x1, y1))  -> LineSegment ((x1, y1), (x2, y2))
                                         | _ -> Empty 
            | (Empty, Empty) -> match (p2, p4) with
                                | (Point (x1, y1), Point (x2, y2)) -> LineSegment ((x1, y1), (x2, y2))
                                | _ -> Empty
            | _ -> Empty
        else Empty
    else 
        let t1 = (c'*e' - b'*f') / (a'*e' - b'*d')
        let t2 = (a'*f' - c'*d') / (a'*e' - b'*d')

        if (t1 >= 0.0) && (t1 <= 1.0) && (t2 >= 0.0) && (t2 <= 1.0) then Point(m + t1*a', n + t1*d')
        else Empty


let interset set1 set2 =
    match set1 with
    | Point (a, b) ->
        match set2 with
        | Point (c, d) -> intersetPointPoint (a, b) (c, d)
        | Line (c, d) -> intersetPointLine (a, b) (c, d)
        | VertLine c -> intersetPointVertLine (a, b) c
        | LineSegment ((c, d), (e, f)) -> intersetPointLineSegment (a, b) (c, d) (e, f)
        | Empty -> Empty
    | Line (a, b) ->
        match set2 with
        | Point (c, d) -> intersetPointLine (c, d) (a, b)
        | Line (c, d) -> intersetLineLine (a, b) (c, d)
        | VertLine c -> intersetLineVertLine (a, b) c
        | LineSegment ((c, d), (e, f)) -> intersetLineLineSegment (a, b) (c, d) (e, f)
        | Empty -> Empty
    | VertLine a ->
        match set2 with
        | Point (c, d) -> intersetPointVertLine (c, d) a
        | Line (c, d) -> intersetLineVertLine (c, d) a
        | VertLine c -> intersetVertLineVertLine a c
        | LineSegment ((c, d), (e, f)) -> intersetVertLineLineSegment a (c, d) (e, f)
        | Empty -> Empty
    | LineSegment ((c, d), (e, f)) ->
        match set2 with
        | Point (a, b) -> intersetPointLineSegment (a, b) (c, d) (e, f)
        | Line (a, b) -> intersetLineLineSegment (a, b) (c, d) (e, f)
        | VertLine a -> intersetVertLineLineSegment a (c, d) (e, f)
        | LineSegment ((m, n), (k, l)) -> intersetLineSegmentLineSegment (m, n) (k, l) (c, d) (e, f)
        | Empty -> Empty
    | Empty -> Empty


