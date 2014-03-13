//Chusovitin Denis Copyrigths (c) 2014
//Sum of n odd fibonacci numbers

let n = 4000000

let sumFib n =
    let rec sumFib' n x y res =
        if ((x + y) < n) then
           if (x + y)% 2 = 0 then sumFib' n y (x + y) (res + x + y)
           else sumFib' n y (x + y) res
        else res
    sumFib' n 1 1 0

printfn "%A" (sumFib n)