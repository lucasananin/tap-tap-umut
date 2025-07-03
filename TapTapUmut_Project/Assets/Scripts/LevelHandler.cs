using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] GameDataSO _gameDataSO = null;
    [SerializeField] LevelSO _levelSO = null;
    [SerializeField] BalloonSpawner _spawner = null;
    [SerializeField] TimeHandler _timeHandler = null;
    [SerializeField] bool _spawnOnStart = true;

    private void Awake()
    {
        _levelSO = _gameDataSO.CurrentLevelSO;
    }

    private void Start()
    {
        if (_spawnOnStart)
        {
            StartGame();
        }
    }

    private void OnEnable()
    {
        TimeHandler.OnCountdownEnded += EndGame;
    }

    private void OnDisable()
    {
        TimeHandler.OnCountdownEnded -= EndGame;
    }

    public void StartGame()
    {
        _spawner.StartSpawning(_levelSO);
        _timeHandler.StartCountdown(_levelSO);
    }

    public void EndGame()
    {
        _spawner.StopSpawning();
    }
}
