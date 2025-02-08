using UnityEngine;

public class Arrow : Ammo
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    protected override void Start()
    {
        speed = _speed;
        damage = _damage;
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IDamagable enemy))
        {
            enemy.GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}
