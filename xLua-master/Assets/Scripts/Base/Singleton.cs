using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static Singleton<T> instance;

    public static Singleton<T> Instance
    {
        get
        {
            if (instance == null)
            {

                instance = new GameObject(typeof(T).Name).AddComponent<Singleton<T>>();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        gameObject.AddComponent<DonDestroyLoad>();
        instance = this;
    }
}
