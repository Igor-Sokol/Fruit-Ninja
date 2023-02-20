namespace GameSystems.ScoreStorageSystem
{
    public interface IScoreStorage
    {
        void SaveScore(int score);
        int LoadScore();
    }
}