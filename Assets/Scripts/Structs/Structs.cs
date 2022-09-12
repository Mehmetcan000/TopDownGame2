using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BulletOptions
{
    public float speed;
    public int damageToGive;
    public float bulletTime;
    public int damageMultiplier;


    public BulletOptions(float speed, int damageToGive, int damageMultiplier, float bulletTime)
    {
        this.speed = speed;
        this.damageToGive = damageToGive;
        this.bulletTime = bulletTime;
        this.damageMultiplier = damageMultiplier;
    }
    public int CurrentDamage()
    {
        return damageToGive * damageMultiplier;
    }

}

[System.Serializable]
public struct GunOptions
{
    public bool isFiring;
    public float timeBetweenShots; 
    public int maxAmmo;
    public int currentAmmo;
    public int reloadTime;

    public GunOptions(bool isFiring,float timeBetweenShots,int maxAmmo,int currentAmmo,int reloadTime)
    { 
        this.isFiring = isFiring;
        this.timeBetweenShots = timeBetweenShots;
        this.maxAmmo = maxAmmo;
        this.currentAmmo = currentAmmo;
        this.reloadTime = reloadTime;   
    }




}