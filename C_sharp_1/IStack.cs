using System.Collections.Generic;

namespace lab1
{
    public interface IStack<T> : IEnumerable<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        void Clear();

        int Count { get; }
        bool IsEmpty { get; }
    }
}