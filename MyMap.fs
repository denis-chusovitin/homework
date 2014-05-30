//Chusovitin Denis (c) 2014
//MAP

module MyMap

open System
open System.Collections
open System.Collections.Generic
open Microsoft.FSharp.Core

type Tree<'key, 'value> =
  | Fork of left: Tree<'key, 'value> * right: Tree<'key, 'value> * 'key  * 'value * lheight: int * rheight: int
  | Empty


let private getheight tree =
    match tree with
    | Fork(_, _, _ ,_ , hl, hr) -> max hl hr
    | Empty -> 0 

let rec search tree key =
    match tree with
    | Fork(l, r, k, v, hl, hr) -> if key = k || (key < k && hl = 0) || (key > k && hr = 0) then Fork(l, r, k, v, hl, hr) 
                                  else if key < k then search l key 
                                       else search r key
                                           
    | Empty -> Empty
    
let rec private balance tree =
    match tree with
    | Fork(l1, r1, k1, v1, hl1, hr1) -> match hl1 - hr1 with
                                        | 2 -> match l1 with
                                               | Fork(l2, r2, k2, v2, hl2, hr2) -> if hl2 > hr2 then Fork(l2, Fork(r2, r1, k1, v1, hr2, hr1), k2, v2, hl2, max hr2 hr1) 
                                                                                   else match r2 with
                                                                                        | Fork(l3, r3, _, _, hl3, hr3) -> Fork(l1, Fork(r3, r1, k1, v1, hr3, hr1), k2, v2, max hl2 hl3, max hr3 hr1)
                                                                                        | _ -> failwith "Error"  
                                               | _ -> failwith "Error"  
                                        | -2 -> match r1 with
                                                | Fork(l2, r2, k2, v2, hl2, hr2) -> if hr2 > hl2 then Fork(Fork(l1, l2, k1, v1, hl1, hl2), r2, k2, v2, max hl1 hl2, hr2) 
                                                                                    else match l2 with
                                                                                         | Fork(l3, r3, _, _, hl3, hr3) -> Fork(Fork(l1, l3, k1, v1, hl1, hr3), r1, k2, v2, max hl1 hl3, max hr3 hr2)
                                                                                         | _ -> failwith "Error"  
                                                | _ -> failwith "Error"  
                                        | _ -> failwith "Error"
    | Empty -> Empty

let rec private getleaf tree =
    match tree with
    | Fork(l, r, k, v, hl, hr) -> if hl = 0 then (k, v)
                                  else getleaf l
    | Empty -> failwith "Error"

let rec private removeleaf tree =
    match tree with
    | Fork(l, r, k, v, hl, hr) -> if hl = 0 then r
                                  else Fork(removeleaf l, r, k, v, getheight l, getheight r)
    | Empty -> failwith "Error"

let rec add tree key value = 
           match tree with
           | Fork(l, r, k, v, hl, hr) -> if key < k then if hl = 0 then Fork(Fork(Empty, Empty, key, value, 0, 0), r, k, v, 1, hr) 
                                                         else let t = add l key value
                                                              let t' = Fork(t, r, k, v, getheight t, hr)
                                                              if abs(getheight t - hr) = 2 then balance t'
                                                              else t'
                                         else if hr = 0 then Fork(l, Fork(Empty, Empty, key, value, 0, 0), k, v, hl, 1) 
                                                        else let t = add r key value
                                                             let t' = Fork(l, t, k, v, hl, getheight t)
                                                             if abs(getheight t - hl) = 2 then balance t'
                                                             else t'
           | Empty -> Fork(Empty, Empty, key, value, 0, 0)
       

let private getEnumerator(tree) =
    let rec getList tree =
        match tree with
        | Empty -> []
        | Fork(l, r, k, v, _, _) -> getList l @ ((k, v) :: getList r)
    let list = getList tree
    let refList = ref list
    let isStart = ref true
    let curr() = if !isStart then failwith("Not found")
                 else (!refList).Head
    {
        new IEnumerator<'key * 'value> with
            member this.Current = curr()

        interface IEnumerator with
            member this.Current = curr() :> obj
            member this.MoveNext() = if !isStart then isStart := false
                                     refList := (!refList).Tail
                                     not (!refList).IsEmpty
            member this.Reset() = isStart := true
                                  refList := list

        interface System.IDisposable with
            member this.Dispose() = ()
    }



type Mymap<'key, 'value  when 'key: comparison and 'value: equality>private(tree:Tree<'key, 'value>) =
   class 

   member this.TryFind key =    
       let t = search tree key
       match t with
       | Fork(_, _, k, v, _, _) -> if k = key then Some v
                                   else None
       | Empty -> None
    
   member this.IsEmpty =
       match tree with
       | Fork(_, _, _, _, _, _) -> false
       | _ -> true

   member this.Count =
       let rec count' tree  =
           match tree with
           | Fork(l, r, _, _, _, _) -> 1 + (count' l) + (count' r)
           | Empty -> 0
       count' tree

   member this.ContainsKey key =  
       let t = search tree key
       match t with
       | Fork(_, _, k, _, _, _) -> k = key
       | Empty -> false 
       

   member this.Item key =    
       let t = search tree key
       match t with
       | Fork(_, _, k, v, _, _) -> if k = key then v
                                   else failwith "Error"
       | Empty -> failwith "Error"

   member this.Add (key, value) = new Mymap<_, _>(add tree key value)

   member this.Remove key =
       let rec remove tree key =
           match tree with
           | Fork(l, r, k, v, hl, hr) -> if key < k then let t = remove l key 
                                                         let t' = Fork(t, r, k, v, getheight t, hr)
                                                         if abs(getheight t - hr) = 2 then balance t'
                                                         else t'
                                         else if key > k then let t = remove r key 
                                                              let t' = Fork(l, t, k, v, hl, getheight t) 
                                                              if abs(getheight t - hl) = 2 then balance t'
                                                              else t' 
                                              else if (hl = hr) && (hl = 0) then Empty
                                                   else if hr > 0 then let (k1 ,v1) =  getleaf r
                                                                       let t = removeleaf r
                                                                       Fork(l, t, k1, v1, getheight l , getheight t)
                                                        else l                          
           | Empty -> failwith "Error"

       new Mymap<_,_>(remove tree key)

   member private this.GetEnumerator() = getEnumerator(tree)
   interface IEnumerable<'key * 'value> with
       member this.GetEnumerator() = this.GetEnumerator()
   interface IEnumerable with
       member this.GetEnumerator() = this.GetEnumerator() :> IEnumerator
           
   override this.ToString() =
       let rec string tree =
           match tree with
           | Fork(l, r, k, v, _, _) -> "Fork(" + string l + ", " + string r + ", " + k.ToString() + ", " + v.ToString() + ")"
           | Empty -> "Empty"
       string tree

   override this.GetHashCode() =
        let rec hash tree =
            match tree with
            | Fork(l, r, k, v, _, _) -> k.GetHashCode() * v.GetHashCode() * (hash l) * (hash r) % Int32.MaxValue
            | Empty -> 1
        hash tree

   override this.Equals x = 
        match x with 
        | :? Mymap<'key, 'value> as map -> this.Count = map.Count && Seq.forall2 (=) this map
        | _ -> false

   new(x: seq<'key * 'value>) = 
       let t = ref Tree.Empty
       let add' list = 
           List.fold (fun acc (a, b) -> t := add (!t) a b
                                        (!t)
                      ) (!t) list
       Mymap<_,_>(add' (Seq.toList x))

   end


