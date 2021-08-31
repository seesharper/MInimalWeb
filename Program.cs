using LightInject;

var builder = WebApplication.CreateBuilder(args);

// Uncomment this line and it will not inject Foo anymore
//builder.Host.UseLightInject();

builder.Services.AddTransient<Foo>();
var app = builder.Build();
app.MapGet("/", (Foo foo) => $"Hello world {foo.GetType()}");
app.Run();



public class Foo
{

}