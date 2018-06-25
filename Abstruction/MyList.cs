using System;
using System.Collections;

namespace Abstruction
{
    internal class MyList<T> : IEnumerable, IEnumerator
    {
        protected T[] mainArr;
        protected T[] supportArr;
        protected Int32 index;
        protected Int32 count;
        protected Boolean isEmpty;
        protected String popMethMsg;
        protected T popMethReturnTos;

        private T currentlyTos;
        private Int32 defaultValueCount;

        public T GetTos { get { return currentlyTos; } }
        public Int32 Count { get { return count; } }

        public object Current { get { return mainArr[index]; } }

        public MyList(String msg = "List is Empty")
        {
            mainArr = new T[count];
            supportArr = new T[count];
            count = 0;
            index = -1;
            popMethMsg = msg;
            isEmpty = true;
        }
        public virtual void Add(T item)
        {
            Array.Copy(mainArr, supportArr, mainArr.Length);
            count++;
            mainArr = new T[count];
            Array.Copy(supportArr, mainArr, supportArr.Length);
            supportArr = new T[count];
            mainArr[count - 1] = item;
            index = -1;
            isEmpty = false;
            currentlyTos = item;
        }
        public Boolean RemoveAt(Int32 index)
        {
            defaultValueCount = 0;
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (Int32 i = 0; i < mainArr.Length; i++)
                {
                    if (index.Equals(i))
                    {
                        mainArr[i] = default(T);
                        defaultValueCount++;
                    }
                }
                supportArr = new T[mainArr.Length - defaultValueCount];
                for (Int32 i = 0, j = 0; i < mainArr.Length; i++)
                {
                    if (!mainArr[i].Equals(default(T)))
                    {
                        supportArr[j] = mainArr[i];
                        j++;
                    }
                }
                mainArr = new T[--count];
                Array.Copy(supportArr, mainArr, mainArr.Length);
                supportArr = new T[count];
                currentlyTos = mainArr[count - 1];
                this.index = -1;
                if (count == 0)
                {
                    isEmpty = true;
                }
                return true;
            }
        }
        public virtual T Pop()
        {
            if (isEmpty)
            {
                throw new ArgumentOutOfRangeException(popMethMsg, new Exception());
            }
            else
            {
                popMethReturnTos = mainArr[count - 1];
                RemoveAt(count - 1);
                return popMethReturnTos;
            }
        }
        #region IEnumerable, IEnumerator
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public bool MoveNext()
        {
            if (index >= mainArr.Length - 1)
            {
                return false;
            }
            else
            {
                index++;
                return true;
            }
        }
        public void Reset()
        {
            index = 0;
        }
        #endregion
    }
}
