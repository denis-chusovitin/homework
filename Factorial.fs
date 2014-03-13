//Chusovitin Denis Copyrights(c) 2014
//Sum digits of factorial

let n = 10

let fact n =
    let rec fact' n res =
        if n = 0 then res
        else fact' (n - 1) res*n
    fact' n 1
    
let sumDig n =
    let rec sumDig' n res = 
        if n < 10 then res + n
        else sumDig' (n/10) (res + (n % 10))
    sumDig' n 0

printfn "%A" (sumDig (fact n))