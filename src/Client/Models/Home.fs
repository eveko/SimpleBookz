module Models

open Shared

type Model = { Counter: Counter option }

let show = function
| { Counter = Some counter } -> string counter.Value
| { Counter = None   } -> "Loading..."