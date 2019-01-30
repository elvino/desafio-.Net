namespace Domain.Shared.Contracts
{
    public partial interface IResult{}

    public interface IHandler<in T> where T : class
    {
        object Handle(T command);
    }
}
