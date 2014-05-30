//Chusovitin Denis Copyrights (c) 2014
//Web CPS

module Web

open WebR

let cmp k v img = if k = img then (k, v + 1)
                  else (k, v)

let findImg site =
    let rec findImg' (site: string) list =
        let k = site.IndexOf("<img")
        if k <> -1 then let strbeg = k + 11
                        let strend = site.IndexOf("\"")
                        let img = site.Substring(strbeg, strend - strbeg) 
                        if List.exists (fun (k, v) -> k = img) list then findImg' (site.Remove(0, strend)) (List.map (fun (k, v) -> cmp k v img) list)                                                                                                           
                        else findImg' (site.Remove(0, strend)) ((img, 1) :: list) 
        else []
    findImg' site []

let rec print list =
    if List.length list > 5 then match list with 
                                 | [] -> ()
                                 | (k, v) :: tl -> if v = 1 then printfn "%A\n" k
                                                   print tl
let printimg site = print (findImg site)

let rec web sitelist f =
    match sitelist with
    | [] -> ()
    | hd :: tl -> getUrl hd f 
                  web tl f
                  

web ["https://vk.com"; "https://github.com"; "https://google.com"] printimg
    
System.Console.ReadLine() |> ignore
