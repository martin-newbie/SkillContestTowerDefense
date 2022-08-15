using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBall : MonoBehaviour
{

    Transform target;
    Vector3 start;
    Vector3 end;

    float anim;
    float delay;

    public void Init(Transform startPos, Transform endPos, float time)
    {
        start = startPos.position;
        target = endPos;
        delay = time;
        end = target.position;
    }

    void Update()
    {
        delay -= Time.deltaTime;

        if (delay <= 0f)
        {
            Destroy(gameObject);
            // explosion and destroy
            return;
        }


        anim += Time.deltaTime;
        anim = anim % 5;

        transform.position = MathParabola.Parabola(start, end, 5f, anim);
    }

}
