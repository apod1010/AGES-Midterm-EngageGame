using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public AudioSource shipDestroyed;

    //public float deathdelay = 2f;
    //WaitForSeconds deathwait;

    public Slider healthSlider;

    [SerializeField]
    private int damageTaken = 20;

    private void Start()
    {
        //deathwait = new WaitForSeconds(deathdelay);

        //healthSlider = GetComponentInChildren<Slider>();
        //healthSlider.maxValue = maxHealth;
        //healthSlider.value = healthSlider.maxValue;
        currentHealth = maxHealth;


    }

    void OnCollisionEnter(Collision collision)
    {

        //Renderer rend = GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("Specular");

        if (collision.gameObject.tag == "Bullet")
        {
            AdjustCurrentHealth(-damageTaken);

            healthSlider.value = currentHealth;

            //rend.material.SetColor("_SpecColor", Color.red);
        }
    }

    public void AdjustCurrentHealth(int adj)
    {
        currentHealth += adj;

        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        if (currentHealth < 1)
        {
            shipDestroyed.Play();
            Destroy(gameObject);
        }
    }
}
