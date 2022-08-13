using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LaserTurret : TurretBase
{
    [Header("Laser Turret")]
    public int enemyCount;
    public Transform attackPos;
    public LineRenderer[] Lasers;

    private void Update()
    {
        var near = GetNearMonsters();

        for (int i = 0; i < enemyCount; i++)
        {
            if (i < near.Count)
            {
                Lasers[i].SetPosition(0, attackPos.position);
                Lasers[i].SetPosition(1, near[i].transform.position);
                Lasers[i].transform.LookAt(near[i].transform);

                near[i].OnHit(damage * Time.deltaTime, transform);
            }
            else
            {
                Lasers[i].SetPosition(0, attackPos.position);
                Lasers[i].SetPosition(1, attackPos.position);

            }
        }
    }

    List<Hostile> GetNearMonsters()
    {
        List<Hostile> result = new List<Hostile>();
        GetNearby();

        var order = from item in nearbyHostile
                    orderby Vector3.Distance(item.transform.position, transform.position)
                    select item;

        var arr = order.ToArray();
        for (int i = 0; i < arr.Length; i++)
        {
            result.Add(order.ToArray()[i]);
        }

        return result;
    }
}
