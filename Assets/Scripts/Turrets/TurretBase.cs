using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretBase : MonoBehaviour
{
    [Header("Level Objects")]
    public GameObject[] LevelArmor;
    public GameObject[] LevelBase;

    [Header("Tower System")]
    public float checkRadius;
    public float damage;
    public Transform body; // rotate able
    Hostile target = null;
    public int level;
    public bool UpgradeAble => exp >= maxExp && level < 2;

    public int[] cost = new int[3];

    float exp;
    public float Exp
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }
    public float maxExp => 50f + level * 50f;

    [HideInInspector] public List<Hostile> nearbyHostile = new List<Hostile>();
    EXPBar thisBar;
    private void Awake()
    {
        thisBar = InGameManager.Instance.SpawnExp(this);
        InitObject();
    }

    public void Upgrade()
    {
        if (UpgradeAble)
        {
            InGameManager.Instance.coin -= cost[level];
            exp = 0f;
            level++;

            InitObject();
        }
    }

    void InitObject()
    {
        for (int i = 0; i < 3; i++)
        {
            LevelArmor[i].SetActive(i == level);
            LevelBase[i].SetActive(i == level);
        }
    }

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
