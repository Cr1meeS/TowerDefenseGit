using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speed;

    [HideInInspector] public float Health;
    private float _currentealh;

    public  delegate void OnDie();
    public  delegate void OnHealthChanged(float currentHealth);

    public event OnDie OnDieEvent;
    public event OnHealthChanged OnHealthChangedEvent;

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

    protected void HealthChange(float currentHealth)
    {
        _currentealh = currentHealth;
        OnHealthChangedEvent?.Invoke(currentHealth);
    }
}
