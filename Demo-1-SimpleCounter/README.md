# Blazor WASM & Server - Counter Example

This is the canonical demo for Blazor - a counter that gets incremented when you click a button.

There are 2 projects in this solution.

## BlazorCounterDemo.WASM

Similar to a SPA, Blazor WASM runs in your browser. 

You can scaffold an application with the following CLI command.

```sh
dotnet new blazorwasm -o BlazorCounterDemo.WASM
```

## BlazorCounterDemo.Server

You can scaffold an application with the following CLI command.

```sh
dotnet new blazorserver -o BlazorCounterDemo.WASM
```

## Key files

In both projects you will come across the following file structure.

- `Program.cs` is the entry point for the app that starts the server.
- `Startup.cs` is where you configure the app services and middleware.
- `App.razor` is the root component for the app.
- The `BlazorApp/Pages` directory contains some example web pages for the app.
- `BlazorApp.csproj` defines the app project and its dependencies.