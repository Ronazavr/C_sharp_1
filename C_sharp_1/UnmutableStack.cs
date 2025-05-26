using System.Collections.Generic;

namespace lab1
{
    public class UnmutableStack<T> : IStack<T>
    {
        private readonly IStack<T> _stack;

        public UnmutableStack(IStack<T> stack) => _stack = stack;

        public void Push(T value) => throw new StackException("Неизменяемый стек");
        public T Pop() => throw new StackException("Неизменяемый стек");
        public T Peek() => _stack.Peek();
        public void Clear() => throw new StackException("Неизменяемый стек");

        public int Count => _stack.Count;
        public bool IsEmpty => _stack.IsEmpty;
        public IStack<T> GetOriginalStack() => _stack;

        public IEnumerator<T> GetEnumerator() => _stack.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}