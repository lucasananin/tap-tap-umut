using UnityEngine;

public class ExplosionCamShake : CameraShaker
{
    [SerializeField] HealthBehaviour _health = null;
    [SerializeField] float _velocityMultiplier = 1f;

    protected override void OnValidate()
    {
        base.OnValidate();
        _health = GetComponent<HealthBehaviour>();
    }

    private void Start()
    {
        SetShape(Unity.Cinemachine.CinemachineImpulseDefinition.ImpulseShapes.Explosion);
    }

    private void OnEnable()
    {
        _health.OnDie += Shake;
    }

    private void OnDisable()
    {
        _health.OnDie -= Shake;
    }

    private void Shake(HealthBehaviour arg0)
    {
        Shake();
    }

    public override void Shake()
    {
        var _velocity = GeneralMethods.GetRandomDirection() * _velocityMultiplier;
        _impulseSource.GenerateImpulse(_velocity);
    }
}
