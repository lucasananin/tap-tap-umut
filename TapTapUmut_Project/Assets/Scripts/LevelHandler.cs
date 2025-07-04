using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] RawImage _background = null;
    [Space]
    [SerializeField] bool _spawnOnStart = true;
    [SerializeField] bool _debug = false;
    [SerializeField] float _startDelay = 1;
    [SerializeField] float _endDelay = 2;

    private void Awake()
    {
        if (!_debug)
            _levelSO = _gameDataSO.CurrentLevelSO;

        _startMessageText.text = _levelSO.StartMessage;
        _background.texture = _levelSO.Background;
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
