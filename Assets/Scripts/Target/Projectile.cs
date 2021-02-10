using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Range(1, 100)] public float speed = 10.0f;
    public float timer = 5.0f;
    public bool destroyOnHit;
    public GameObject destroyFX;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Vector3 forward)
    {
        Rigidbody rigidbody =  GetComponent<Rigidbody>();
        rigidbody.AddForce(forward * speed, ForceMode.VelocityChange);
    }

    private void OnDestroy()
    {
        if(destroyFX != null)
        {
            Instantiate(destroyFX, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
