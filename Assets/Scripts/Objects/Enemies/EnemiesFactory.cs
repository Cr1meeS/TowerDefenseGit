using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFactory : MonoBehaviour
{

    [SerializeField] private Transform _spawnpoint;

    [SerializeField] private List<Enemy_Prefab> _enemy_Prefab = new List<Enemy_Prefab>(); 

    private float _spawnCooldown;

    [SerializeField]
    private LevelConstructer _levelConstructer;

    private void Start()
    {
        _spawnCooldown = _levelConstructer.SpawnCooldown;
        StartCoroutine(SpawnByTime());
    }

    private void Update()
    {
        
    }


    private void Spawn(Enemy enemy)
    {
        foreach (var enemy_prefab in _enemy_Prefab)
        {
            if (enemy_prefab.Enemy.Equals(enemy))
            {
                GameObject gameObject = Instantiate(enemy_prefab.Prefab, _spawnpoint.position, Quaternion.identity);
            }
        }
    }

    private IEnumerator SpawnByTime()
    {
        for (int enemiesCount = 0; enemiesCount < _levelConstructer.Enemy_Count.Count; enemiesCount++)
        {
            for (int i = 0; i < _levelConstructer.Enemy_Count[enemiesCount].Count; i++)
            {
                Spawn(_levelConstructer.Enemy_Count[enemiesCount].Enemy);
                
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }
    }
}

[Serializable]
public class Enemy_Prefab
{
    public Enemy Enemy; 
    public GameObject Prefab;
}
