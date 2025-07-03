using UnityEngine;

//[CreateAssetMenu(fileName = "PopEffectSO", menuName = "Scriptable Objects/PopEffectSO")]
public abstract class PopEffectSO : ScriptableObject
{
    public abstract void Pop(BalloonBehaviour _behaviour);
}
