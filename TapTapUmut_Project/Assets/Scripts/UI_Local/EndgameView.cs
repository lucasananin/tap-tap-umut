using TMPro;
using UnityEngine;

public class EndgameView : CanvasView
{
    [SerializeField] TextMeshProUGUI _scoreText = null;

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
        _scoreText.text = $"Final Score\n{_scoreHandler.CurrentValue}";
    }
}
