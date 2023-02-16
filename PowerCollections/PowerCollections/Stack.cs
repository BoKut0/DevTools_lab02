using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public int Capacity { get; }

        T[] items;

        public Stack(int size)
        {
            if (size < 0)
            {
                throw new InvalidOperationException("Размер стека не должен быть меньше 0");
            }
            Capacity = size;
            items = new T[Capacity];
        }

        public void Push(T item)
        {
            if (Count == Capacity)
            {
                throw new InvalidOperationException("Стек переполнен. Выход за пределы размера стека");
            }
            else
            {
                items[Count] = item;
                Count += 1;
            }
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Стек не содержит никаких элементов");
            }
            else
            {
                Count -= 1;
                return items[Count];
            }
        }

        public T Top()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Стек не содержит никаких элементов");
            }
            else
            {
                int size = Count - 1;
                return items[size];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int size = Count - 1;
            for (int i = size; i >= 0; i--)
            {
                yield return items[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
