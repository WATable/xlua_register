using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TwoTreeNode : MonoBehaviour
{
    private void Start()
    {
        int[] nums = TwoSum(new int[] { 3, 2, 4 }, 6);

        //for (int i = 0; i < nums.Length; i++)
        //{
        //    print(i + "  : " + nums[i]);
        //}
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        int[] index = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            bool Lock = false;
            for (int j = i+1; j < nums.Length; j++)
            {
                print(i + ":" + nums[i] + "    " + j + ":" + nums[j]);
                if (nums[i] + nums[j] == target)
                {
                    index[0] = i;
                    index[1] = j;
                    Lock = true;
                    break;
                }
            }
            if (Lock== true)
            {
                break;
            }
        }
        return index;
    }
}
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int g) { val = g; }
}