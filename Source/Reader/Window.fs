namespace Reader

open System
open System.IO
open System.Diagnostics
open System.Runtime.CompilerServices

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Controls.Presenters
open Avalonia.Controls.Primitives
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Platform
open Avalonia.Threading

// open Material.Icons.Avalonia

open Elmish
open Avalonia.FuncUI.DSL
open Avalonia.FuncUI.Elmish
open Avalonia.FuncUI.Elmish.ElmishHook
open Avalonia.FuncUI.Hosts
open Avalonia.FuncUI.Types

// open Material.Icons
// open Material.Icons.Avalonia

open System.Collections.ObjectModel
open FsToolkit.ErrorHandling

type Message = | Started

type State = { Text: string }

module Window =
    let init() = { Text = "Reader" }, Cmd.ofMsg Started

    let update msg (state: State) =
        match msg with
        | Started -> state, Cmd.none

    let view (state: State) dispatch =
        TextBlock.create [ TextBlock.text state.Text ]

type Window() as this =
    inherit HostWindow()

    do
        base.Title <- "Reader"
        base.CanResize <- true
        base.Width <- 1980
        base.Height <- 1080

        Program.mkProgram Window.init Window.update Window.view
        |> Program.withHost this
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> Program.runWithAvaloniaSyncDispatch()

#if DEBUG
        base.AttachDevTools()
#endif