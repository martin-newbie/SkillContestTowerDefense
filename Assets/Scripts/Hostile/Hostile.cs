using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hostile : MonoBehaviour
{
    public float MaxHp;
    [SerializeField] float Hp;
    [SerializeField] float speed;
    [SerializeField] Transform[] Path;
    [SerializeField] float checkRadius;

    int curPathIdx;
    Transform curPathNode;
    bool isActive = false;

    private void Start()
    {
        Hp = MaxHp;
    }

    private void Update()
    {
        if (!isActive) return;

        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (curPathIdx < Path.Length - 1)
        {
            if (Vector3.Distance(Path[curPathIdx + 1].position, transform.position) < checkRadius)
            {
                curPathIdx++;
                curPathNode = Path[curPathIdx];
                transform.position = curPathNode.position;
                transform.rotation = curPathNode.rotation;
            }
        }
        else
        {
            InGameManager.Instance.HP--;
            Destroy(gameObject);
        }
    }

    public virtual void OnHit(float damage, Transform target)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            InGameManager.Instance.coin++;
            Destroy(gameObject);
            // destroy action
        }
    }

    public void InitPath(Transform[] path)
    {
        Path = path;
        isActive = true;
        curPathNode = path[curPathIdx];
    }
}
