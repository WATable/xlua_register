using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ʯ��ʯͷ��
/// </summary>
public class snake_771
{
    /// <summary>
    /// �ж�ʯͷ���ж����ַ���
    /// </summary>
    /// <param name="bs">��ʯ</param>
    /// <param name="st">ʯͷ</param>
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