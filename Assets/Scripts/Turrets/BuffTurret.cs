using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTurret : TurretBase
{
    [Header("BuffTurret")]
    public MeshRenderer buffEffect;
    Vector2 materialOffset;

    private void Start()
    {
        materialOffset.x = 1;
    }

    private void Update()
    {
        BuffEffectMove();
    }

    void BuffEffectMove()
    {
        if (materialOffset.x >= -1f)
            materialOffset.x -= Time.deltaTime;
        else
            materialOffset.x = 1f;

        buffEffect.material.SetTextureOffset("_MainTex", materialOffset);
    }
}
