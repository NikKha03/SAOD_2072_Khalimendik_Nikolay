using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPZ
{
    public class Stack<T>
    {
        public int size = 0;
        private T[] array;
        int n;

        public Stack(int n)
        {
            this.n = n;
            array = new T[n];
        }

        public bool Push(T value)
        {
            if (IsNoFull())
            {
                array[size] = value;
                size++;
                return true;
            }
            else return false;

        }
        public T Pop()
        {
            size--;

            return array[size];
        }

        public bool IsNoFull()
        {
            if (size != this.array.Length)
                return true;
            else
                return false;
        }
        public bool IsEmpty()
        {
            if (size == 0)
                return true;
            else return false;
        }

        public T Top()
        {
            return array[size - 1];
        }

        public void Clear(int n)
        {
            this.n = n;
            array = new T[n];
        }
    }
}
    

