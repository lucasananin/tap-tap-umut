using System.Collections.Generic;
using UnityEngine;

public class BallonPopHandler : MonoBehaviour
{
    private void OnEnable()
    {
        TapHandler.OnTap += CheckBalloonsHit;
    }

    private void OnDisable()
    {
        TapHandler.OnTap -= CheckBalloonsHit;
    }

    private void CheckBalloonsHit(List<HealthBehaviour> _balloonsHit)
    {
        int _count = _balloonsHit.Count;

        // if hit more than one multiply the ScoreMultiplier for some seconds.

        for (int i = 0; i < _count; i++)
        {
            if (_balloonsHit[i].TryGetComponent(out BalloonBehaviour _behaviour))
            {
                _behaviour.ApplyEffect();
            }
        }
    }
}
