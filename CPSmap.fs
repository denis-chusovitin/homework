//Chusovotin Denis Copyrigths (c) 2014
//Map function in CPS style


let func x g = g (x + 1)

let rec map l f h = 
   match l with
   | [] -> h []
   | hd :: tl -> f hd (fun x -> map tl f (fun y -> h (x :: y)))

let l = [1..10]

map l func (printfn "%A")