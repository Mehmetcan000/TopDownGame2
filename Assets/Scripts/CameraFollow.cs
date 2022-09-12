using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    Vector3 targetDistance;
    void Start()
    {
        targetDistance = transform.position - target.position;   
    }    
    private void FixedUpdate()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + targetDistance, 0.1f);
        }
    }
}
