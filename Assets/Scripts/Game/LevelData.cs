using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private static LevelData _instance;
    public static LevelData Instance
    {
        get
        {
            if (_instance == null) _instance = new LevelData();
            
            return _instance;
        }
        
    }

    public List<Enemy> Enemies = new List<Enemy>();

    public List<Transform> Waypoints = new List<Transform>();

    public Dictionary<Enemy, float> EnemiesSpeed = new Dictionary<Enemy, float>();

    public void Awake()
    {
        _instance = this;
    }

}
