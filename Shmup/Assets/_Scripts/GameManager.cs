public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }
    public int lifes;
    public int score;
    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager()
    {
        lifes = 10;
        score = 0;
        gameState = GameState.GAME;
    }

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        lifes = 10;
        score = 0;
    }
}