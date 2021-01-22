using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.1f;
    
    int ammo = 500;
    float fireTimer = 0;

    public Bullet _bullet;

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
            Bullet bullet = Instantiate(_bullet, position, Quaternion.identity);
            bullet.Fire(direction);

            return true;
        }

        return false;
    }
}
