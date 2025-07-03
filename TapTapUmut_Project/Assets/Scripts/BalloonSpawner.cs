using System.Collections;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] Collider2D _area = null;
    [SerializeField] bool _spawnOnStart = true;
    [Space]
    [SerializeField] LevelSO _levelSO = null;

    private void Start()
    {
        if (_spawnOnStart)
        {
            StartSpawning();
        }
    }

    [ContextMenu("StartSpawning()")]
    public void StartSpawning()
    {
        StartCoroutine(Spawn_Routine());
    }

    private IEnumerator Spawn_Routine()
    {
        _levelSO.WarmUp();

        while (true)
        {
            int _count = Random.Range(_levelSO.BurstRange.x, _levelSO.BurstRange.y + 1);

            for (int i = 0; i < _count; i++)
            {
                var _prefab = _levelSO.GetPrefab();
                var _position = GeneralMethods.RandomPointInBounds(_area.bounds);
                var _rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
                var _instance = Instantiate(_prefab, _position, _rotation);

                var _force = new Vector2(Random.Range(_levelSO.XForceRange.x, _levelSO.XForceRange.y), Random.Range(_levelSO.YForceRange.x, _levelSO.YForceRange.y));
                var _torque = Random.Range(_levelSO.TorqueRange.x, _levelSO.TorqueRange.y);
                _instance.AddForce(_force, _torque);
            }

            var _delay = Random.Range(_levelSO.DelayRange.x, _levelSO.DelayRange.y);
            yield return new WaitForSeconds(_delay);
        }
    }
}
