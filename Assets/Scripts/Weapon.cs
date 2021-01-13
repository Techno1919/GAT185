using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet _bullet;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 direction = (point - transform.position).normalized;

            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.Fire(ray.direction);
            /*Destroy(gameObeject, 3);
            Destroy(hitInfo.collider.gameObject);*/
        }
    }
}
