using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb = null;

    public void AddForce(Vector2 _force, float _torque)
    {
        _rb.AddForce(_force, ForceMode2D.Impulse);
        _rb.AddTorque(_torque * _force.x, ForceMode2D.Impulse);
    }
}
