using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance = null;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if(instance == null)
                {
                    GameObject t = new GameObject(typeof(T).Name);
                    instance = t.AddComponent<T>();
                }
            }

            return instance;
        }
    }

}
