using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int damageMultipier;
    public int powerTime;
   
    void Update()
    {
        transform.Rotate(Vector3.up, .4f);
    }
}
