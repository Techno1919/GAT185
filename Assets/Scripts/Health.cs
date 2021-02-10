using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float healthMax;
    public float decay;
    public Slider slider;
    public bool destroyOnDeath = false;

    public float CurrentHealth { get; set; }

    void Start()
    {
        CurrentHealth = healthMax;
    }

    
    void Update()
    {
        if(slider != null)
        {
            slider.value = (CurrentHealth / healthMax);
        }
        if(CurrentHealth <= 0 && destroyOnDeath)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(float health)
    {
        CurrentHealth += health;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0 , healthMax);
    }
}
