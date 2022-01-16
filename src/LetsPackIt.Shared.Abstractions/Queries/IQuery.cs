namespace LetsPackIt.Shared.Abstractions.Queries
{
    public interface IQuery
    {
    }
    
    public interface IQuery<TResult> : IQuery
    {
    }
}