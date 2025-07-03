using System.Collections;
using TMPro;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] GameDataSO _gameDataSO = null;
    [SerializeField] LevelSO _levelSO = null;
    [Space]
    [SerializeField] BalloonSpawner _spawner = null;
    [SerializeField] TimeHandler _timeHandler = null;
    [SerializeField] ScoreHandler _scoreHandler = null;
    [SerializeField] CanvasView _hud = null;
    [SerializeField] CanvasView _endgameView = null;
    [SerializeField] TextMeshProUGUI _startMessageText = null;
    [Space]
    [SerializeField] bool _spawnOnStart = true;
    [SerializeField] float _startDelay = 1;
    [SerializeField] float _endDelay = 2;

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
        StartCoroutine(StartGame_Routine());
    }

    private IEnumerator StartGame_Routine()
    {
        _hud.Show();
        _startMessageText.text = _levelSO.StartMessage;
        yield return new WaitForSecondsRealtime(_startDelay);
        _spawner.StartSpawning(_levelSO);
        _timeHandler.StartCountdown(_levelSO);
    }

    public void EndGame()
    {
        StartCoroutine(EndGame_Routine());
    }

    private IEnumerator EndGame_Routine()
    {
        _spawner.StopSpawning();
        _timeHandler.ResetTime();
        _scoreHandler.EndPopFever();
        yield return new WaitForSecondsRealtime(_endDelay);
        _hud.Hide();
        _endgameView.Show();
    }
}
