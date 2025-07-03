using System.Collections;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] Collider2D _area = null;
    [SerializeField] bool _spawnOnStart = true;
    [Space]
    [SerializeField] BalloonBehaviour[] _prefabs = null;
    [SerializeField] Vector2 _delayRange = new(1f, 2f);
    [SerializeField] Vector2 _xForceRange = new(-1f, 1f);
    [SerializeField] Vector2 _yForceRange = new(10f, 12f);
    [SerializeField] Vector2 _torqueRange = new(5f, 10f);

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
        while (true)
        {
            var _prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            var _position = GeneralMethods.RandomPointInBounds(_area.bounds);
            var _rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
            var _instance = Instantiate(_prefab, _position, _rotation);

            var _force = new Vector2(Random.Range(_xForceRange.x, _xForceRange.y), Random.Range(_yForceRange.x, _yForceRange.y));
            var _torque = Random.Range(_torqueRange.x, _torqueRange.y);
            _instance.AddForce(_force, _torque);

            var _delay = Random.Range(_delayRange.x, _delayRange.y);
            yield return new WaitForSeconds(_delay);
        }
    }
}
