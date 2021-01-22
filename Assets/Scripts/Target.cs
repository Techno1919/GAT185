using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 100;
    public Material material;
    public GameObject destroyGameObject;
    public AudioSource audioSource;


    private void Start()
    {
        GetComponent<Renderer>().material = material;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // add score to game
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Game.Instance.AddPoints(points);
            audioSource.Play();
            if(destroyGameObject != null)
            {
                Destroy(destroyGameObject);
            }
        }
    }

}
