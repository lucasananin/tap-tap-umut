using UnityEngine;

[CreateAssetMenu(fileName = "DestroyAllBalloonsEffectSO", menuName = "Scriptable Objects/Pop Effects/Destroy All Balloons")]
public class DestroyAllBalloonsEffectSO : PopEffectSO
{
    public override void Pop(BalloonBehaviour _behaviour)
    {
        _behaviour.DestroyAll();
    }
}
