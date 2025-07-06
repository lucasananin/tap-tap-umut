using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text = null;

    private void OnEnable()
    {
        TimeHandler.OnCountdownChanged += UpdateVisuals;
    }

    private void UpdateVisuals(float _value)
    {
        _text.text = $"{_value:F1}";
    }
}
