//Chusovitin Denis Copyrights (c) 2014
//Sum of list elements

let list = [1;3;3;9] 

let rec sumElements l =
    match l with
        | [] -> 0
        | hd::tl -> hd + sumElements tl

let n = sumElements list


printfn "%A" (n)