using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretConstruct : MonoBehaviour
{
    public TurretContainer[] turretButtons;

    private void Start()
    {
        foreach (var item in turretButtons)
        {
            item.Init(this);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
