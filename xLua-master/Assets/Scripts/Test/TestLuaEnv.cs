using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class TestLuaEnv : MonoBehaviour
{
    private void Start()
    {
        List<LuaEnv.CustomLoader> loaders = LuaController.Luaenv.customLoaders;
    }

}
