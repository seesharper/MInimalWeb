// using LightInject;
using DryIoc.Microsoft.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Uncomment this line and it will not inject Foo anymore
//builder.Host.UseLightInject();

// Uncomment and trying to open the app link will result in the error:
// ```
// fail: Microsoft.AspNetCore.Server.Kestrel[13]
//       Connection id "0HMBCQ2M8Q5IF", Request id "0HMBCQ2M8Q5IF:00000001": An unhandled exception was thrown by the application.
//       System.InvalidOperationException: Unable to read the request as JSON because the request content type '' is not a known JSON content type.
//          at Microsoft.AspNetCore.Http.HttpRequestJsonExtensions.ReadFromJsonAsync(HttpRequest request, Type type, JsonSerializerOptions options, CancellationToken cancellationToken) in Microsoft.AspNetCore.Http.Extensions.dll:token 0x600004b+0x1f6
//          at Microsoft.AspNetCore.Http.RequestDelegateFactory.<>c__DisplayClass38_0.<<HandleRequestBodyAndCompileRequestDelegate>b__0>d.MoveNext() in Microsoft.AspNetCore.Http.Extensions.dll:token 0x6000194+0xd4
//       --- End of stack trace from previous location ---
//          at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger) in Microsoft.AspNetCore.Routing.dll:token 0x60000ab+0x5e
//          at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application) in Microsoft.AspNetCore.Server.Kestrel.Core.dll:token 0x6000ac9+0x1b8
// ```

//builder.Host.UseServiceProviderFactory(new DryIocServiceProviderFactory());

builder.Services.AddTransient<Foo>();

var app = builder.Build();
app.MapGet("/", (Foo foo) => $"Hello world {foo.GetType()}");
app.Run();

public class Foo
{

}