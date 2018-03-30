using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XLua;

public class LuaController : MonoBehaviour
{
    static LuaEnv luaenv;
    LoaderFile lf;
    public LuaEnv Luaenv
    {
        get
        {
            if (luaenv == null)
            {
                luaenv = new LuaEnv();

                lf = new LoaderFile();
                luaenv.AddLoader(lf.LoadLua);
            }
            return luaenv;
        }
    }
 
    public static LuaController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject g = new GameObject("LuaController");
                instance = g.AddComponent<LuaController>();

                g.AddComponent<DonDestroyLoad>();
            }
            return instance;
        }
    }

    static LuaController instance;




    private void Awake()
    {
        Luaenv.DoString("require 'init'");
    }
}
