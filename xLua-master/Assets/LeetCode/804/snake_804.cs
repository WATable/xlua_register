using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_804
{
    public static string[] mima = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

    public static int GetSame(string[] words)
    {
        List<string> set = new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            string str = "";

            for (int j = 0; j < words[i].Length; j++)
            {
                char s = words[i][j];

                str += mima[(char.ToLower(s) - 'a')];
            }
            if (!set.Contains(str))
            {
                set.Add(str);
            }
        }



        return set.Count;
    }
}
