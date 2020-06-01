# blazor-intro

![](blazor-webassembly.png)

_[image source](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.1)_

This project has the samples I reference in my LogRocket post on Blazor.

- AzureFunctions
	- Has the Azure Functions that run locally with the "BlazorWebAssembly" project
- BlazorServer
	- Has a Blazor Server implmentation
- BlazorWebAssembly
	- Has a Blazor WebAssembly implementation

All of the three project have corresponding solution `.sln` files in their corresponding folders. Open these up in Visual Studio to run them locally.

If you want to run the BlazorWebAssembly project, you'll need to run the AzureFunctions locally in a different session. The BlazorWebAssembly project uses the AzureFunctions project as a backend for HTTP calls.

In addition to these examples, I recommend checking out [Microsoft's Getting Started Page](https://docs.microsoft.com/en-us/aspnet/core/blazor/get-started?view=aspnetcore-3.1&tabs=visual-studio).

If you have any questions, please feel free to contact me using one of the resources at [andrewevans.dev](https://www.andrewevans.dev).