using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public PlayerController playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public NavMeshAgent navMeshAgent;

    public float aggroRadius;
    public float attackRadius;

    private Rigidbody enemyRb;
    public float moveSpeed;

    public UIHealthBar updateLocation;
    public EnemyAttack enemyAttack;
  
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();    
        navMeshAgent = GetComponent<NavMeshAgent>();    
        playerRef = FindObjectOfType<PlayerController>();
        StartCoroutine(FOVRoutine());
        
    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return wait;
            if (FieldOfViewCheck(aggroRadius) && !FieldOfViewCheck(attackRadius))
            {
                navMeshAgent.destination = (playerRef.transform.position);
                enemyAttack.AttackStart();   
            }
            else if (!FieldOfViewCheck(aggroRadius))
            {
                enemyAttack.AttackStop();
            }

            if (FieldOfViewCheck(attackRadius))
            {
                updateLocation.updateBarLocation = false;
                enemyAttack.Attack(true);
                transform.rotation = Quaternion.LookRotation(playerRef.transform.position - transform.position);
            }
            else
            {
                enemyAttack.Attack(false);
            }
               
            updateLocation.updateBarLocation = true;
        }
    }

    public  bool FieldOfViewCheck(float radius)
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);


        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                   
                  canSeePlayer = true;
                    return true;
                }
                else { 
            canSeePlayer = false;
                return false ;
                }
            }
            else { 
                canSeePlayer = false;
            return false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            return false;
        }
        else
        {
            return false;   
        }
         
    }
 
}
