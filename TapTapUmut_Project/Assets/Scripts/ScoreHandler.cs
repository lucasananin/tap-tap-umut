using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] int _currentValue = 0;
    [SerializeField] int _currentMultiplier = 1;

    public static event UnityAction<ScoreHandler> OnChanged = null;

    public int CurrentValue { get => _currentValue; }
    public int CurrentMultiplier { get => _currentMultiplier; }

    public void IncreaseValue(int _value)
    {
        var _totalValue = _value * _currentMultiplier;
        _currentValue += _totalValue;
        OnChanged?.Invoke(this);
    }
}
