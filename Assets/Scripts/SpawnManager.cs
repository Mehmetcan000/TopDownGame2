using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerUpPrefab;
    public GameObject[] spawnPoint;

    public List<GameObject> enemyList;
    
    private int enemiesInWave=2;
    private RoomManager currentRoomManager;
    public void SetRoomData(GameObject[] enemyPrefab,GameObject[] spawnPoint,RoomManager roomManager)
    {
      this.enemyPrefab = enemyPrefab;   
      this.spawnPoint = spawnPoint;
      currentRoomManager = roomManager;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
   

        for (int i = 0; i < enemiesToSpawn; i++)
        {

            GameObject enemy = Instantiate(GetRandomFromList(enemyPrefab), GetRandomFromList(spawnPoint).transform.position, Quaternion.identity);
            
            enemy.GetComponent<EnemyHealthManager>().spawnManager = this;
            enemyList.Add(enemy);
        }


    }
    public  void RemoveFromList(GameObject enemy)
    {
        enemyList.Remove(enemy);
        EnemyListCount();
    }
 

    public void EnemyListCount()
    {

        if (enemyList.Count == 0)
        {
            currentRoomManager.LevelControl();
        }
    }

    public void StartWave()
    {
        SpawnEnemyWave(enemiesInWave * currentRoomManager.CurrentWave);
    }

    public GameObject GetRandomFromList(GameObject[] array)
    {
        return array[Random.Range(0, array.Length )];
    }
  
}
