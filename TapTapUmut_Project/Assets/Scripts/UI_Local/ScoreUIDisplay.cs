using TMPro;
using UnityEngine;

public class ScoreUIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _valueText = null;
    [SerializeField] TextMeshProUGUI _multiplierText = null;

    private void OnEnable()
    {
        ScoreHandler.OnChanged += UpdateVisuals;
    }

    private void OnDisable()
    {
        ScoreHandler.OnChanged -= UpdateVisuals;
    }

    private void UpdateVisuals(ScoreHandler _scoreHandler)
    {
        _valueText.text = $"{_scoreHandler.CurrentValue}";
        _multiplierText.text = $"x{_scoreHandler.CurrentMultiplier}";
    }
}
