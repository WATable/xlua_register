using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadInterface
{
    /// <summary>
    /// 加载文本
    /// </summary>
    /// <param name="fillName"></param>
    /// <returns></returns>
    byte[] Load(ref string fillName);

    GameObject Loadprefab(string fillName);
}

