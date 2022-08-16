using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    public Transform[] Path;
    public TurretTower SelectedTower;
    public Hostile dummy;
    public RectTransform canvasRT;
    public EXPBar expPrefab;

    public int coin;

    private void Start()
    {
        StartCoroutine(SpawnDummy());
    }

    public EXPBar SpawnExp(TurretBase turret)
    {
        EXPBar temp = Instantiate(expPrefab, canvasRT);
        temp.Init(turret, canvasRT);
        return temp;
    }

    IEnumerator SpawnDummy()
    {
        while (true)
        {
            SpawnHostile(dummy);
            yield return new WaitForSeconds(1f);
        }
    }

    public Hostile SpawnHostile(Hostile hostile)
    {
        Hostile temp = Instantiate(hostile, Path[0].position, Path[0].rotation);
        temp.InitPath(Path);
        return temp;
    }
}
