using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

public class LuaBehaviour : MonoBehaviour
{
    [CSharpCallLua]
    public delegate void LuaObjectAction(object luaObject,params object[] args);
    public LuaObjectAction _Awake;
    public LuaObjectAction _Start;
    public LuaObjectAction _Update;
    XLua.LuaTable table;
    public string luascriptsName;

    public object[] args = null;

    private void Awake()
    {
        if (luascriptsName!="")
        {
            table = loadDelegate();
            args = new object[1];
            args[0] = gameObject;
            Init();
        }
    }

    public void Init()
    {
        table.Set("gameObject", gameObject);
        _Awake = table.Get<LuaObjectAction>("Awake");
        _Start = table.Get<LuaObjectAction>("Start");

        _Update = table.Get<LuaObjectAction>("Update");
        if (_Awake != null)
        {
            if (args != null)
            {
                _Awake(table, args);
            }
            else
            {
                _Awake(table);
            }
        }
    }

    private void Start()
    {
        if (_Start!=null)
        {
            if (args!=null)
            {
                _Start(table,args);
            }
            else
            {
                _Start(table);
            }
        }
    }
    private void Update()
    {
        if (_Update != null)
        {
            if (args != null)
            {
                _Update(table, args);
            }
            else
            {
                _Update(table);
            }
        }
    }

    public LuaTable loadDelegate()
    {
        if (!string.IsNullOrEmpty(luascriptsName) && LuaController.Luaenv != null)
        {

            object[] objs = LuaController.Luaenv.DoString(LuaController.lf.LoadLua(ref luascriptsName), luascriptsName);

            if (objs != null && objs.Length > 0)
            {
                return objs[0] as LuaTable;
            }
            Debug.LogError(string.Format("Do file '{0:s}' failed", luascriptsName));
        }
        return null;
    }

}
