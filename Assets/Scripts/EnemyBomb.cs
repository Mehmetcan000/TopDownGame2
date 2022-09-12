using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : EnemyAttack
{
    private bool attackOnce = true;
    public override void Attack(bool canAttack)
    {
        if (attackOnce && canAttack)
        {
            attackOnce = false;
            AudioManager.instance.Play("Bomber");
            anim.SetBool("die", true);
            Invoke("DestroySelf", 1.5f);
        }
    }
}
