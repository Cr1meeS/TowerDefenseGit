using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{

    [HideInInspector] protected float _shootCooldown;
    [HideInInspector] protected float _firstShootCooldown;

    [SerializeField] protected GameObject _ammunitionPrefab;
    [SerializeField] protected Transform _ammoSpawnpoint;

    protected List<Transform> _enemies = new List<Transform>();

    protected bool _isShooting = false;

    protected Transform _target;

    protected virtual void Start() { }

    protected virtual void Update()
    {
        if (_target == null && _enemies.Count != 0) ChangeTarget();

        if (_target != null && _isShooting == false) StartCoroutine(ShootByTime(_target));
    }


    protected virtual void ChangeTarget()
    {
        _enemies.Remove(_target);
        if (_enemies.Count != 0) _target = _enemies[0];
        if (_target != null) _target.GetComponent<Enemy>().OnDieEvent += TargetDie;
        _isShooting = false;
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy.transform);
        }
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy.transform);
        }
    }

    protected virtual void TargetDie()
    {
        _target.GetComponent<Enemy>().OnDieEvent -= TargetDie;
        ChangeTarget();
    }

    protected virtual void OnDisable()
    {
        if (_target != null) _target.GetComponent<Enemy>().OnDieEvent -= TargetDie;

    }

    protected virtual IEnumerator ShootByTime(Transform target)
    {
        _isShooting = true;
        yield return new WaitForSeconds(_firstShootCooldown);
        while (_enemies.Contains(target))
        {
            GameObject gameObject = Instantiate(_ammunitionPrefab, _ammoSpawnpoint.position, Quaternion.identity);
            gameObject.GetComponent<Ammo>().Target = target;
            yield return new WaitForSeconds(_shootCooldown);
        }
    }
}
