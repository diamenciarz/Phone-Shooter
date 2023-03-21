using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject shootingPoint;

    [Header("Shooting settings")]
    [SerializeField] float shootingCooldown = 0.5f;

    private float lastShotTime = 0;

    private void Start()
    {
        if (projectile == null)
        {
            Debug.LogError("Projectile has to be assigned!");
        }
        if (shootingPoint == null)
        {
            Debug.LogError("ShootingPoint has to be assigned!");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TryShoot();
        }
    }
    private void TryShoot()
    {
        float timeSinceLastShot = Time.time - lastShotTime;
        if (timeSinceLastShot > shootingCooldown)
        {
            Instantiate(projectile, shootingPoint.gameObject.transform.position, shootingPoint.transform.rotation);
            lastShotTime = Time.time;
        }

    }
}
