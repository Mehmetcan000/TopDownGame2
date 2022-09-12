using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public int weaponSwitch;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up, .4f);
    }


}
