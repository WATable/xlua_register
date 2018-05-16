using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DataStructure
{
    public class BinaryLinkTree<T> 
    {
        TwoNode<T> root;

        T[] dataSource;

        public BinaryLinkTree(T[] dataSource)
        {
            this.dataSource = dataSource;

            this.root = new DataStructure.TwoNode<T>();


            this.root.index = 0;
        }

        public TwoNode<T> GetRoot()
        {
            return root;
        }
        public T GetDefault()
        {
            return default(T);
        }
        /// <summary>
        /// 生成父节点
        /// </summary>
        /// <param name="node"></param>
        public void GenerateRoot(TwoNode<T> node)
        {
            if (node.index < dataSource.Length)
            {
                if (dataSource[node.index].Equals(default(T)))
                {
                    return;
                }
                node.Data = dataSource[node.index];

                node.Left = CreateLeft(node);
                node.Right = CreatRight(node);
            }
        }

        public TwoNode<T> CreateLeft(TwoNode<T> node)
        {
            if (node != null)
            {
                node.Left = new TwoNode<T>();

                node.Left.index = 2 * node.index + 1;
                GenerateRoot(node.Left);
            }
            return node.Left;
        }

        public TwoNode<T> CreatRight(TwoNode<T> node)
        {
            if (node != null)
            {
                node.Right = new TwoNode<T>();

                node.Right.index = 2 * node.index + 2;
                GenerateRoot(node.Right);
            }
            return node.Right;
        }
    }

}
