using LightInject;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLightInject().ConfigureContainer<IServiceContainer>(c =>
{
    c.Register<Foo>();
    Console.WriteLine("");
});

//builder.Services.AddTransient<Foo>();
var app = builder.Build();
app.MapGet("/{number}", (Foo foo, int number) => $"Hello world {number}");
app.Run();



public class Foo
{

}