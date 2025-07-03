using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TapHandler : MonoBehaviour
{
    [SerializeField] ContactFilter2D _contacFilter = default;

    private readonly List<HealthBehaviour> _ballonsHit = new(99);
    private readonly RaycastHit2D[] _results = new RaycastHit2D[99];

    public static event UnityAction<List<HealthBehaviour>> OnTap = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        _ballonsHit.Clear();
        var _origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var _hits = Physics2D.Raycast(_origin, Vector3.forward, _contacFilter, _results, 99);

        for (int i = 0; i < _hits; i++)
        {
            var _colliderHit = _results[i].collider;
            //Debug.Log($"// hit {_colliderHit.name}");

            if (_colliderHit.TryGetComponent(out HealthBehaviour _health))
            {
                _health.TakeDamage();
                _ballonsHit.Add(_health);
            }
        }

        if (_ballonsHit.Count > 0)
            OnTap?.Invoke(_ballonsHit);
    }
}
