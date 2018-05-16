using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructure;

public class TestBinary : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        BinaryLinkTree<int> tree = new DataStructure.BinaryLinkTree<int>(data);
        tree.GenerateRoot(tree.GetRoot());
        print(tree.GetRoot().ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
