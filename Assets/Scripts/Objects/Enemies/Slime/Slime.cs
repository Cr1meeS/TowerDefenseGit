using UnityEngine;

public class Slime : Enemy, IDamagable
{
    [SerializeField] private float _health;

    public float Speed;


    protected override void Start()
    {
        if (!LevelData.Instance.EnemiesSpeed.ContainsKey(this))
        {
            LevelData.Instance.EnemiesSpeed[this] = Speed;
        }
        speed = LevelData.Instance.EnemiesSpeed[this];
        Health = _health;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {
        _health = _health - damage;

        HealthChange(_health);
        if (_health <= 0) Die();

    } 
}
