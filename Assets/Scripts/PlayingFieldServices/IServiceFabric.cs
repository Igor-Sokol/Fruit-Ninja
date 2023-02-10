namespace PlayingFieldServices
{
    public interface IServiceFabric
    {
        IPlayingFieldService Create();
    }
}