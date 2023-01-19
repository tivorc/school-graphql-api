using GraphQL.Types;

namespace School.GraphQL;

public class SchoolSchema : Schema
{
  public SchoolSchema(IServiceProvider serviceProvider) : base(serviceProvider)
  {
    Query = serviceProvider.GetRequiredService<Queries>();
    Mutation = serviceProvider.GetRequiredService<ApiMutations>();
  }
}
