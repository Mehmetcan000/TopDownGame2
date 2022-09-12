using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager :MonoBehaviour
{

    [SerializeField] private SpawnManager spawnManager;

    public delegate void LevelSystem();

    public static event LevelSystem OnNewLevel;

    public int startWave = 1;
    public int maxWave = 3;
    public int currentWave;

   
    public GameObject[] enemyPrefab;
    public GameObject[] spawnPoint;
    public bool startOnPlay=false;
    public bool lastRoom=false;
    

    [SerializeField] private GameObject doorTrigger;
    [SerializeField] private TriggerDoorController closeDoor;


    public int CurrentWave
    {
        get { return currentWave; }
    }

    private void Awake()
    {
        currentWave = startWave;
        
    }

    private void Start()
    {
      
        if (startOnPlay)
        { 
            StartWave();
        }
    }

    public void StartWave()
    {
        spawnManager.SetRoomData(enemyPrefab, spawnPoint, this);
        NewLevel();     
    }

    public virtual void LevelControl()
    {
       
        Debug.Log("End Level");
        
        currentWave++;
        
        if (currentWave > maxWave)
        {
            doorTrigger.SetActive(true);
            if (lastRoom)
            {
                GameManager.instance.MissionComplete();
            }
        }
        else
        {
            NewLevel();
        }
    }
    void NewLevel()
    {
        Debug.Log("Start Level");
        UIManager.instance.CurrentLevelText(currentWave);
        PowerUpSpawn(); //SpawnPowerups
        spawnManager.StartWave();
        startOnPlay=true;  
        
    }

    public void PowerUpSpawn()
    {
        if (currentWave%2==0 ||currentWave==1)
        {
            OnNewLevel();
        }
        
    }
}
