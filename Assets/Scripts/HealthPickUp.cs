using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthToGive=100;  
    private void Update()
    {
        transform.Rotate(Vector3.up, .4f);
    }
}
