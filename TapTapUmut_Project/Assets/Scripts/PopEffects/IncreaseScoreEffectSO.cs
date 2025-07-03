using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseScoreEffectSO", menuName = "Scriptable Objects/Pop Effects/Increase Score")]
public class IncreaseScoreEffectSO : PopEffectSO
{
    public override void Pop(BalloonBehaviour _behaviour)
    {
        _behaviour.IncreaseScore();
    }
}
