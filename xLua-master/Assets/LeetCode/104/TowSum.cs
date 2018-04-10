using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowSum : MonoBehaviour
{
    private void Start()
    {
        ListNode node = new global::ListNode(1);
        node.next = new ListNode(2);
        node.next.next = new ListNode(3);
        print(GetListNodeLength(node));

        //AddTwoNumbers(node,null);
    }
    //public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    //{
    //    int len1 = GetListNodeLength(l1);
    //    int len2 = GetListNodeLength(l2);

    //    for (int i = 0; i < len1; i++)
    //    {

    //    }
    //}


    public int GetListNodeLength(ListNode node)
    {
        if (node == null)
        {
            return 0;
        }
        int length = 0;
        while (node.next != null)
        {
            length++;
            node = node.next;
        }
        return length;
    }
}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}
