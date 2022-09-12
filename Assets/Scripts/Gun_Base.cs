using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun_Base : MonoBehaviour
{
    public BulletController bullet;
    public Transform firePoint;
    public bool isReloading = false;
    private float shotCounter;
    public BulletOptions bulletOptions;
    public GunOptions gunOptions;
    public string soundGunFire;
    public string reloadSoundName;




    private void OnEnable()
    {
        Invoke("MaxAmmo", .2f);
       
    }

    public void MaxAmmo()
    {
        UIManager.instance.SetGunMaxAmmo(gunOptions.maxAmmo);
    }
    private void Start()
    {
       gunOptions.currentAmmo =gunOptions.maxAmmo;
        if (gunOptions.currentAmmo == 0)
        {
            gunOptions.currentAmmo = gunOptions.maxAmmo;
        }
    }
    public virtual void Shoot()
    {
          if (gunOptions.isFiring)
          {  //Ateþ Ettiðimiz zaman çalýþacaklar..
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0 && gunOptions.currentAmmo > 0)
            {
                shotCounter = gunOptions.timeBetweenShots;
                AudioManager.instance.Play(soundGunFire);
                
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<BulletController>();
                newBullet.bulletOptions = bulletOptions;         
                gunOptions.currentAmmo--;
                UIManager.instance.SetGunCurrentText(gunOptions.currentAmmo);
                
            }
            else if (gunOptions.currentAmmo == 0 && !isReloading )
            {
                gunOptions.isFiring = false;
                StartCoroutine(Reload());
                return;      
            }
          }
         else
         {
           shotCounter -= Time.deltaTime;       
         }   
    }
   
    
    public virtual IEnumerator Reload()
    {
        
        isReloading = true;
        AudioManager.instance.Play(reloadSoundName);
        UIManager.instance.ReloadingText(isReloading);
        yield return new WaitForSeconds(gunOptions.reloadTime);
        gunOptions.currentAmmo = gunOptions.maxAmmo;
        UIManager.instance.SetGunCurrentText(gunOptions.currentAmmo);
        isReloading = false;
        UIManager.instance.ReloadingText(isReloading);

    }
}
