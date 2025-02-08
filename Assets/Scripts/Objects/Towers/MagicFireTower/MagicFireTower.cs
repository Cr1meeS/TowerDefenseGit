using UnityEngine;

public class MagicFireTower : Tower
{
    [SerializeField] protected float ShootCooldown;
    [SerializeField] protected float FirstShootCooldown;

    protected override void Start()
    {
        _shootCooldown = ShootCooldown;
        _firstShootCooldown = FirstShootCooldown;
    }
}
