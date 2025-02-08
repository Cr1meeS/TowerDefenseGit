using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float speed;

    public  delegate void OnDie();

    public event OnDie OnDieEvent;

    protected virtual void Awake()
    {
        LevelData.Instance.Enemies.Add(this);
    }

    protected virtual void Start() { }

    protected virtual void Update() { }

    protected virtual void OnDestroy() 
    {
        OnDieEvent?.Invoke();
    }
}
