using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
    public Text level;
    public Image gauge;
    public Vector3 offset;
    TurretBase turret;
    RectTransform canvasRT;

    public void Init(TurretBase target, RectTransform canvasRT)
    {
        turret = target;
        this.canvasRT = canvasRT;
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(turret.transform.position + offset);
        transform.position = pos;
        gauge.fillAmount = turret.Exp / turret.maxExp;
        level.text = (turret.level + 1).ToString();
    }
}
