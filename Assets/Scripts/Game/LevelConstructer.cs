using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelConstructer : MonoBehaviour
{
    public List<Enemy_Count> Enemy_Count = new List<Enemy_Count>();

    public float SpawnCooldown;

}

[Serializable]
public class Enemy_Count
{
    public Enemy Enemy;
    public float Count;
}
