using DG.Tweening;
using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform barrel;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float shootPower=10;
    public static Action<VfxType, Vector3> OnShot;

    public void Shoot()
    {
        var projectile=Instantiate(projectilePrefab,projectileSpawnPoint.transform.position,projectileSpawnPoint.transform.rotation);
        projectile.SetVelocity(shootPower);
        OnShot?.Invoke(VfxType.Muzzle, projectileSpawnPoint.position);
        barrel.DOKill(true);
        barrel.DOPunchPosition(-barrel.right*0.5f,0.3f);
    }
}
