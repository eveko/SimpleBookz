namespace Shared
open System.Text.RegularExpressions
open System

type Counter = { Value : int }

type Entry = {
  Id : int
  Amount : decimal
  Group : int
  Date : DateTime
}

type Group = {
  Id : int
  Description : string
  Target : decimal
  Entries : Entry list
  Subgroups : Group list
}

