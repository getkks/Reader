namespace Reader

open System
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Elmish
open Avalonia.FuncUI.Elmish
open Avalonia.FuncUI.Hosts

type HostApplication() =
    inherit Application()

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            this.RequestedThemeVariant <- Styling.ThemeVariant.Light
            Themes.Fluent.FluentTheme() |> this.Styles.Add
            // null |> MaterialIconStyles |> this.Styles.Add
            let mainWindow = Window()
            desktopLifetime.MainWindow <- mainWindow
        | _ -> ()