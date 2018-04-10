using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Snake
{
    public class Data<T>
    {
        public T current;

        public Data<T> next;

        public Data(T current)
        {
            this.current = current;
        }
    }

    public class Stack<T>
    {
        public Data<T> head;

        public int count;

        public bool IsEmty()
        {
            if (head == null)
            {
                return false;
            }
            return true;
        }

        public void Push(T value)
        {
            if (!IsEmty())
            {
                Data<T> temp = new Snake.Data<T>(value);

                head = temp;
            }
            else
            {

                Data<T> current = new Snake.Data<T>(value);

                current.next = head;

                head = current;
            }
        }

        public Data<T> Pop()
        {
            if (!IsEmty())
            {
                return null;
            }
            else
            {
                Data<T> current = head;

                head = current.next;
                current.next = null;
                return current;
            }
        }

        public void LogInfo()
        {
            Data<T> data = head;

            while (data !=null)
            {
                Debug.Log(data.current);
                data = data.next;
            }


        }


    }
}

