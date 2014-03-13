//Chusovitin Denis Copyrights (c) 2013
//Concatenate lists

let list1 = [3;6;9]
let list2 = [2;0]

let rec conc l1 l2 =
    match l1 with
        | []-> l2
        | hd::tl-> hd::conc tl l2

let newlist = conc list1 list2



