namespace Algorithms.ListDataStructures
{
    using System;
    using System.Linq;

    public class Array<T>
    {
        private T[] array;

        public Array(T[] array)
        {
            this.array = array;
        }

        public Array()
        {
            this.array = new T[0];
        }

        public T this[int index]
        {
            get
            {
                return this.array[index];
            }
        }

        public void InsertAtHead(T item)
        {
            if (item == null)
            {
                throw new System.ArgumentNullException();
            }

            T[] newArray = new T[this.array.Length + 1];
            newArray[0] = item;
            this.array.CopyTo(newArray, 1);
            this.array = newArray;
        }

        public void InsertAtTail(T item)
        {
            if (item == null)
            {
                throw new System.ArgumentNullException();
            }

            T[] newArray = new T[this.array.Length + 1];
            newArray[newArray.Length - 1] = item;
            this.array.CopyTo(newArray, 0);
            this.array = newArray;
        }

        public ArraySearchResult Search(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new System.ArgumentNullException();
            }

            var index = this.array.TakeWhile(x => !predicate(x)).Count();
            return new(index < this.array.Length, index, this.array[index]);
        }

        public readonly record struct ArraySearchResult(bool Found, int Index, T Value);

        /* ResultCode Array_Search(const Array*, const void*, void**); */
        /* ResultCode Array_Enumerate(const Array*, item_handler); */
        /* ResultCode Array_Max(const Array*, void**); */
        /* ResultCode Array_Predecessor(const Array*, const void*, void**); */
        /* ResultCode Array_Rank(const Array*, const void*, size_t*); */
    }
}
