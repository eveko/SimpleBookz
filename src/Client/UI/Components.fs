module UI

open Fable.Helpers.React
open Fulma


let button txt onClick =
    Button.button
        [ Button.IsFullWidth
          Button.Color IsLink
          Button.OnClick onClick ]
        [ str txt ]