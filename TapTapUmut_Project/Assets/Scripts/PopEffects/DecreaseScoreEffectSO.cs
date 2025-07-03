using UnityEngine;

[CreateAssetMenu(fileName = "DecreaseScoreEffectSO", menuName = "Scriptable Objects/Pop Effects/Decrease Score")]
public class DecreaseScoreEffectSO : PopEffectSO
{
    public override void Pop(BalloonBehaviour _behaviour)
    {
        _behaviour.DecreaseScore();
    }
}
