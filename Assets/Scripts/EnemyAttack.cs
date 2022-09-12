using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool isAttack;

    

    public int damage;

    public int maxAmmo;
    public int currentAmmo;
    public int reloadTime = 2;
    public bool isReloading = false;

    public Animator anim;

    private bool attackStartOnce =true;
    public IEnumerator attackStart;
    public EnemyHealthManager enemyHealthManager; 

 
    void Start()
    {
        anim = GetComponent<Animator>();         
    }
  
    public virtual void Attack(bool canAttack)
    {
    }
    public void AttackStart()
    {
        if (attackStartOnce)
        {
            attackStartOnce = false;
            if (attackStart !=null)
            {
                StartCoroutine(attackStart);
            }
        }
    }
    public void AttackStop()
    {
        if (!attackStartOnce)
        { 
            attackStartOnce = true;
            if (attackStart != null)
            {
                StopCoroutine(attackStart);
            }
        }
    }
    
    public void DestroySelf()
    {
        enemyHealthManager.DestroySelf();
    }
}

