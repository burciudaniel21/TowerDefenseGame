using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    [SerializeField] float range = 15f;


    [Header("Use Bullets (default)")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    [SerializeField] bool useLaser = false;
    [SerializeField] ParticleSystem impactEffect;
    public LineRenderer lineRenderer;
    [SerializeField] Light impactLight;
    [SerializeField] int dmgOverTime = 30;
    [SerializeField] float slowPercentage = .5f;

    [Header("Unity setup fields")]
    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] Transform partToRotate;
    [SerializeField] float turretTurnSpeed = 7f;
    [SerializeField] Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false; 
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    private void Laser()
    {
        targetEnemy.TakeDamage(dmgOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercentage);
        if(!lineRenderer.enabled)
        { 
            lineRenderer.enabled = true; 
            impactEffect.Play();
            impactLight.enabled = true;

        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position +  dir.normalized ; //update the location of the particle effect to appear at the location of the enemy

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    private void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turretTurnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        GameObject instantiatedBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = instantiatedBullet.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) 
        { 
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else 
        { 
            target = null; 
        }
    }
}
