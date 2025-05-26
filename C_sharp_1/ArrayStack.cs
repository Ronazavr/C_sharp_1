using System;

namespace lab1
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] _items;
        private int _top = -1;

        public ArrayStack(int capacity = 10)
        {
            _items = new T[capacity];
        }

        public void Push(T value)
        {
            if (_top == _items.Length - 1)
                Array.Resize(ref _items, _items.Length * 2);

            _items[++_top] = value;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new StackException("Стек пуст");

            return _items[_top--];
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new StackException("Стек пуст");

            return _items[_top];
        }

        public void Clear() => _top = -1;

        public int Count => _top + 1;
        public bool IsEmpty => _top == -1;

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int i = _top; i >= 0; i--)
                yield return _items[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}