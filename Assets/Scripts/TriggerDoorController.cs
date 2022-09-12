using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    public bool lastCloseTrigger= false;    
    public RoomManager roomManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                AudioManager.instance.Play("Door");
                myDoor.SetBool("open", true);          
            }
            else if (closeTrigger)
            {
                AudioManager.instance.Play("Door");
                myDoor.SetBool("open", false);
                if (roomManager !=null)
                {
                    roomManager.StartWave();
                }
                gameObject.SetActive(false);
            }
        }
    }
}
