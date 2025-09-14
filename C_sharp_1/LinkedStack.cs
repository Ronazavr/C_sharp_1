using System.Collections.Generic;

namespace lab1
{
    public class LinkedStack<T> : IStack<T>
    {
        private class Node
        {
            public T Value { get; }
            public Node Next { get; set; }

            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node _top;

        public void Push(T value) => _top = new Node(value, _top);

        public T Pop()
        {
            if (IsEmpty)
                throw new StackException("Стек пуст");

            T value = _top.Value;
            _top = _top.Next;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new StackException("Стек пуст");

            return _top.Value;
        }

        public void Clear() => _top = null;

        public int Count
        {
            get
            {
                int count = 0;
                Node current = _top;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public bool IsEmpty => _top == null;

        public LinkedStack()
        {
            // Конструктор по умолчанию
        } 
        public IEnumerator<T> GetEnumerator()
        {
            Node current = _top;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}