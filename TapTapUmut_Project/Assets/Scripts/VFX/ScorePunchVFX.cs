using DG.Tweening;
using UnityEngine;

public class ScorePunchVFX : MonoBehaviour
{
    [SerializeField] RectTransform _rect = null;
    [SerializeField] Vector2 _punch = default;
    [SerializeField] float _duration = 0.3f;

    private void OnEnable()
    {
        ScoreHandler.OnIncrease += Play;
    }

    private void OnDisable()
    {
        ScoreHandler.OnIncrease += Play;
    }

    private void Play(ScoreHandler arg0)
    {
        _rect.DOComplete();
        _rect.DOPunchScale(_punch, _duration);
    }
}
