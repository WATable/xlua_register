using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public interface IEventHandler
{
    string[] listEvent { get; }
    void OnEvent<T>(string type, T data);
}


public class Dispatcher
{
    static Dispatcher instance;

    public static Dispatcher Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Dispatcher();
            }
            return instance;
        }
    }
    private Dispatcher() { }

    Dictionary<string, HashSet<UnityAction<string,object>>> eventDic = new Dictionary<string, HashSet<UnityAction<string, object>>>();
    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="type"></param>
    /// <param name="handler"></param>
    public void AddListener(string type, UnityAction<string, object> handler)
    {
        if (eventDic.ContainsKey(type))
        {
            if (eventDic[type] == null)
            {
                eventDic[type] = new HashSet<UnityAction<string, object>>();
            }
            eventDic[type].Add(handler);
        }
        else
        {
            eventDic.Add(type,new HashSet<UnityAction<string, object>>() { handler});
        }
    }

    public void AddListener(string[] list,UnityAction<string,object> handler)
    {
        for (int i = 0; i < list.Length; i++)
        {
            AddListener(list[i],handler);
        }
    }

    /// <summary>
    /// 移除类型的监听
    /// </summary>
    /// <param name="type"></param>
    public void RemoveListener(string type)
    {
        if (eventDic.ContainsKey(type))
        {
            eventDic.Remove(type);
        }
    }

    /// <summary>
    /// 移除监听
    /// </summary>
    /// <param name="handler"></param>
    public void RemoveListener(UnityAction<string, object> handler)
    {

        foreach (var item in eventDic)
        {
            if (item.Value!=null)
            {
                if (RemoveSet(item.Value,handler))
                {
                    item.Value.Remove(handler);
                    break;
                }
            }
        }
    }

    public bool RemoveSet(HashSet<UnityAction<string, object>> hashset, UnityAction<string, object> target)
    {
        foreach (var set in hashset)
        {
            if (set == target)
            {
                return true;
            }
        }
        return false;
    }



    public void DispatchEvent<T>(string type,T data)
    {
        if (eventDic.ContainsKey(type))
        {
            if (eventDic[type]!=null || eventDic[type].Count >0)
            {
                foreach (var item in eventDic[type])
                {
                    item(type,data);
                }
            }
        }
        else
        {
            Debug.Log(string.Format("事件 {0} 无监听",type));
        }

    }
}
