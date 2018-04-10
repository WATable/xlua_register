using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 宝石与石头答案
/// </summary>
public class snake_771
{
    /// <summary>
    /// 判断石头里有多少字符串
    /// </summary>
    /// <param name="bs">宝石</param>
    /// <param name="st">石头</param>
    /// <returns></returns>
    public static int NumJewelsInStones(string bs, string st)
    {
        int count = 0;
        for (int i = 0; i < bs.Length; i++)
        {
            for (int j = 0; j < st.Length; j++)
            {
                if (bs[i] == st[j]) count++;
            }
        }
        return count;
    }
}