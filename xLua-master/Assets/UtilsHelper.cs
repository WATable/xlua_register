using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class UtilsHelper
{


    public static string Print<T>(T value)
    {
        Type type = typeof(T);


        string name = type.Name;

        string source = "";

        source += "data type : " + name + "\n";


        foreach (MemberInfo mi in type.GetMembers())
        {
            Debug.Log(string.Format("{0}/t{1}", mi.MemberType, mi.Name));
        }

        return source;
    }
}
