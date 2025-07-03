using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    [Header("// READONLY")]
    [SerializeField] int _currentValue = 0;
    [SerializeField] int _currentMultiplier = 1;
    [SerializeField] int _feverMultiplier = 1;

    public static event UnityAction<ScoreHandler> OnChanged = null;
    public static event UnityAction<ScoreHandler> OnIncrease = null;
    public static event UnityAction<ScoreHandler> OnDecrease = null;
    public static event UnityAction<ScoreHandler> OnStartFever = null;
    public static event UnityAction<ScoreHandler> OnEndFever = null;

    public int CurrentValue { get => _currentValue; }
    public int CurrentMultiplier { get => _currentMultiplier; }

    private void Start()
    {
        ResetValues();
    }

    public void ResetValues()
    {
        _currentValue = 0;
        _currentMultiplier = 1;
        OnChanged?.Invoke(this);
    }

    public void IncreaseValue(int _value)
    {
        var _totalValue = _value * _currentMultiplier;
        _currentValue += _totalValue;
        _currentMultiplier++;
        OnChanged?.Invoke(this);
        OnIncrease?.Invoke(this);
    }

    public void DecreaseValue(int _value)
    {
        _currentValue -= _value;
        _currentMultiplier = 1;
        OnChanged?.Invoke(this);
        OnDecrease?.Invoke(this);
    }

    public void StartPopFever(int _multiplier)
    {
        _feverMultiplier = _multiplier;
        StopAllCoroutines();
        StartCoroutine(PopFever_Routine());
    }

    private IEnumerator PopFever_Routine()
    {
        OnStartFever?.Invoke(this);
        _currentMultiplier *= _feverMultiplier;
        yield return new WaitForSeconds(5f);
        EndPopFever();
    }

    public void EndPopFever()
    {
        StopAllCoroutines();
        _currentMultiplier /= _feverMultiplier;
        OnEndFever?.Invoke(this);
    }

    public void DoubleScore()
    {
        _currentValue *= 2;
        OnChanged?.Invoke(this);
    }
}
