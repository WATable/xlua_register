using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XLua;

public class LuaController : Singleton<LuaController>
{
    static LuaEnv luaenv;
    public static LoaderFile lf;
    public static LuaEnv Luaenv
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
    protected override void Awake()
    {
        base.Awake();
        Luaenv.DoString("require 'base.init'");
    }


}
