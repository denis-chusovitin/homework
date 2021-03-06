﻿//Chusovitin Denis Copyrights (c) 2014
//Web CPS

module Web

open WebR
open CPSmap

let count site =
    let rec count' (site: string) (pos: int) =
        let k = site.IndexOf("<img", pos)
        if k <> -1 then 1 + count' site (k + 1)
                   else 0 
    count' site 0
    
let rec getimg site =
    let rec getimg' (site: string) (pos: int) =
        let k = site.IndexOf("<img", pos)
        if k <> -1 then let strbeg = site.IndexOf("src=", k + 4)
                        let strend = site.IndexOf("\"", strbeg + 5)
                        let len = strend - strbeg
                        site.Substring(strbeg + 5, len) :: (getimg' site strend)
        else []
    if (count site) > 5 then getimg' site 0
    else []
    
let web list f = map list getUrl (fun x -> Seq.map (fun y -> getimg y) x |> Seq.distinct |> Seq.concat |> Seq.toList |> f)

web ["https://www.google.ru/"; "http://www.youtube.com/";"https://www.vk.com/"] (printfn "%A")
    
System.Console.ReadLine() |> ignore 
