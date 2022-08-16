using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretStatus : MonoBehaviour
{
    TurretBase thisTurret;
    public Text NameTxt;
    public Image EXPGauge;
    public Text DamageTxt;
    public Text LevelTxt;
    public Text RangeTxt;
    public Text CostTxt;

    public void Init(TurretBase turret)
    {
        thisTurret = turret;

        NameTxt.text = thisTurret.name;
        EXPGauge.fillAmount = thisTurret.Exp / thisTurret.maxExp;
        DamageTxt.text = "DMG: " + string.Format("{0:0}", thisTurret.damage);
        LevelTxt.text = "Lv: " + thisTurret.level.ToString();
        RangeTxt.text = "Range: " + string.Format("{0:0}", thisTurret.checkRadius);
        CostTxt.text = "Cost: " + string.Format("{0:0}", thisTurret.cost[thisTurret.level]);
    }


}
