using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float healthMax;
    public float decay;
    public Slider slider;
    public GameObject destroySpawnObject;
    public bool destroyOnDeath = false;
    public UnityEvent deathEvent;
    
    public float CurrentHealth { get; set; }
    public bool IsDead { get; set; } = false;

    void Start()
    {
        CurrentHealth = healthMax;
    }

    
    void Update()
    {
        if(slider != null) slider.value = (CurrentHealth / healthMax);

        if(CurrentHealth <= 0 && !IsDead)
        {
            IsDead = true;

            deathEvent?.Invoke();
            if(destroySpawnObject != null)
            {
                Instantiate(destroySpawnObject, transform.position, transform.rotation);
            }
            if(destroyOnDeath) Destroy(gameObject);
        }
    }

    public void AddHealth(float health)
    {
        CurrentHealth += health;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0 , healthMax);
    }
}
