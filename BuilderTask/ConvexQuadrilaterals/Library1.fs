module Convex

type Point = {X : int; Y : int} 

let isClockwise a b c = (b.X - a.X)*(c.Y - a.Y) - (b.Y - a.Y)*(c.X - a.X) < 0

let isNotOnLine a b c = (a.X - b.X)*(c.Y - b.Y) <> (a.Y - b.Y)*(c.X - b.X)

let private map' f (points: Point[]) = 
    [| for i in 0 .. 3 -> f points.[i] points.[(i + 1)%4] points.[(i + 2)%4] |]

let isQuadrilateral (points: Point[]) = 
    let p = map' isNotOnLine points
    let q = map' isClockwise points
    (not <| Seq.exists (fun x -> x = true) p) && (Seq.length (Seq.filter (fun x -> x = true) q) = 2)

let isConvex (points: Point[]) = 
    let p = map' isClockwise points
    not <| Seq.exists (fun x -> x <> p.[0]) p
