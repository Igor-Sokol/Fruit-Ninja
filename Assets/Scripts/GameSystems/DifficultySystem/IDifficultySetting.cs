namespace GameSystems.DifficultySystem
{
    public interface IDifficultySetting
    {
        int FruitsInPack { get; }
        float PackInterval { get; }
        float FruitInterval { get; }
    }
}