using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    private Dictionary<Enemy, int> _enemy_WaypointIndex1 = new Dictionary<Enemy, int>();

    private List<Enemy_WaypoinIndex> _enemy_WaypointIndex = new List<Enemy_WaypoinIndex>();

    void Update()
    {
        if (_enemy_WaypointIndex.Count != LevelData.Instance.Enemies.Count)
        {
            int difference = LevelData.Instance.Enemies.Count - _enemy_WaypointIndex.Count;
            var enemy = LevelData.Instance.Enemies[LevelData.Instance.Enemies.Count -difference];
            _enemy_WaypointIndex.Add(new Enemy_WaypoinIndex(enemy, 0));
        }
        else
        {
            int i = 0;
            foreach (var enemies in _enemy_WaypointIndex)
            {
                if (!(enemies.WaypointIndex >= LevelData.Instance.Waypoints.Count))
                {
                    enemies.Enemy.transform.LookAt(LevelData.Instance.Waypoints[enemies.WaypointIndex]);
                    enemies.Enemy.transform.position = Vector3.MoveTowards(enemies.Enemy.transform.position,
                        LevelData.Instance.Waypoints[enemies.WaypointIndex].position,
                        LevelData.Instance.EnemiesSpeed[enemies.Enemy] * Time.deltaTime);

                    if (enemies.Enemy.transform.position.x == LevelData.Instance.Waypoints[enemies.WaypointIndex].position.x)
                    {
                        _enemy_WaypointIndex[i].WaypointIndex++;
                    }
                }
                i++;
            }
        }

    }
}

public class Enemy_WaypoinIndex
{
    public Enemy_WaypoinIndex(Enemy enemy, int waypointIndex)
    {
        Enemy = enemy;
        WaypointIndex = waypointIndex;
    }
    public Enemy Enemy;
    public int WaypointIndex;
}
