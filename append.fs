//Chusovitin Denis Copyrights (c) 2013
//Add element to end of list


let list = [5;9;3;6]
let n = 100

let rec add l n =
    match l with
        | []->n::l
        | hd::tl->hd::add tl n

let newlist = add list n


