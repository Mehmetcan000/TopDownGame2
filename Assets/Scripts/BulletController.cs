using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public BulletOptions bulletOptions;
    public GameObject fx;



    void Start()
    {
        Invoke("DestroyBullet", bulletOptions.bulletTime);
    }  
    void Update()
    {
        transform.Translate(Vector3.forward * bulletOptions.speed * Time.deltaTime);  
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<IDamage>().ITakeDamage(bulletOptions.CurrentDamage());       
        }
        DestroyBullet();
    }
    void DestroyBullet()
    {

        Instantiate(fx, transform.position, Quaternion.identity);
        Destroy(gameObject);


    }
}
