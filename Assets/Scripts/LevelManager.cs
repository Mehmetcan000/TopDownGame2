using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;

    public delegate void LevelSystem();
   
    public static event LevelSystem OnNewLevel;

    
    public int startWave = 1;
    public int maxWave=3;
    public int currentWave;
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
        NewLevel();    
    }

    public virtual void LevelControl()
    {
        Debug.Log("End Level");
        currentWave++;
        if(currentWave >= maxWave)
        {
            //KAPIYI AÇ.ÝLK ROOM
            //KAPIYI AÇ. ÝKÝNCÝ ROOM
            //OYUNU BÝTÝR. ÜÇÜNCÜ ROOM

        }
        else
        {
            NewLevel();
        }
    }
    void NewLevel()
    {
        Debug.Log("Start Level");
        OnNewLevel();//SpawnPowerups
        spawnManager.StartWave();
    }
}
