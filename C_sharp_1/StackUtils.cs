using System;

namespace lab1
{
    public static class StackUtils<T> where T : IComparable<T>
    {
        public delegate bool CheckDelegate<in T>(T item);
        public delegate TO ConvertDelegate<in TI, out TO>(TI item);
        public delegate IStack<T> StackConstructorDelegate<T>();

        public static readonly StackConstructorDelegate<T> ArrayStackConstructor = () => new ArrayStack<T>();
        public static readonly StackConstructorDelegate<T> LinkedStackConstructor = () => new LinkedStack<T>();

        public static bool Exists(IStack<T> stack, CheckDelegate<T> check)
        {
            foreach (var item in stack)
                if (check(item))
                    return true;
            return false;
        }

        public static IStack<T> FindAll(IStack<T> stack, CheckDelegate<T> check, StackConstructorDelegate<T> constructor)
        {
            IStack<T> result = constructor();
            IStack<T> temp = new ArrayStack<T>();

            foreach (var item in stack)
                if (check(item))
                    temp.Push(item);

            while (!temp.IsEmpty)
                result.Push(temp.Pop());

            return result;
        }

        public static IStack<TO> ConvertAll<TI, TO>(IStack<TI> stack, ConvertDelegate<TI, TO> convert, StackConstructorDelegate<TO> constructor)
        {
            IStack<TO> result = constructor();
            IStack<TI> temp = new ArrayStack<TI>();

            foreach (var item in stack)
                temp.Push(item);

            while (!temp.IsEmpty)
                result.Push(convert(temp.Pop()));

            return result;
        }

        public static void ForEach(IStack<T> stack, Action<T> action)
        {
            IStack<T> temp = new ArrayStack<T>();

            foreach (var item in stack)
                temp.Push(item);

            while (!temp.IsEmpty)
                action(temp.Pop());
        }

        public static bool CheckForAll(IStack<T> stack, CheckDelegate<T> check)
        {
            foreach (var item in stack)
                if (!check(item))
                    return false;
            return true;
        }
    }
}