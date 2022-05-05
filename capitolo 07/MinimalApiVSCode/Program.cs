var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/random", () => {
  var numbers=Enumerable.Range(1,6).Select( i => Random.Shared.Next(1,90)).ToList();
  return numbers;
});

app.MapGet("/numbers/{n}", (int n) => {
  var numbers=Enumerable.Range(1,n).Select( i => Random.Shared.Next(1,90)).ToList();
  return numbers;
});

//app.Run();
app.Run("http://localhost:3000");
