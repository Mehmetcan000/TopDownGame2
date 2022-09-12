using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    public int damageToGive;

    public GameObject fx;
    
    void Start()
    {
        Invoke("DestroyBullet", 3f);

    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<IDamage>().ITakeDamage(damageToGive);
            
        }
        DestroyBullet();
        
    }
    void DestroyBullet()
    {
        Instantiate(fx, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
