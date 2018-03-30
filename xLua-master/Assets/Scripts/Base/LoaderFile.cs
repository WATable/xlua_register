using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 加载文本
/// </summary>
public class LoaderFile : BaseLoad
{
    public override byte[] Load(ref string fillName)
    {
        return base.Load(ref fillName);
    }

    public byte[] LoadLua(ref string fillName)
    {
        string fill = fillName.Replace('.', '/') + ".lua";
        return Load(ref fill);
    }
    public byte[] LoadText(ref string fillName)
    {
        string fill = fillName.Replace('.', '/') + ".txt";
        return Load(ref fill);
    }

    public byte[] LoadBytes(ref string fillName)
    {
        string fill = fillName.Replace('.', '/') + ".lua.bytes";
        return Load(ref fill);
    }

}
