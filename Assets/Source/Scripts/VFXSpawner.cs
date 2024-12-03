using UnityEngine;
using AYellowpaper.SerializedCollections;

public class VFXSpawner : MonoBehaviour
{
    [SerializeField]
    private SerializedDictionary<VfxType, ParticleSystem> particles;

    private void Awake()
    {
        Projectile.OnDestroy += SpawnAtPosition;
        Gun.OnShot += SpawnAtPosition;
    }

    private void SpawnAtPosition(VfxType vfxType,Vector3 position)
    {
        if(particles.ContainsKey(vfxType))
        {
            Instantiate(particles[vfxType],position,Quaternion.identity);
        }
    }
    private void OnDestroy()
    {
        Projectile.OnDestroy -= SpawnAtPosition;
        Gun.OnShot -= SpawnAtPosition;
    }
}
public enum VfxType { RocketExplosion, Muzzle }

