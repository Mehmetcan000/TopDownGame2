using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed=15f;
    private Rigidbody playerRb;


    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public Gun_Base currentGun;
    public LayerMask layerMask;
    public Gun_Base[] gunList;


    public GameObject powerUpIndicator;

    public PlayerHealthManager healthManager;
    

 


    
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            PowerUp powerUp=other.GetComponent<PowerUp>();
            
            StartCoroutine(PowerUpDamage(powerUp.damageMultipier,powerUp.powerTime));
            
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("HealthPickUP"))
        {
            HealthPowerUp(other.GetComponent<HealthPickUp>().healthToGive);
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("WeaponPickUp"))
        {
            SetCurrentGun(other.GetComponent<WeaponPickUp>().weaponSwitch);
            Destroy(other.gameObject);  
        }
    }
   
    public IEnumerator PowerUpDamage(int damage,int powerTime)
    {
        powerUpIndicator.gameObject.SetActive(true);
        currentGun.bulletOptions.damageMultiplier =damage;
        yield return new WaitForSeconds(powerTime);
        currentGun.bulletOptions.damageMultiplier = 1;
        powerUpIndicator.gameObject.SetActive(false);
    }

    public void HealthPowerUp(int health)
    {
        healthManager.GiveHealth(health);
    }  
    void Update()
    {
        RotatePlayer();
        MovePlayer();
     
        if (Input.GetMouseButtonDown(0))
        {
            currentGun.gunOptions.isFiring = true;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            currentGun.gunOptions.isFiring = false;
           


        }
        powerUpIndicator.transform.position = transform.position + new Vector3(0, 0.5f,0);
    }
    

    private void RotatePlayer()
    {
       gameObject.transform.LookAt(GetMousePosition()); 
    }
    private void MovePlayer()
    {
      
      moveInput = new Vector3(Input.GetAxisRaw("Vertical"), 0f, -Input.GetAxisRaw("Horizontal"));
      moveVelocity = moveInput * moveSpeed;
      playerRb.velocity = moveVelocity;
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit , Mathf.Infinity ,layerMask))
        {     
            return hit.point;   
        }
        return Vector3.zero;
    }

    public void SetCurrentGun(int i)
    {
       
        if (i<gunList.Length)
        {
            currentGun.gameObject.SetActive(false);
            currentGun = gunList[i];
            currentGun.gameObject.SetActive(true);
        }
    }

    
}
