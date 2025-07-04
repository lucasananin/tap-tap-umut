using UnityEngine;

public class SpawnOnDie : MonoBehaviour
{
    [SerializeField] GameObject _prefab = null;

    [Header("// READONLY")]
    [SerializeField] HealthBehaviour _health = null;

    private void OnValidate()
    {
        _health = GetComponent<HealthBehaviour>();
    }

    private void OnEnable()
    {
        _health.OnDie += Spawn;
    }

    private void OnDisable()
    {
        _health.OnDie -= Spawn;
    }

    private void Spawn(HealthBehaviour _health)
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
