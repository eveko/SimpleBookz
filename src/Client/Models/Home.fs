module Models

open Shared

type Model = { Counter: Counter option }

let show = function
| { Counter = Some counter } -> string counter.Value
| { Counter = None   } -> "Loading..."

type AppModel = { Groups: Group list option }

let showApp = function
| { Groups = Some group } ->  "Your financial info"
| { Groups = None } -> "Loading..."