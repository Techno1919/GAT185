using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healing = 100;
    public GameObject spawnObject;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.AddHealth(healing);
            if(gameObject != null)
            {
                GameObject gameObject = Instantiate(spawnObject, transform.position, transform.rotation);
                Destroy(gameObject, 2);
            }
            Destroy(gameObject);
        }
    }
}
