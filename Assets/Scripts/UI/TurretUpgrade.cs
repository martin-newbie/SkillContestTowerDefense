using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgrade : MonoBehaviour
{
    TurretBase thisTurret;
    public Text progressTxt;
    public Text costTxt;
    public Text nameTxt;
    bool isUpgradeAble => InGameManager.Instance.coin >= thisTurret.cost[thisTurret.level];

    public void Init(TurretBase turret, string name)
    {
        thisTurret = turret;
        nameTxt.text = name;
        costTxt.text = string.Format("{0:0,#}", turret.cost[thisTurret.level]);
    }

    void Update()
    {
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

        gameObject.SetActive(false);
    }

}
