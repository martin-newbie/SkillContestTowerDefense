using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTurret : TurretBase
{
    [Header("Moartar Turret")]
    public float attackDelay;
    public Transform spawnPos;
    public MortarBall ball;
    float curDelay;
    Animator anim;

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
        if(curDelay >= attackDelay)
        {
            Hostile temp = GetNearestHostile();

            if(temp != null)
            {
                anim.SetTrigger("AttackTrigger");
                MortarBall m = Instantiate(ball, spawnPos.position, Quaternion.identity);
                m.Init(spawnPos, temp.transform, 1f);
            }

            curDelay = 0f;
        }

        curDelay += Time.deltaTime;
    }

}
