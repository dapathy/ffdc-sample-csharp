# Welcome

This sample client application is an implementation of the OAuth2 Authorization Code authorization grant for FusionFabric.cloud.

**To run this sample**
> You need a recent installation of .NET SDK. To find out more about it, and how to install .NET SDK, follow the [.NET Tutorial](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) for your operating system.

1. Register an application on [**Fusion**Fabric.cloud Developer Portal](https://developer.fusionfabric.cloud), and include the **Forex Spot for Trade Capture** API. Use `https://localhost:44307/login/oauth2/code/finastra` as the reply URL.
2. Clone the current project.
3. Copy `src/appsettings.json.sample` to `src/appsettings.json`, open it, and enter `<%YOUR-CLIENT-ID%>`, and `<%YOUR-SECRET-KEY%>` of the application created at the step 1.  

> The `accessTokenEndpoint` and `authorizationEndpoint` are the access token and authorization endpoints provided by the [Discovery service](https://developer.fusionfabric.cloud/documentation?workspace=FusionCreator%20Developer%20Portal&board=Home&uri=oauth2-grants.html#discovery-service) of the **Fusion**Fabric.cloud Developer Portal.

4. Open a Command Prompt or a Terminal in this directory and run the application with `dotnet run -p src\ffdc-authorization-code.csproj`. The application has started running. 
5. Point your browser to https://localhost:44307, and click **Signin**. You are redirected to the **Fusion**Fabric.cloud Developer Portal Authorization Server.
6. Log in with one of the following credentials:

| User        | Password |
| :---------- | :------- |
| `ffdcuser1` | `123456` |
| `ffdcuser2` | `123456` |

The home page of this sample application is displayed.

7. (Optional) Click **List Fores Spot Trades** in the home page to get the list of the Forex Spot trades, from the **Forex Spot for Trade Capture** API.