
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructure
{
    public class NodeBase<T> : INode<T>
    {

        protected T data;

        public NodeBase()
        {
            data = default(T);
        }
        public NodeBase(T data)
        {
            this.data = data;
        }

        public T Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public T GetRoot()
        {
            return data;
        }
    }

}
