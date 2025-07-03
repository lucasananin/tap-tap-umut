using UnityEngine;

public class LevelButton : SceneLoaderButton
{
    [SerializeField] GameDataSO _gameDataSO = null;
    [SerializeField] LevelSO _levelSO = null;

    public override void Load()
    {
        base.Load();
        _gameDataSO.CurrentLevelSO = _levelSO;
    }
}
