using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretBase : MonoBehaviour
{
    [Header("Tower System")]
    [SerializeField] float checkRadius;
    public float damage;
    public Transform body; // rotate able
    Hostile target = null;

    [HideInInspector] public List<Hostile> nearbyHostile = new List<Hostile>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

    protected void FollowTarget()
    {
        GetNearby();
        Hostile target = GetNearestHostile();

        if (target == null) return;

        Vector3 dir = target.transform.position - transform.position;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        rot.x = 0f;
        rot.z = 0f;

        body.rotation = rot;

    }

    protected List<Hostile> GetNearby()
    {
        List<Hostile> result = new List<Hostile>();

        var nearby = Physics.OverlapSphere(transform.position, checkRadius, LayerMask.GetMask("Hostile"));

        foreach (var item in nearby)
        {
            result.Add(item.GetComponent<Hostile>());
        }


        nearbyHostile = result;
        return result;
    }

    protected Hostile GetNearestHostile()
    {
        if (nearbyHostile.Count <= 0) return null;

        if (target != null && nearbyHostile.Contains(target)) return target;
        else if (target != null && !nearbyHostile.Contains(target)) target = null;

        Hostile result = null;
        float distance = checkRadius;

        foreach (var item in nearbyHostile)
        {
            float _d = Vector3.Distance(item.transform.position, transform.position);
            if (_d < distance)
            {
                distance = _d;
                result = item;
            }
        }

        target = result;
        return result;
    }

}
