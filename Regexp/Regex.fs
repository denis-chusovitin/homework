//Chusovitin Denis (c) 2014
//Checking email addresses

module Regex

open System.Text.RegularExpressions

let regexp s  = Regex("[_a-zA-Z]+(\.\w+)*@([a-zA-Z]+\.)+([a-zA-Z]{2,4}|museum|travel)$").Replace(s, "") = ""

