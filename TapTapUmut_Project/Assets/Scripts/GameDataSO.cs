using UnityEngine;

[CreateAssetMenu(fileName = "GameDataSO", menuName = "Scriptable Objects/GameDataSO")]
public class GameDataSO : ScriptableObject
{
    [SerializeField] LevelSO _currentLevelSO = null;

    public LevelSO CurrentLevelSO { get => _currentLevelSO; set => _currentLevelSO = value; }
}
