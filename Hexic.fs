//Chusovitin Denis (c) 2014
//Hexic game

open System

type Hexic =
    | Color of int
    | Border
    | Empty

let width = Convert.ToInt32(Console.ReadLine())
let height = Convert.ToInt32(Console.ReadLine())
let Rand = new Random(Convert.ToInt32(Console.ReadLine()))
let colors = 6
let mutable score = 0

let swap (a : Hexic byref) (b : Hexic byref) =
    let temp = a
    a <- b
    b <- temp

let frst (a, _, _, _, _, _, _) = a
let othr (_, a, b, c, d, e, f) = (a, b, c, d, e, f)

let maxEl list =
    let rec max' l acc =
        match l with
        | (hd :: tl) -> if frst hd > frst acc then max' tl hd
                        else max' tl acc
        | [] -> acc
    max' list (0, 0, 0, 0, 0, 0, 0)
       

let genLattice = 
    let l = Array2D.createBased -1 -1 (width + 2) (height + 2) Border
    for i in 0 .. width - 1 do
        for j in 0  .. height - 1 do
           l.[i, j] <- Color (Rand.Next(colors))
    l

let removal (l : Hexic [,]) =
    let mutable scr = 0
    let l' = Array2D.copy l 
    let rec count i j =
        let mutable sum = 1
        let count' i' j' =
            if (l.[i, j] = l.[i', j']) && (l'.[i', j'] <> Empty) then count i' j'
            else 0
        l'.[i, j] <- Empty
        sum <- sum + (count' i (j + 1)) + (count' i (j - 1)) + (count' (i - 1) j) + (count' (i + 1) j) 
        if i % 2 = 0 then sum <- sum + (count' (i - 1) (j - 1)) + (count' (i + 1) (j - 1))
        else sum <- sum + (count' (i - 1) (j + 1)) + (count' (i + 1) (j + 1))
        sum

    for i in 0 .. width - 1 do
        for j in 0 .. height - 2 do
            if (l.[i, j] = l.[i, j + 1]) && (l'.[i, j] <> Empty) then
                if ((i % 2 = 0) && ((l.[i, j] = l.[i - 1, j]) || (l.[i, j] = l.[i + 1, j]))) ||
                   ((i % 2 <> 0) && ((l.[i, j] = l.[i - 1, j + 1]) || (l.[i, j] = l.[i + 1, j + 1]))) then
                        scr <- scr + 3*int((2.0)**float((count i j) - 3))
    (l', scr)

let drop (l : Hexic [,]) = 
    for i in 0 .. width - 1 do
        let mutable k = 0
        for j in 0 .. height - 1 do
            if l.[i, j] <> Empty then 
                l.[i, k] <- l.[i, j]
                if k <> j then l.[i, j] <- Empty
                k <- k + 1
    l

let removeEmpty (l : Hexic [,]) = 
    for i in 0 .. width - 1 do
        let mutable j = height - 1
        while (l.[i, j] = Empty) && (j >= 0) do
            l.[i, j] <- Color (Rand.Next(colors))
            j <- j - 1
    l
    
let latticeMove (l : Hexic [,]) = 
    let rec lat' lat =
        let l' = removal <| Array2D.copy (fst lat)
        let newlat = removeEmpty (drop <| fst l')
        if fst lat <> newlat then lat' (newlat, (snd lat) + snd l')
        else lat
    lat' (l, 0)
     
let move (l : Hexic [,]) i1 j1 i2 j2 i3 j3 =
    if (l.[i1, j1] <> Border) && (l.[i2, j2] <> Border) && (l.[i3, j3] <> Border) then
        swap &l.[i1, j1] &l.[i2, j2]
        swap &l.[i2, j2] &l.[i3, j3]
    l

let countMove (lat : Hexic [,]) i j =  
    let mutable maxs = []
    let move' i1 j1 i2 j2 i3 j3 = 
        let l' = move (Array2D.copy lat) i1 j1 i2 j2 i3 j3
        (snd <| removal l', i1, j1, i2, j2, i3, j3)
    if j <> height then
        if i % 2 = 0 then 
            if i <> 0 then
                maxs <- (move' i j (i - 1) j i (j + 1)) :: maxs
                maxs <- (move' i j i (j + 1) (i - 1) j) :: maxs 

            if i <> width then 
                maxs <- (move' i j (i + 1) j i (j + 1)) :: maxs
                maxs <- (move' i j i (j + 1) (i + 1) j) :: maxs 
        else
            if i <> 0 then 
                maxs <- (move' i j (i - 1) (j + 1) i (j + 1)) :: maxs
                maxs <- (move' i j i (j + 1) (i - 1) (j + 1)) :: maxs
            if i <> 0 then 
                maxs <- (move' i j (i + 1) (j + 1) i (j + 1)) :: maxs
                maxs <- (move' i j i (j + 1) (i + 1) (j + 1)) :: maxs
    maxEl maxs
  
let profitMove (l : Hexic [,]) =
    let mutable max = (0, 0, 0, 0, 0, 0, 0)
    for i in 0 .. width - 1 do
        for j in 0 .. height - 1 do
            let mutable m = countMove l i j
            max <- if frst max > frst m then max
                   else m
    othr max

let game lattice =
    let rec game' lattice scr =
        match profitMove (lattice) with
        | (i1, j1, i2, j2, i3, j3) -> let lat = latticeMove <| move (Array2D.copy lattice) i1 j1 i2 j2 i3 j3
                                      if snd lat <> 0 then game' (fst lat) (scr + snd lat)
                                      else scr
    game' lattice 0

let lat = fst <| latticeMove genLattice
printfn "%A" (game lat)


