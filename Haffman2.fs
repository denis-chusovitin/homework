module Huffman

open System

type CodeTree = 
  | Fork of left: CodeTree * right: CodeTree * chars: char list * weight: int
  | Leaf of char: char * weight: int

let rec ifElemInList list value = 
    match list with
    | [] -> false
    | hd :: tl -> if (hd = value) then true
                  else ifElemInList tl value

// code tree

let createCodeTree (chars: char list) : CodeTree = 
    failwith "Not i"

// decode

type Bit = int

let decode (tree: CodeTree)  (bits: Bit list) : char list = 
    let rec decode' (tree: CodeTree)  (bits: Bit list) : char list = 
        match bits with
        | [] -> []
        | x :: tl -> if x = 0 then match tree with
                                   | Fork(left, _, _, _) -> decode' left tl
                                   | Leaf(char, _) -> [char]
                     else match tree with
                          | Fork(_, right, _, _) -> decode' right tl
                          | Leaf(char, _) -> [char]
    decode' tree bits
// encode
   

let encode (tree: CodeTree)  (text: char list) : Bit list = 
    let rec encodeChar (tree: CodeTree) (symb: char) : Bit list =
        match tree with
        | Fork(left, right, _, _) -> match left with
                                         | Fork(_, _, chars, _) -> if ifElemInList chars symb then 0 :: encodeChar left symb
                                                                   else 1 :: encodeChar right symb
                                         | Leaf(char, _) -> if char = symb then [0]
                                                            else []
        | _ -> []
    let rec encode' (tree: CodeTree)  (text: char list) : Bit list = 
        match text with
        | [] -> []
        | hd :: tl -> encodeChar tree hd @ encode' tree tl
    encode' tree text

open System

let weight (tree:CodeTree) =
    match tree with
    | Fork(_,_,_,weight) -> weight
    | Leaf(_,weight) -> weight

let chars (tree:CodeTree) =
    match tree with
    | Fork(_,_,chars,_) -> chars
    | Leaf(char,_) -> [char]

let makeCodeTree left right = Fork(left, right, chars left @ chars right, weight left + weight right)

let string2chars str = Seq.toList str

let times (list:char list) : (char * int) list = 
    let newlist = List.sort list
    
    let rec times' list list1 ch v =
        match list with 
        | [] -> (ch, v) :: list1
        | hd :: tl -> if hd = ch then times' tl list1 ch (v+1)
                      else times' tl ((ch, v) :: list1) hd 1

    times' newlist.Tail [] newlist.Head 1

let makeOrderedLeafList list = 
    let newlist = List.sortBy (fun (k,v) -> v) list

    let rec make list =
        match list with
        | [] -> []
        | (k,v) :: tl -> Leaf(k,v) :: (make tl)

    make newlist

let singltone (list : CodeTree list) : bool = List.length list = 1

let rec combine (list: CodeTree list) : CodeTree list =
    if not (singltone list) then
        match list with
        | x :: y :: tl ->
            let un = Fork (x, y, (chars x) @ (chars y), weight x + weight y) :: tl
            combine (List.sortBy (function | Fork (_, _, _, x) -> x | Leaf (_, x) -> x) un)
        | _ -> failwith "Error"
    else list
