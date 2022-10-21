using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private int _fps = 60;
    [SerializeField] private int _vSyncCount = 0;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public StartScreen StartScreen => _startScreen;
    public GameScreen GameScreen => _gameScreen;
    public PauseScreen PauseScreen => _pauseScreen;
    public GameOverScreen GameOverScreen => _gameOverScreen;

    private State _state;
    private EnvirontmentMover[] _environtmentMovers;
    private LevelGenerator _levelGenerator;
    private InputHandler _inputHandler;

    public LevelGenerator LevelGenerator => _levelGenerator;

    public InputHandler InputHandler => _inputHandler;
    public Player Player => _player;
    public BirdMover BirdMover => _birdMover;

    public void ResetEnvironmentMovers()
    {
        foreach (var mover in _environtmentMovers)
        {
            mover.Reset();
        }
    }

    public void SetGameState()
    {
        SetState(new GameState());
    }

    public void SetRestartState()
    {
        SetState(new RestartState());
    }

    public void SetPauseState()
    {
        SetState(new PauseState());
    }

    public void SetGameOverState()
    {
        SetState(new GameOverState());
    }

    private void SetState(State state)
    {
        _state = state;
        _state.Handle(this);
    }

    private void Awake()
    {
        Application.targetFrameRate = _fps;
        QualitySettings.vSyncCount = _vSyncCount;

        _startScreen = FindObjectOfType<StartScreen>();
        _gameScreen = FindObjectOfType<GameScreen>();
        _pauseScreen = FindObjectOfType<PauseScreen>();
        _gameOverScreen = FindObjectOfType<GameOverScreen>();

        _birdMover = FindObjectOfType<BirdMover>();
        _player = FindObjectOfType<Player>();
        _levelGenerator = FindObjectOfType<LevelGenerator>();
        _environtmentMovers = FindObjectsOfType<EnvirontmentMover>();
        _inputHandler = FindObjectOfType<InputHandler>();

        SetState(new GameState());
    }
}