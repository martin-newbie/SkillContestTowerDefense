using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretContainer : MonoBehaviour
{
    public TurretBase thisTurret;
    public RawImage turretImage;

    TurretConstruct manager;

    public void Init(TurretConstruct manager)
    {
        this.manager = manager;
    }

    public void ChooseTurret() // button
    {
        TurretTower tower = InGameManager.Instance.SelectedTower;
        if(tower != null)
        {
            TurretBase turretTemp = Instantiate(thisTurret, tower.spawnPoint.position, Quaternion.identity);
            turretTemp.enabled = true;
            tower.thisTurret = turretTemp;

            manager.Close();
            tower.turretExsist = true;
        }
    }
}
