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

    int hp;
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if(hp <= 0)
            {
                // gameover
                Debug.Log("Game Over");
            }
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnDummy());
    }

    public EXPBar SpawnExp(TurretBase turret)
    {
        EXPBar temp = Instantiate(expPrefab, canvasRT);
        temp.Init(turret, canvasRT);
        temp.transform.SetAsFirstSibling();
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
