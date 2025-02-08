using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    [HideInInspector] protected float speed;
    [HideInInspector] protected float damage;

    public Transform Target;

    protected virtual void Start() { }

    protected virtual void Update()
    {
        if (Target != null)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
        else Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider) { }

}
