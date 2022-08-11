using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : TurretBase
{
    [Header("GunTurret")]
    public float attackDelay;
    float curDelay;
    Animator anim;
    bool isLeft = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        FollowTarget();
        AttackLogic();
    }

    void AttackLogic()
    {
        if (curDelay >= attackDelay)
        {
            Hostile enemy = GetNearestHostile();
            if(enemy != null)
            {
                if (isLeft) anim.SetTrigger("LeftFire");
                else anim.SetTrigger("RightFire");
                isLeft = !isLeft;

                enemy.OnHit(damage, transform);
            }

            curDelay = 0f;
        }
        curDelay += Time.deltaTime;
    }

}
