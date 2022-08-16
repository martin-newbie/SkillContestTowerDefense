using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [Header("UI Objects")]
    public TurretConstruct TurretConstructUI;
    public TurretUpgrade TurretUpgradeUI;
    public TurretStatus TurretStatusUI;

    public void OnPointerDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200f, LayerMask.GetMask("Tower")))
        {
            SetWindowClose();
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
                    TurretUpgradeUI.gameObject.SetActive(true);
                    TurretUpgradeUI.Init(tower.thisTurret, tower.thisTurret.name);
                }
                else
                {
                    // open status
                    TurretStatusUI.gameObject.SetActive(true);
                    TurretStatusUI.Init(tower.thisTurret);
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SetWindowClose();
    }

    void SetWindowClose()
    {
        TurretConstructUI.gameObject.SetActive(false);
        TurretUpgradeUI.gameObject.SetActive(false);
        TurretStatusUI.gameObject.SetActive(false);
    }
}
