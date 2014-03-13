//Chusovitin Denis Copyrigths (c) 2014
//Filtr list with condition

let list = [6;8;1;0;3;8;5;3;7;2;7]
let n = 2

let rec filtr l f=
    match l with
    | hd::tl -> if (f hd) then hd::filtr tl f
                          else filtr tl f
    | []->[]

printfn "%A" (filtr list (fun x -> x>n))