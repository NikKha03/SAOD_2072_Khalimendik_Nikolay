using System;

namespace SAOD_Stack
{
    internal class Stack<T>
    {

        private T[] arr;
        private int current;
        private int capacity;

        public Stack(int size)
        {

            this.capacity = size;
            this.current = 0;
            this.arr = new T[size];
        }

        public void push(T value)
        {

            if (this.current > this.capacity)
                throw new Exception();

            arr[this.current] = value;
            ++this.current;
        }

        public T pop()
        {

            Console.WriteLine(this.current);
            if (this.current == 0)
                throw new Exception();

            return arr[--this.current];
        }

        public T top()
        {

            if (this.current == 0)
                throw new Exception();

            return arr[this.current - 1];
        }

        public T[] toArray()
        {

            T[] newArr = new T[this.current];

            for (int i = 0; i < this.current; i++)
                newArr[i] = arr[i];

            return newArr;
        }

        public int getCapacity()
        {
            return this.capacity;
        }

        public int getCurrent()
        {
            return this.current;
        }
    }
}