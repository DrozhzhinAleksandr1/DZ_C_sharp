using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyCollections
{
    /// <summary>
    /// Demo class impliments LinkedList X2
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class MyLinkedListX2<T> : IList<T>, IEnumerator<T>
    {
        #region inner classes
        /// <summary>
        /// class helper
        /// </summary>
        private class ListItem
        {
            public T _value;
            public ListItem _prev;
            public ListItem _next;

            public ListItem(T value, ListItem prev = null, ListItem next = null)
            {
                _value = value;
                _prev = prev;
                _next = next;
            }
        }
        #endregion
        #region fields
        private ListItem _head = null;
        private ListItem _tail = null;
        private int _counter = 0;
        private ListItem _currentItem = null;
        #endregion

        #region ctors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MyLinkedListX2()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">for initialization initial data</param>
        public MyLinkedListX2(IEnumerable<T> array)
        {
            using (IEnumerator<T> e = array.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    Add(e.Current);
                }
            }
        }
        #endregion

        #region properties and indexer
        /// <summary>
        /// getter and setter
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get => GetItem(index)._value;
            set => GetItem(index)._value = value;
        }
        /// <summary>
        /// rerurn list length/count
        /// </summary>
        public int Count { get => _counter; }
        /// <summary>
        /// dont do enething
        /// </summary>
        public bool IsReadOnly { get => false; }

        #endregion

        #region utilites
        /// <summary>
        /// returns an element at its index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private ListItem GetItem(int index)
        {
            if (index < 0 || index >= _counter) throw new ArgumentOutOfRangeException();
            ListItem item = _head;
            while (index-- > 0)
            {
                item = item._next;
            }
            return item;
        }
        #endregion

        #region methods

        /// <summary>
        /// Add to Head
        /// </summary>
        /// <param name="val">Generic type, additional value</param>
        public void AddHead(T val)
        {
            if (_tail == null && _head == null)
            {
                _head = _tail = new ListItem(val);
                _counter = 1;
            }
            else
            {
                _head = _head._prev = new ListItem(val, null, _head);
                ++_counter;
            }
        }
        /// <summary>
        /// Add to Tail
        /// </summary>
        /// <param name="val">Generic type, additional value</param>
        public void Add(T val)
        {
            if (_tail == null && _head == null)
            {
                _head = _tail = new ListItem(val);
                _counter = 1;
            }
            else
            {
                _tail = _tail._next = new ListItem(val, null, _head);
                ++_counter;
            }
        }
        /// <summary>
        /// delete all info from list
        /// </summary>
        public void Clear()
        {
            _counter = 0;
            _head = _tail = null;
        }
        /// <summary>
        /// if elem contains in list return true
        /// </summary>
        /// <param name="val">Contains(T val)</param>
        /// <returns></returns>
        public bool Contains(T val)
        {
            using (IEnumerator<T> e = GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (e.Current.Equals(val))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            using (IEnumerator<T> e = GetEnumerator())
            {
                while (e.MoveNext())
                {
                    array[arrayIndex++] = e.Current;
                }
            }
        }
        /// <summary>
        /// finds the first element by its value and returns the index
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int IndexOf(T val)
        {
            ListItem item = _head;
            for (int i = 0; item != null; ++i, item = item._next)
            {
                if (item._value.Equals(val))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// inserts elements into a list starting with the index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="val"></param>
        public void Insert(int index, T val)
        {
            if (index == 0)
            {
                AddHead(val);
                return;
            }
            if (index == _counter)
            {
                Add(val);
                return;
            }
            ListItem itemPrev = GetItem(index - 1);
            ListItem itemNext = GetItem(index);

            itemNext._prev = itemPrev._next = new ListItem(val, itemPrev, itemNext);
            ++_counter;

        }
        /// <summary>
        /// delete first element from list with this value
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Remove(T val)
        {
            // если голова пуста то и лист пуст
            if (_head == null) return false;
            // если валуе головы равно то голову перемещяем на 1 вперед
            if (_head._value.Equals(val))
            {
                _head = _head._next;
                --_counter;
                return true;
            }
            // делаем итем для цыкла
            ListItem item = _head;
            while (item._next != null)
            {
                // ищим нужный 
                if (val.Equals(item._next._value))
                {
                    break;
                }
                item = item._next;
            }
            // если цыкл закончился и не нашли
            if (item == null) return false;
            // если нашли, переставляем ссылку итема на следующий

            int indexRemovedItem = this.IndexOf(item._next._value);            
            ListItem nextItem = this.GetItem(indexRemovedItem + 1); 
            ListItem prevItem = this.GetItem(indexRemovedItem - 1);
            nextItem._prev = prevItem;
            prevItem._next = nextItem;

            --_counter;
            return true;
        }
        /// <summary>
        /// delete item on index place if index in range
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            // если голова пуста то и лист пуст
            if (_head == null) return;
            // если валуе головы равно то голову перемещяем на 1 вперед
            if (index == 0)
            {
                _head = _head._next;
                --_counter;
                return;
            }
            // делаем итем для цыкла
            ListItem item = _head;
            int i = 1;
            while (item._next != null)
            {
                // ищим нужный 
                if (index == i)
                {
                    // если нашли, переставляем ссылку итема на следующий

                    int indexRemovedItem = this.IndexOf(item._next._value);
                    ListItem nextItem = this.GetItem(indexRemovedItem + 1);
                    ListItem prevItem = this.GetItem(indexRemovedItem - 1);
                    nextItem._prev = prevItem;
                    prevItem._next = nextItem;
                    --_counter;
                    break;
                }
                item = item._next;
                ++i;
            }
        }
        #endregion

        #region IEnumerator 

        public T Current { get => _currentItem._value; }
        object IEnumerator.Current { get => Current; }

        /// <summary>
        /// need for foreach
        /// </summary>
        public void Dispose()
        {
            Reset();
        }
        /// <summary>
        /// need for Dispise
        /// </summary>
        public void Reset()
        {
            _currentItem = null;
        }
        /// <summary>
        /// next steep for foreach
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_currentItem == null)
            {
                _currentItem = _head;
            }
            else
            {
                _currentItem = _currentItem._next;
            }
            return _currentItem != null;
        }
        #endregion
        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

    }
}
