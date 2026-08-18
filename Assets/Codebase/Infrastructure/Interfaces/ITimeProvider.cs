namespace Infrastructure.Interfaces
{
    public interface ITimeProvider
    {
        float DeltaTime { get; }
    }
}