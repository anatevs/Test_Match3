namespace GameManagement
{
    public interface IGameListener
    {
    }

    public interface IStartGameListener : IGameListener
    {
        public void StartGame();
    }

    public interface IPlayGameListener : IGameListener
    {
        public void PlayGame();
    }

    public interface IWinGameListener : IGameListener
    {
        public void WinGame();
    }

    public interface ILoseGameListener : IGameListener
    {
        public void LoseGame();
    }
}