using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamage
{

    public int startingHealth=20;
    public int currentHealth;
    public HealthBar healthBar;

    

    void Start()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);        
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            
            gameObject.SetActive(false);
            GameManager.instance.MissionFailed();
        }
    }

    public void ITakeDamage(int damage)
    {
        currentHealth -= damage;
        AudioManager.instance.Play("Death");
        healthBar.SetHealth(currentHealth);
        CheckHealth();
    }

    public void GiveHealth(int health)
    {
        currentHealth =Mathf.Clamp(currentHealth +health,0,startingHealth)  ;//Ýki deðer arasýnda tutar.
        healthBar.SetHealth(currentHealth);

    }
}
 