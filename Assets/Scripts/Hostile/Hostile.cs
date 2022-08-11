using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hostile : MonoBehaviour
{
    public float MaxHp;
    [SerializeField] float Hp;

    private void Start()
    {
        Hp = MaxHp;
    }

    public virtual void OnHit(float damage, Transform target)
    {
        Hp -= damage;

        if(Hp <= 0)
        {
            // destroy action
        }
    }

}
