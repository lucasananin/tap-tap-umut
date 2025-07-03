using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] float _countdown = 60f;
    [SerializeField] float _slowMotionDuration = 3f;
    [SerializeField] float _slowMotionTime = 0.1f;

    [Header("// READONLY")]
    [SerializeField] bool _isCountingDown = false;

    public static event UnityAction<float> OnCountdownChanged = null;
    public static event UnityAction OnCountdownEnded = null;

    private void Update()
    {
        if (_isCountingDown)
        {
            _countdown -= Time.deltaTime;

            if (_countdown < 0)
            {
                _countdown = 0;
                _isCountingDown = false;
                OnCountdownEnded?.Invoke();
            }

            OnCountdownChanged?.Invoke(_countdown);
        }
    }

    public void StartCountdown(LevelSO _so)
    {
        _countdown = _so.Duration;
        _isCountingDown = true;
    }

    public void StartSlowMotion()
    {
        Time.timeScale = _slowMotionTime;
        StopAllCoroutines();
        StartCoroutine(SlowMotion_Routine());
    }

    private IEnumerator SlowMotion_Routine()
    {
        yield return new WaitForSecondsRealtime(_slowMotionDuration);
        ResetTime();
    }

    public void ResetTime()
    {
        Time.timeScale = 1;
    }
}
