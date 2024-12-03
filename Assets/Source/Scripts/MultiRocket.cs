using UnityEngine;
using UnityEngine.Rendering;

public class MultiRocket : Projectile
{
    [SerializeField] private Projectile spawnProjectilePrefab;
    [SerializeField] private int countToSpawn = 3;
    private bool isSpawning; 
    private void FixedUpdate()
    {
        if (!isSpawning&&rb.velocity.y < 0)
        {
            Spawn();
            Destruct();
        }
    }
    private void Spawn()
    {
        isSpawning = true;
        for (int i = 0; i < countToSpawn; i++)
        {
            var projectile = Instantiate(spawnProjectilePrefab, transform.position, transform.rotation);
            projectile.SetVelocity(rb.velocity.magnitude+(i - (float)countToSpawn / 2));
        }
    }
}
