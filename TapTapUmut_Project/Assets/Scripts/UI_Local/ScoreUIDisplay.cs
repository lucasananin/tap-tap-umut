using TMPro;
using UnityEngine;

public class ScoreUIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _valueText = null;
    [SerializeField] TextMeshProUGUI _multiplierText = null;
    [SerializeField] float _lerpMultiplier = 1f;

    [Header("// READONLY")]
    [SerializeField] int _value = 0;
    [SerializeField] int _targetValue = 0;
    [SerializeField] float _time = 0;

    private void OnEnable()
    {
        ScoreHandler.OnChanged += UpdateVisuals;
    }

    private void OnDisable()
    {
        ScoreHandler.OnChanged -= UpdateVisuals;
    }

    private void LateUpdate()
    {
        if (_value == _targetValue) return;

        _time += Time.deltaTime * _lerpMultiplier;
        _value = (int)Mathf.Lerp(_value, _targetValue, _time);
        _valueText.text = $"{_value}";
    }

    private void UpdateVisuals(ScoreHandler _scoreHandler)
    {
        _value = _targetValue;
        _targetValue = _scoreHandler.CurrentValue;
        _time = 0;

        _valueText.text = $"{_scoreHandler.CurrentValue}";
        _multiplierText.text = $"x{_scoreHandler.CurrentMultiplier}";
    }
}
