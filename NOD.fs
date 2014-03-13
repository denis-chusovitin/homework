//Chusovitin Denis Copyrights (c) 2014
//Max prime numbers divider of number

let n = 4444444

let firstDiv k =
    let rec firstDiv' k i =
        if i <= int(sqrt(float(k))) then
            if k % i = 0 then i
            else firstDiv' k (i + 1)
        else k
    firstDiv' k 2

let rec maxDiv n =
    if n = firstDiv n then n
    else maxDiv (n/(firstDiv n))

printfn "%A" (maxDiv n) 
    
