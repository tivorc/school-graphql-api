using GraphQL.Types;
using School.Models;

namespace School.GraphQL;

public class PaginationType<T, TT> : ObjectGraphType<Pagination<T>> where TT : IGraphType
{
  public PaginationType()
  {
    Name = $"{typeof(TT).Name}List";
    Field(x => x.Total).Name("totalItems");
    Field<BooleanGraphType>("next")
      .Resolve(context => context.Source.Next);
    Field<BooleanGraphType>("back")
      .Resolve(context => context.Source.Back);
    Field<IntGraphType>("currentPage")
      .Resolve(context => context.Source.CurrentPage);
    Field<IntGraphType>("totalPages")
      .Resolve(context => context.Source.TotalPages);
    Field<ListGraphType<TT>>("list")
      .Resolve(context => context.Source.List);
  }
}
