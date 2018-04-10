using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkNode : MonoBehaviour
{
    public GameObject[] nodes;


    public void SetAllChild(Transform trans)
    {
        LinkNode node = trans.GetComponent<LinkNode>();

        if (trans.childCount == 0 && node)
        {
            return;
        }

        if (node == null)
        {
            node = trans.gameObject.AddComponent<LinkNode>();
        }

        node.nodes = new GameObject[trans.childCount];

        for (int i = 0; i < trans.childCount; i++)
        {
            Transform child = trans.GetChild(i);
            node.nodes[i] = child.gameObject;

            SetAllChild(child);
        }
    }
    [ContextMenu("设置子物体")]
    public void SetAll()
    {
        SetAllChild(transform);
    }
}
