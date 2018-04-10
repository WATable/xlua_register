using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildAssetBoudleName
{
    public static string assetpath = Application.dataPath+ "AssetBoudle";
    [MenuItem("Tools/Named Asset Bundle")]
    public static void NamedAssetBundleName()
    {
        List<string> bundles = new List<string>();

        GetDirs(assetpath,ref bundles);
    }
    private static void GetDirs(string dirPath, ref List<string> dirs)
    {
        foreach (string path in Directory.GetFiles(dirPath))
        {
            //获取所有文件夹中包含后缀为 .prefab 的路径  
            if (System.IO.Path.GetExtension(path) == ".prefab")
            {
                string strTempPath = path.Substring(path.IndexOf("Assets")).Replace(@"\", "/");
                dirs.Add(strTempPath);
                Debug.Log(strTempPath);
            }
        }

        if (Directory.GetDirectories(dirPath).Length > 0)  //遍历所有文件夹  
        {
            foreach (string path in Directory.GetDirectories(dirPath))
            {
                GetDirs(path, ref dirs);
            }
        }
    }
}
