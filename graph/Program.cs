using School.GraphQL;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(b => b
  .AddSchema<SchoolSchema>()
  .AddSystemTextJson()
  .AddGraphTypes(typeof(SchoolSchema).Assembly)
);
builder.Services.AddHttpContextAccessor();

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
app.UseGraphQL<SchoolSchema>("/api/graphql");
app.UseHttpsRedirection();
app.Run();
