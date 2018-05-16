using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DataStructure
{
    public interface INode<T>
    {
        T Data { get; set; }
        T GetRoot();
    }
}
