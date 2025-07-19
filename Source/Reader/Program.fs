open Avalonia
open Reader

[<CompiledName "BuildAvaloniaApp">]
let buildAvaloniaApp() =
    AppBuilder.Configure<HostApplication>().UsePlatformDetect().WithInterFont().UseSkia().LogToTrace(areas = Array.empty)

[<EntryPoint>]
let main args =
    buildAvaloniaApp().StartWithClassicDesktopLifetime args