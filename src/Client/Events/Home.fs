module Events

open Elmish
open Elmish.React

open Fable.Import

open Shared
open Models
open Shared


type Msg =
| Increment
| Decrement
| InitialCountLoaded of Result<Counter, exn>

let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
    match currentModel.Counter, msg with
    | Some counter, Increment ->
        let nextModel = { currentModel with Counter = Some { Value = counter.Value + 1 } }
        nextModel, Cmd.none
    | Some counter, Decrement ->
        let nextModel = { currentModel with Counter = Some { Value = counter.Value - 1 } }
        nextModel, Cmd.none
    | _, InitialCountLoaded (Ok initialCount)->
        let nextModel = { Counter = Some initialCount }
        nextModel, Cmd.none

    | _ -> currentModel, Cmd.none

type GroupEvent =
  | NewGroup of Group
  | DeleteGroup of int
  | RenameGroup of int*string

type EntryEvent =
  | NewEntry
  | UpdateEntry
  | RemoveEntry

let updateGroup (event : GroupEvent) (current : AppModel) : AppModel * Cmd<GroupEvent> =
  match current.Groups, event with
  | Some groups, NewGroup newGroup ->
      let next = { current with Groups = Some  (groups @ [newGroup]) }
      next, Cmd.none
  | Some groups , RenameGroup(id , newname) ->
      let renameGroup g =
        if g.Id =  id then { g with Description = newname } else g
      { current with Groups = Some (List.map renameGroup groups) }, []
  | Some groups , DeleteGroup id ->
    { current with Groups = Some (List.filter (fun g -> g.Id <> id) groups) }, []
  | _ -> current, Cmd.none


