using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour,IDamage
{
    public int health;
    public float currentHealth;
    UIHealthBar healthBar;
    Animator anim;
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = health; 
        healthBar = GetComponentInChildren<UIHealthBar>();
        anim = this.GetComponent<Animator>();
    }
   public virtual void  CheckHealth()
    {
        if (currentHealth <= 0)
        {
            healthBar.gameObject.SetActive(false);

           
            
            if (anim !=null)
            {
                anim.SetBool("die", true);
                Invoke("DestroySelf", 2f);
               
            }
            else
              DestroySelf();
         
        }
    }
   public void  DestroySelf()
    {

        spawnManager.RemoveFromList(gameObject);
        Destroy(gameObject);
        
     }

    public void ITakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealthBarPercentage(currentHealth / health);     
        CheckHealth();
    }
    
}
