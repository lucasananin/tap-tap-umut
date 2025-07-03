using UnityEngine;

[CreateAssetMenu(fileName = "SlowMotionEffectSO", menuName = "Scriptable Objects/Pop Effects/Slow Motion")]
public class SlowMotionEffectSO : PopEffectSO
{
    public override void Pop(BalloonBehaviour _behaviour)
    {
        _behaviour.StartSlowMotion();
    }
}
