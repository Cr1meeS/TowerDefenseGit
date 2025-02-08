using System.Collections;
using UnityEngine;

public class FireBall : Ammo
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _explasionRadius;
    [SerializeField] private float _explasionScaleSpeed;

    private bool _hit = false;

    protected override void Update()
    {
        if (Target != null && _hit == false)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, _speed * Time.deltaTime);
        }
        if (Target == null && _hit == false) Destroy(gameObject);
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IDamagable enemy))
        {
            if (_hit == false)
            {
                StartCoroutine(ExplasionByTime());
            }
            enemy.GetDamage(_damage);
        }
    }

    private IEnumerator ExplasionByTime()
    {
        Vector3 currentScale = new Vector3(_explasionRadius, _explasionRadius, _explasionRadius);
        _hit = true;
        while (_explasionRadius - 0.1f > transform.localScale.x)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, currentScale, _explasionScaleSpeed * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(ExplasionDisappearingByTime());  
    }

    private IEnumerator ExplasionDisappearingByTime()
    {
        while (transform.localScale.x > 1f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, _explasionScaleSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}