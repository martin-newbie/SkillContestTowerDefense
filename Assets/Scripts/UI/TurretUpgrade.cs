using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgrade : MonoBehaviour
{
    TurretBase thisTurret;
    public Text costTxt;
    bool isUpgradeAble => InGameManager.Instance.coin >= thisTurret.cost[thisTurret.level];

    public void Init(TurretBase turret)
    {
        thisTurret = turret;
        costTxt.color = isUpgradeAble ? Color.white : Color.red;
    }

    public void UpgradeButton()
    {
        if (isUpgradeAble)
        {
            thisTurret.Upgrade();
        }
        else
        {
            // error
        }
    }

}
