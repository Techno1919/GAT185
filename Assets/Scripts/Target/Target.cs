using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 100;
    public Material material;
    public GameObject destroyGameObject;
    public AudioSource audioSource;
    public GameObject spawnGameObject;
    public float lifetime = 5.0f;
    public bool useLifetime = false;

    private void Start()
    {
        GetComponent<Renderer>().material = material;
       // audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // add score to game
        if(collision.gameObject.CompareTag("Projectile"))
        {
            audioSource.Play();
            //Game.Instance.AddPoints(points);
            if(destroyGameObject != null)
            {
                Destroy(destroyGameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Instantiate(spawnGameObject, transform.position, Quaternion.identity);
        if (useLifetime)
        {
            Destroy(gameObject, lifetime);
        }
    }
}
