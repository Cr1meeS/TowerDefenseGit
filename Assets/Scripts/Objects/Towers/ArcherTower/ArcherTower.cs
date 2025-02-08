using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] protected float ShootCooldown;
    [SerializeField] protected float FirstShootCooldown;

    protected override void Start()
    {
       _shootCooldown = ShootCooldown;
        _firstShootCooldown = FirstShootCooldown;
    }
}
