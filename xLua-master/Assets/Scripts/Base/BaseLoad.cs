using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class BaseLoad : ILoadInterface,ILoadCompoent
{
    public virtual byte[] Load(ref string fillName)
    {
        string filePath = SnakeUtils.Root + fillName;             // lua文件的实际路径
        fillName = fillName.Replace('.', '/');     // 返给lua调试器的路径，不用调试lua的就不用管这个了
        try
        {
            // File.ReadAllBytes返回值可能会带有BOM（0xEF，0xBB，0xBF），这会导致脚本加载出错（<\239>）
            byte[] script = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(filePath));
            return script;
        }
        catch
        {
            return null;
        }
    }

    public void LoadBehaviour(string compoent)
    {
        GameObject g;
        //g.AddComponent
    }

    public virtual GameObject Loadprefab(string fillName)
    {
        return null;
    }


}
