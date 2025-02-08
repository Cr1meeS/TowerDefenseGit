using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Vector3 velocity;

    public Transform Target;

    private void Update()
    {
        if (Target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref velocity, 0f, _speed * 1000f);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IDamagable enemy))
        {
            enemy.GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}
