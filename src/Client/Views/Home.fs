module Views

open Fable.Helpers.React
open Fulma

open Models
open Events
open UI

let home (model : Model) (dispatch : Msg -> unit) =
    div []
        [ Navbar.navbar [ Navbar.Color IsLight ]
            [ Navbar.Item.div [ ]
                [ Heading.h2 [ ]
                    [ str "SimpleBookz" ] ] ]

          Container.container []
              [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                    [ Heading.h3 [] [ str ("Push buttons to manipulate counter: " + show model) ] ]
                Columns.columns []
                    [ Column.column [] [ button "decrement" (fun _ -> dispatch Decrement) ]
                      Column.column [] [ button "increment" (fun _ -> dispatch Increment) ] ] ]

          Footer.footer [ ]
                [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                    []  ] ]