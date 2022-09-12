using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    GameObject spawnedPowerUp;   
    public GameObject powerUpPrefab;

    [SerializeField] Vector3 powerUpOffset;

    private bool doOnce= true;

    
    private void OnEnable()
    {
        RoomManager.OnNewLevel += Spawn;
    }
    private void OnDisable()
    {
        RoomManager.OnNewLevel -= Spawn;
    }

    public void Spawn()
    {
        if(spawnedPowerUp == null )
        {
            if (!powerUpPrefab.CompareTag("WeaponPickUp"))
            {
                spawnedPowerUp = Instantiate(powerUpPrefab, gameObject.transform.position + powerUpOffset, powerUpPrefab.transform.rotation);
            }
            else if (powerUpPrefab.CompareTag("WeaponPickUp") && doOnce)
            {
                spawnedPowerUp = Instantiate(powerUpPrefab, gameObject.transform.position + powerUpOffset, powerUpPrefab.transform.rotation);
                doOnce = false; 
            }  
        } 
    }
   
}
