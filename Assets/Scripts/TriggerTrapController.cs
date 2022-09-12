using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapController : MonoBehaviour
{
    [SerializeField]
    private Animator myTrap = null;

    [SerializeField]
    private bool openTrap = false;
    [SerializeField]
    private bool closeTrap = false;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            if (openTrap)
            {
                AudioManager.instance.Play("Trap");
                myTrap.SetBool("openTrap", true);
                gameObject.SetActive(false);
            }
            if (closeTrap)
            {
                myTrap.SetBool("openTrap", false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
