using System;
using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;
    [SerializeField] PopEffectSO _popEffectSO = null;
    [Space]
    [SerializeField] int _scoreValue = 3;

    public void AddForce(Vector2 _force, float _torque)
    {
        _rb.AddForce(_force, ForceMode2D.Impulse);
        _rb.AddTorque(_torque * _force.x, ForceMode2D.Impulse);
    }

    public void ApplyEffect()
    {
        _popEffectSO.Pop(this);
    }

    public void IncreaseScore()
    {
        var _scoreHandler = FindFirstObjectByType<ScoreHandler>();
        _scoreHandler.IncreaseValue(_scoreValue);
    }

    public void DecreaseScore()
    {
        var _scoreHandler = FindFirstObjectByType<ScoreHandler>();
        _scoreHandler.DecreaseValue(_scoreValue);
    }

    public void DestroyAll()
    {
        var _balloons = FindObjectsByType<BalloonBehaviour>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        var _count = _balloons.Length;

        for (int i = _count - 1; i >= 0; i--)
        {
            Destroy(_balloons[i].gameObject);
        }

        var _scoreHandler = FindFirstObjectByType<ScoreHandler>();
        _scoreHandler.DecreaseValue(0);
    }
}
