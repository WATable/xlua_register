using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : BaseLoad
{
    public static GameObject Load(string fillname)
    {
        return Resources.Load<GameObject>("prefabs/" + fillname);
    }

    
}
