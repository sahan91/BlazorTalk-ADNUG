# JsInterop Demos

## /index

This page demonstrates a couple of things that, while they aren't specific to JsInterop, play a very large role in developing client-centric applications - [CSS isolation](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation?view=aspnetcore-5.0) and [Hot Reload](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-3/#initial-net-hot-reload-support).

To run the demo, run the app with a watch:

```cmd
> dotnet watch run
```

When the program runs, you should see that hot reload has been enabled from the output in the console.

```
watch : Hot reload enabled.
```

To confirm that hot reload is working, make a change to the scoped style in Index.razor.css and save it. The page should refresh with its state intact.

## /js-demo

The demo example loads an ES6 module using Blazor code running on the server.

```csharp
selfReference = DotNetObjectReference.Create(this);
module = await JS.InvokeAsync<IJSObjectReference>(
    "import", "/js/demo.js");

await module.InvokeVoidAsync("enableSimple", "button", "click", selfReference);
```

When the module is loaded, a reference to the component is passed to the client.

The client uses the component reference to invoke a call to a `JsInvokable` callback method on the server

```js
componentInstance.invokeMethodAsync("HandleClick", num, reason);
```
