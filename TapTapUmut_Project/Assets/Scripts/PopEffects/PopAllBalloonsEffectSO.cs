using UnityEngine;

[CreateAssetMenu(fileName = "PopAllBalloonsEffectSO", menuName = "Scriptable Objects/Pop Effects/Pop All Balloons")]
public class PopAllBalloonsEffectSO : PopEffectSO
{
    public override void Pop(BalloonBehaviour _behaviour)
    {
        _behaviour.PopAll();
    }
}
