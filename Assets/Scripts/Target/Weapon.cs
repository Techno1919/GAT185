using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Range(0, 3)] public float fireRate = 0.1f;
    [Range(0, 100)] public float angle = 10.0f;

    int ammo = 500;
    float fireTimer = 0;

    public Projectile _projectile;
    public Transform emitTransform;

    void Start()
    {
        
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 direction = (point - transform.position).normalized;

            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.Fire(ray.direction);
            *//*Destroy(gameObeject, 3);
            Destroy(hitInfo.collider.gameObject);*//*
        }*/
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        if (fireTimer >= fireRate && ammo > 0)
        {
            fireTimer = 0;
            ammo--;
            Projectile bullet = Instantiate(_projectile, position, Quaternion.identity);
            bullet.Fire(direction);

            return true;
        }

        return false;
    }

    public bool Fire(Vector3 direction)
    {
        if (fireTimer >= fireRate && ammo > 0)
        {
            fireTimer = 0;
            ammo--;
            Projectile bullet = Instantiate(_projectile, emitTransform.position, emitTransform.rotation);
            bullet.Fire(direction);

            return true;
        }

        return false;
    }
}
