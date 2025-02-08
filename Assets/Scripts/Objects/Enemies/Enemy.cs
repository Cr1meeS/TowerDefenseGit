using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float speed;

    protected virtual void Awake()
    {
        LevelData.Instance.Enemies.Add(this);
    }

    protected virtual void Start() { }

    protected virtual void Update() { }
}
