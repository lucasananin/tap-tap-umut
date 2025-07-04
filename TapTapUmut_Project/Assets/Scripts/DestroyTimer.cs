using System.Collections;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] Vector2 _timeRange = new(8, 12);

    private IEnumerator Start()
    {
        var _time = Random.Range(_timeRange.x, _timeRange.y);
        yield return new WaitForSeconds(_time);

        Destroy(gameObject);
    }
}
