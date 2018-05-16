using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDispatcher : MonoBehaviour, IEventHandler
{
    public string[] listEvent
    {
        get
        {
            return new string[]
            {
                "test"
            };
        }
    }

    public void OnEvent<T>(string type, T data)
    {
        
    }

    // Use this for initialization
    void Awake()
    {
        TestNum num = new TestNum();
        Dispatcher.Instance.AddListener(listEvent, OnEvent);
    }

    private void Start()
    {
        int a = 0;

        Dispatcher.Instance.DispatchEvent("test", new int[] { 1, 2, 3, 4, 56 });
    }
}


public class TestNum : IEventHandler
{
    public TestNum()
    {
        Dispatcher.Instance.AddListener(listEvent, OnEvent);
    }

    public string[] listEvent
    {
        get
        {
            return new string[] 
            {
                "test"
            };
        }
    }

    public void OnEvent<T>(string type, T data)
    {
        if (type == "test")
        {
            int[] temp = data as int[];
            for (int i = 0; i < temp.Length; i++)
            {
            }
        }
    }
}