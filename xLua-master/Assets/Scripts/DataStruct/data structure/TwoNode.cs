using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructure
{
    public class TwoNode<T> : NodeBase<T>
    {
        TwoNode<T> left;
        TwoNode<T> right;
        /// <summary>
        /// 节点的深度
        /// </summary>
        public int index;
        public TwoNode(T data) : base(data)
        {
        }

        public TwoNode() : base()
        {

        }

        public TwoNode(T data, TwoNode<T> left) : this(default(T), null, null)
        {
            this.data = data;
            this.left = left;
        }

        public TwoNode(T data, TwoNode<T> left, TwoNode<T> right) : base(data)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        public TwoNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }
        public TwoNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }


    }
}
