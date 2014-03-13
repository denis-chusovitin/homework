//Chusovitin Denis Copyrigths (c) 2013
//Print first squares not exceeding n

let n = 5546

let rec squares n j =
    if (j*j < n) then (j*j)::squares n (j+1)
                 else []

printfn "%A" (squares n 1)

