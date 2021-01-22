using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    public float lifetime = 5.0f;
    public bool useLifetime = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Instantiate(spawnGameObject, transform);
            if(useLifetime)
            {
                Destroy(gameObject, lifetime);
            }
        }
    }

}
