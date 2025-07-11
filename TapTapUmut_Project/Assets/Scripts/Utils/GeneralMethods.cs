using UnityEngine;

public class GeneralMethods
{
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public static Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle.normalized;
    }
}
