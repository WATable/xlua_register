using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public static class GameObjectExt
{


    public static void AddScripts(this GameObject target, string classname, string reflect = "CS")
    {
        AssemblyName name = new AssemblyName(reflect);

        var result = Assembly.Load(name);

        target.AddComponent(result.GetType(reflect + "." + classname));

    }
}
