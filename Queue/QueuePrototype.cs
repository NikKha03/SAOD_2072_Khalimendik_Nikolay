using System;
using System.Xml.Linq;

namespace Queue {
    internal class QueuePrototype<T> {

        private T[] container;
        private int count;
        private int currentIn;
        private int currentOut;
        private bool carryFlag;

        public QueuePrototype(int capacity = 10) {
            container = new T[capacity];
        }

        public void enqueue(T elem) {
            if(count == Capacity) throw new QueueOverflowException("Queue overflow");

            // currentIn on second circle
            if(currentIn == Capacity) {
                carryFlag = true;
                currentIn = 0;
            }

            container[currentIn++] = elem;     
            count++;
        }

        public T dequeue() {
            checkEmpty();

            // currentOut on second circle
            if(currentOut == Capacity) {
                currentOut = 0;
                carryFlag = false;
            }

            count--;
            return container[currentOut++];
        }

        public T peek() {
            checkEmpty();
            return container[currentOut];
        }

        public bool isEmpty() {
            return count == 0;
        }

        private void checkEmpty() {
            if(count == 0) throw new QueueEmptyException("Queue is empty");
        }


        public T[] toArray() {
            return !carryFlag 
                ? container[currentOut..currentIn]
                : container[currentOut..].Concat(container[..currentIn]).ToArray();
        }

        public int Capacity {
            get { return container.Length; }
        }

        public int getCount() {
            return count;
        }
    }
}