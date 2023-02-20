namespace Models.Factories.Contracts.Generic
{
    public interface IFactory<out T>
    {
        T Create();
    }
}