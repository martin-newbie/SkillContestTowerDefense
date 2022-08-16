using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [Header("UI Objects")]
    public TurretConstruct TurretConstructUI;

    public void OnPointerDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Tower")))
        {
            TurretTower tower = hit.transform.GetComponent<TurretTower>();

            if (!tower.turretExsist)
            {
                InGameManager.Instance.SelectedTower = tower;

                TurretConstructUI.gameObject.SetActive(true);
            }
            else
            {
                if (tower.thisTurret.UpgradeAble)
                {
                    // open upgrade
                }
                else
                {
                    // open status
                }
            }
        }
    }
}
