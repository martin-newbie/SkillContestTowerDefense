using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLine : MonoBehaviour
{
    public LineRenderer line;

    public float offsetX;
    public float speed;

    private void Update()
    {
        offsetX -= Time.deltaTime;
        line.material.SetTextureOffset("_MainTex", new Vector2(offsetX * speed, 0));
    }
}
