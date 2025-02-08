using UnityEngine;

public class Movement : MonoBehaviour
{
    private int _waypointIndex;

    void Update()
    {
        if (_waypointIndex >= LevelData.Instance.Waypoints.Count) Destroy(gameObject);

        else
        {
            transform.LookAt(LevelData.Instance.Waypoints[_waypointIndex]);
            transform.position = Vector3.MoveTowards(transform.position,
                LevelData.Instance.Waypoints[_waypointIndex].position,
                LevelData.Instance.EnemiesSpeed[gameObject.GetComponent<Enemy>()] * Time.deltaTime);

            if (transform.position.x == LevelData.Instance.Waypoints[_waypointIndex].position.x)
            {
                _waypointIndex++;
            }
        }
    }
}
