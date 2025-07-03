using System.Collections.Generic;
using UnityEngine;

public class BalloonPopHandler : MonoBehaviour
{
    private void OnEnable()
    {
        TapHandler.OnTap += CheckBalloonsHit;
    }

    private void OnDisable()
    {
        TapHandler.OnTap -= CheckBalloonsHit;
    }

    private void CheckBalloonsHit(List<BalloonBehaviour> _balloonsHit)
    {
        if (_balloonsHit.Count > 1)
        {
            var _scoreHandler = FindFirstObjectByType<ScoreHandler>();
            _scoreHandler.StartPopFever(_balloonsHit.Count);
        }

        ApplyEffects(_balloonsHit);
    }

    internal void ApplyEffects(List<BalloonBehaviour> _balloons)
    {
        int _count = _balloons.Count;

        for (int i = 0; i < _count; i++)
        {
            _balloons[i].ApplyEffect();
            _balloons[i].TakeDamage();
        }
    }
}
