using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : EnemyAttack 
{
    private float shotCounter;
     
    public EnemyBullet bullet;
    public float bulletSpeed;

    public float timeBetweenShots;

    public Transform firePoint;

    private void Awake()
    {
        attackStart = Shoot();
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
        if (currentAmmo == 0)
        {
            currentAmmo = maxAmmo;
        }
    }
  
 
    private void Update()
    {
        
    }
    public IEnumerator Shoot()
    {
       
        
      
        while (true)
        {
            if (isAttack)
            {  
                //Ateþ Ettiðimiz zaman çalýþacaklar..
                shotCounter -= .1f ;
                if (shotCounter <= 0 && currentAmmo > 0)
                {          
                    shotCounter = timeBetweenShots;
                    EnemyBullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as EnemyBullet;
                    newBullet.speed = bulletSpeed;
                    newBullet.damageToGive = damage;
                    currentAmmo--;

                }
                else if (currentAmmo == 0)
                {
                    StartCoroutine(Reload());
                }
            }
            else
            {
                shotCounter -= .1f;
            }
            yield return new WaitForSeconds(.1f);
        }
         
    }
    public override void Attack(bool canAttack)
    {
      isAttack = canAttack; 

    }
    public  IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
