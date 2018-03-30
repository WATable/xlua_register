using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public static class CustomSetting
{
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>()
    {
        typeof(UnityEngine.GameObject),
        typeof(UnityEngine.UI.Button),
        typeof(UnityEngine.UI.Button.ButtonClickedEvent),
        typeof(UnityEngine.UI.Text),
    };

    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>()
    {
        typeof(UnityEngine.Events.UnityAction),
        typeof(UnityEngine.Events.UnityAction<bool>),
        typeof(UnityEngine.Events.UnityAction<float>),
        typeof(UnityEngine.Events.UnityAction<string>),
    };

    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()
    {

    };
}
