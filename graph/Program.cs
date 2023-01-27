using School.GraphQL;
using GraphQL;
using School.DB;
using School.Services;

var builder = WebApplication.CreateBuilder(args);

var server = builder.Configuration["Database:Server"];
var user = builder.Configuration["Database:User"];
var password = builder.Configuration["Database:Password"];
var database = builder.Configuration["Database:Name"];
builder.Services.AddSingleton(
  new MySqlConnectionManager(server, user, password, database)
);

builder.Services.AddSingleton<StudentService>();

builder.Services.AddGraphQL(b => b
  .AddSchema<SchoolSchema>()
  .AddSystemTextJson()
  .AddGraphTypes(typeof(SchoolSchema).Assembly)
);
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(builder =>
  {
    builder.WithOrigins("http://localhost:5173/")
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseGraphQLPlayground(
    "/",
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
      GraphQLEndPoint = "/api/graphql",
      SubscriptionsEndPoint = "/api/graphql"
    }
  );
}
app.UseCors();
app.UseGraphQL<SchoolSchema>("/api/graphql");
app.Run();
