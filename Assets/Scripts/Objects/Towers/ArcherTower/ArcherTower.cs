using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _firstShootCooldown;
    [SerializeField] private GameObject _ammunitionPrefab;
    [SerializeField] private Transform _spawnpoint;

    private List<Transform> _enemies = new List<Transform>();

    private bool _isShooting = false;
    private bool _targetStayAtTrigger = false;

    private Transform _target;

    private void Update()
    {
        if (_targetStayAtTrigger == false && _target != null) ChangeTarget();

        if (_target == null && _enemies.Count != 0) _target = _enemies[0];

        if (_target !=  null && _isShooting == false)
        {
            StartCoroutine(ShootByTime(_target));
            _isShooting = true;
        }
    }


    private void ChangeTarget()
    {
        _targetStayAtTrigger = true;
        _enemies.Remove(_target);
        if (_target != null) _target = _enemies[0];
        _isShooting = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy.transform);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            if (_target != null)
            {
                if (enemy.Equals(_target.gameObject.GetComponent<Enemy>()))
                {
                    _targetStayAtTrigger = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy.transform);

            if (enemy.Equals(_target.gameObject.GetComponent<Enemy>()))
            {
                ChangeTarget();
            }
        }
    }


    private IEnumerator ShootByTime(Transform target)
    {
        Debug.Log("asd");
        yield return new WaitForSeconds(_firstShootCooldown);
        while (_enemies.Contains(target))
        {
            GameObject gameObject = Instantiate(_ammunitionPrefab, _spawnpoint.position, Quaternion.identity);
            gameObject.GetComponent<Arrow>().Target = target;

            yield return new WaitForSeconds(_shootCooldown);
        }
    }
}
