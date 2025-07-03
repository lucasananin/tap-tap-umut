using System.Collections.Generic;
using UnityEngine;
using Utilities;

[CreateAssetMenu(fileName = "Level_", menuName = "Scriptable Objects/LevelSO")]
public class LevelSO : ScriptableObject
{
    [SerializeField] BalloonTable[] _tables = null;
    [SerializeField] Vector2 _delayRange = new(1f, 2f);
    [SerializeField] Vector2 _xForceRange = new(-1f, 1f);
    [SerializeField] Vector2 _yForceRange = new(10f, 12f);
    [SerializeField] Vector2 _torqueRange = new(4f, 8f);
    [SerializeField] Vector2Int _burstRange = new(1, 3);

    [Header("// READONLY")]
    [SerializeField] List<float> _odds = null;

    public Vector2 DelayRange { get => _delayRange; }
    public Vector2 XForceRange { get => _xForceRange; }
    public Vector2 YForceRange { get => _yForceRange; }
    public Vector2 TorqueRange { get => _torqueRange; }
    public Vector2Int BurstRange { get => _burstRange; }

    public void WarmUp()
    {
        _odds.Clear();
        int _count = _tables.Length;

        for (int i = 0; i < _count; i++)
        {
            _odds.Add(_tables[i].Odd);
        }
    }

    public BalloonBehaviour GetPrefab()
    {
        var _table = RandomMethods.GetRandomInList(_odds, _tables);
        return _table.GetPrefab();
    }

    [System.Serializable]
    private class BalloonTable
    {
        [SerializeField] BalloonBehaviour[] _prefabs = null;
        [SerializeField] int _odd = 80;

        public int Odd { get => _odd; }

        public BalloonBehaviour GetPrefab()
        {
            return _prefabs[Random.Range(0, _prefabs.Length)];
        }
    }
}
