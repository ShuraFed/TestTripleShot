using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public static Action<VfxType,Vector3> OnDestroy;
    protected Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void SetVelocity(float force)
    {
        rb.velocity = transform.right * force;
    }
    private void LateUpdate()
    {
        transform.right = rb.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destruct();
    }
    public virtual void Destruct()
    {
        var VFX = GetComponentInChildren <ParticleSystem>();
        VFX?.transform.SetParent(null);
        OnDestroy?.Invoke(VfxType.RocketExplosion,transform.position);
        Destroy(gameObject);
    }
}