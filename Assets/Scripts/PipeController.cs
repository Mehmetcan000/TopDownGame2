using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    public int damage;
    public float spawnTime;

    public EnemyBullet bullet;

    public void Spawn()
    {

        EnemyBullet newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation).GetComponent<EnemyBullet>();
        newBullet.damageToGive = damage;
    }
    private void Start()
    {
        InvokeRepeating("Spawn", 1f,spawnTime);
        
    }

    






}
