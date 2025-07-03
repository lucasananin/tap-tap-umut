using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] int _currentValue = 0;

    public event UnityAction<HealthBehaviour> OnDamaged = null;
    public event UnityAction<HealthBehaviour> OnDie = null;

    public void TakeDamage()
    {
        if (IsDead()) return;

        _currentValue--;

        if (_currentValue <= 0)
        {
            _currentValue = 0;
            Die();
        }
        else
        {
            OnDamaged?.Invoke(this);
        }
    }

    public virtual void Die()
    {
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return _currentValue <= 0;
    }
}
