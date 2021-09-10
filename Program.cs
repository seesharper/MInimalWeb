// using LightInject;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Uncomment this line and it will not inject Foo anymore
// builder.Host.UseLightInject();

// Uncomment to see both routes work:
// var container = new Container(Rules.MicrosoftDependencyInjectionRules);
// container.Register<Bar>();
// builder.Host.UseServiceProviderFactory(new DryIocServiceProviderFactory(container));


builder.Services.AddTransient<Foo>();

var app = builder.Build();

app.MapGet("/", (Foo foo) => $"Hello world with `{foo}`");
app.MapGet("/bar", (Foo foo, Bar bar) => $"Hello world with `{foo}` and `{bar}`");

app.Run();

public class Foo
{
    public Foo(Bar bar = null) {}
}

public class Bar {}