# Third Party Component Support

This is a Blazor WASM application to showcase the third-party plugin support in Blazor. There are 2 components in this project.

## /Home

The home page is used to host the Markdown component located in the `Components/MarkdownComponent.razor`. We have utilise the popular .NET library [Markdig](https://github.com/xoofx/markdig).

You can download this package via NuGet with the following CLI command.

```sh
dotnet add package Markdig
```

The markup for this component only has a `textarea` to capture the user input and a `<p>` area to render the preview.

```html
Markdown Content
<textarea class="form-control h-100" @bind-value="Body" @bind-value:event="oninput"></textarea>

Preview
<p>@((MarkupString) Preview)</p>
```

Notice how the `@bind-value` and `@bind-value:event` is setup. Since we need to update our state as the user enters something, we need to specifically mention that we need to bind to the "oninput" event. If you only use the `@bind-value`, Blazor will default to `onchange` event which get triggered when you move away (pressing tab or clicking on another HTML component) from the text area.

C# code that handles this is pretty simple. We keep string called `Body` to keep track of that the user is typing and a string called `Preview` to convert the text to markdown.

```csharp
public string Body { get; set; } = "";
public string Preview => Markdown.ToHtml(Body);
```

## /Autocomplete

In the autocomplete demo, we utilise the [Blazored.Typeahead](https://github.com/Blazored/Typeahead) component by [Chris Sainty](https://github.com/chrissainty). This is a more advanced demo as it utilises Javascript under the hood.

You can add this package with the following CLI command.

```sh
dotnet add package Blazored.Typeahead
```

As for the markup we define `BlazoredTypeahead` component by providing a callback method to get triggered when we search, a variable to represent current selection and two templates to define how the selection/result should be rendered.

```csharp
<BlazoredTypeahead SearchMethod="SearchCars" @bind-Value="_selectedCar">
    <SelectedTemplate>
        @context.Title
    </SelectedTemplate>
    <ResultTemplate>
        @context.Title (@context.Year)
    </ResultTemplate>
</BlazoredTypeahead>
```

In the C# code we use two variables - list of Cars and the current selection. In addition, we also provide a method called `SearchCars` which gets triggered when we type something in. 

```csharp
private List<Car> _cars;
private Car _selectedCar;

private async Task<IEnumerable<Car>> SearchCars(string searchText) => {...}
```