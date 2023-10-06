using System;
using System.Collections;
using System.Collections.Generic;


namespace List {
    internal class ListPrototype<T> {

        private Node<T> first;
        private Node<T> last;
        private int count;

        public void append(T value) {
            Node<T> newNode = new Node<T>(value, null, null);

            if(count == 0) {
                first = newNode;
                last = newNode;
            } else {
                if(count == 1) 
                    first.setNext(newNode);

                Node<T> previous = last;
                last = newNode;
                last.setPrevious(previous);
                previous.setNext(last);
            }

            count++;
        }

        public void prepend(T value) {
            Node<T> newNode = new Node<T>(value, null, null);

            if(count == 0) {
                first = newNode;
                last = newNode;
            } else {
                Node<T> secondNode = first;
                first = newNode;
                secondNode.setPrevious(first);
                first.setNext(secondNode);
            }

            count++;
        }

        public void insert(int index, T value) {
            Node<T> nodeToMove = findNode(index);
            Node<T> nodeToInsert = new Node<T>(value, null, null);

            if(nodeToMove.getPrevious() == null)
                prepend(value);
            else if(nodeToMove.getNext() == null)
                append(value);
            else {
                nodeToInsert.setPrevious(nodeToMove.getPrevious());
                nodeToMove.getPrevious().setNext(nodeToInsert);
                nodeToInsert.setNext(nodeToMove);
                nodeToMove.setPrevious(nodeToInsert);
                count++;
            }
        }

        public int find(T value) {
            int index = 0;
            Node<T> localCurrent = first;

            while(index != count) {
                if(compare(localCurrent.getValue(), value)) {
                    return index;
                }

                localCurrent = localCurrent.getNext();
                index++;
            }

            return -1;
        }

        public T findAt(int index) {
            Node<T> target = findNode(index);
            return target.getValue();
        }

        private Node<T> findNode(int index) {
            if(index > count || index < 0)
                throw new Exception();

            int localIndex = 0;
            Node<T> localCurrent = first;

            while(localIndex != index) {
                localCurrent = localCurrent.getNext();
                localIndex++;
            }

            return localCurrent;
        }

        public bool remove(T value) {
            int index = 0;
            Node<T> localCurrent = first;

            while(index != count) {
                if(compare(localCurrent.getValue(), value)) {
                    doRemove(localCurrent);
                    count--;
                    return true;
                }

                localCurrent = localCurrent.getNext();
                index++;
            }
            return false;
        }

        public bool removeAt(int index) {
            int localIndex = 0;
            Node<T> localCurrent = first;

            while(localIndex != count) {
                if(localIndex == index) {       
                    doRemove(localCurrent);
                    count--;
                    return true;
                }

                localCurrent = localCurrent.getNext();
                localIndex++;
            }
            return false;
        }

        private bool compare(T a, T b) {
            /*a.Equals(b);*/
            return EqualityComparer<T>.Default.Equals(a, b);
        }

        private void doRemove(Node<T> localCurrent) {
            // Если элемент первый в списке
            if(localCurrent == first) {
                if(localCurrent.getNext() != null) {
                    first = localCurrent.getNext();
                    localCurrent.getNext().setPrevious(first);
                } else {
                    first = null;
                    last = null;
                }
                // Если элемент последний в списке
            } else if(localCurrent == last) {
                last = localCurrent.getPrevious();
                last.setNext(null);
            } else {
                // Остальные случаи
                localCurrent.getPrevious().setNext(localCurrent.getNext());
                localCurrent.getNext().setPrevious(localCurrent.getPrevious());
                localCurrent = null;
            }
        }

        public int getCount() {
            return count;
        }

        public void toString() {
            Node<T> localCurrent = first;
            int index = 0;
            String output = "";
            
            while(index != count) {
                if(index == count - 1)
                    output += localCurrent.getValue().ToString();
                else
                    output += localCurrent.getValue().ToString() + ", ";
                
                localCurrent = localCurrent.getNext();
                index++;
            }
            Console.WriteLine(output);
        }

        // перегрузка []
        public T this[int index] {
            get => findAt(index);
            set => findNode(index).setValue(value);
        }


        private class Node<T> {

            public Node(T value, Node<T> pNext, Node<T> pPrevious) {
                this.value = value;
                this.pNext = pNext;
                this.pPrevious = pPrevious;
            }

            private T value;
            private Node<T> pNext;
            private Node<T> pPrevious;

            public T getValue() {
                return value;
            }

            public void setValue(T value) {
                this.value = value;
            }

            public Node<T> getNext() {
                return pNext;
            }

            public void setNext(Node<T> pNext) {
                this.pNext = pNext;
            }

            public Node<T> getPrevious() {
                return pPrevious;
            }

            public void setPrevious(Node<T> pPrevious) {
                this.pPrevious = pPrevious;
            }
        }


        private class ListPrototypeEnumerator : IEnumerator {

            public Node<T> localCurrent;
            public T value;
            public int totalCount;
            public int count = 0;

            public ListPrototypeEnumerator(Node<T> localCurrent, int totalCount) {
                this.localCurrent = localCurrent;
                this.value = localCurrent.getValue();
                this.totalCount = totalCount;
            }

            public object Current {
                get {
                    return value;
                }
            }

            public bool MoveNext() {
                if(count == totalCount) 
                    return false;

                value = localCurrent.getValue();
                localCurrent = localCurrent.getNext();
                count++;
                return true;

            }
            public void Reset() => localCurrent = null;
        }

        public IEnumerator GetEnumerator() => new ListPrototypeEnumerator(first, count);
    }
}
