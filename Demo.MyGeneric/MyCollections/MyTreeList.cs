using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{

    public class MyTree<Tkey, TVal> :IDictionary<Tkey,TVal> where Tkey : IComparable
    {
        public delegate void ForEachDelegate(KeyValuePair<Tkey, TVal> pair);
        private class TreeItem
        {
            public KeyValuePair<Tkey, TVal> _pair;
            //public TreeItem _parent;
            public TreeItem _left;
            public TreeItem _right;
            public TreeItem(Tkey key, TVal value, TreeItem left = null, TreeItem right = null)
            {
                _pair = new KeyValuePair<Tkey, TVal>(key, value);
                //_parent = parent;
                _left = left;
                _right = right;
            }
            public TreeItem(KeyValuePair<Tkey, TVal> pair, TreeItem left = null, TreeItem right = null)
            {
                _pair = pair;
                //_parent = parent;
                _left = left;
                _right = right;
            }
        }

        private TreeItem _root = null;
        private bool _allowDuplicateKeys;

        public MyTree(bool allowDuplicateKeys = false)
        {
            _allowDuplicateKeys = allowDuplicateKeys;
        }

        public void Add(Tkey key, TVal value)
        {
            if (_root == null)
            {
                _root = new TreeItem(key, value);
                ++Count;
            }
            else
            {
                Add(new KeyValuePair<Tkey, TVal>(key, value), _root);
            }
        }
        private void Add(KeyValuePair<Tkey, TVal> pair, TreeItem item)
        {
            if (!_allowDuplicateKeys && pair.Key.CompareTo(item._pair.Key) == 0)
            {
                item._pair = pair;
            }
            else if (pair.Key.CompareTo(item._pair.Key) < 0)//Go to left
            {
                if (item._left == null)
                {
                    item._left = new TreeItem(pair, item);
                    ++Count;
                }
                else
                {
                    Add(pair, item._left);
                }
            }
            else//go to right
            {
                if (item._right == null)
                {
                    item._right = new TreeItem(pair, item);
                    ++Count;
                }
                else
                {
                    Add(pair, item._right);
                }
            }
        }


        /// <summary>
        /// returns a tree by layers
        /// </summary>
        /// <param name="d"></param>
        public void ForEachLayers(ForEachDelegate d)
        {
            TreeItem item = _root;
            Queue<TreeItem> itemStack = new Queue<TreeItem>();
            while (item != null || itemStack.Count != 0)
            {
                if (itemStack.Count != 0) 
                {
                    item = itemStack.Dequeue();
                    d.Invoke(item._pair);

                    if (item._right != null)
                    {
                        item = item._right;
                    }
                    else
                    {
                        item = null;
                    }
                }
                while (item != null)
                {
                    itemStack.Enqueue(item);
                    item = item._left;
                }
            }
        }
        /// <summary>
        /// find and return pair
        /// </summary>
        /// <param name="d"></param>
        public KeyValuePair<Tkey, TVal> ReturnElem(Tkey key)
        {
            TreeItem item = _root;
            Queue<TreeItem> itemStack = new Queue<TreeItem>();
            while (item != null || itemStack.Count != 0)
            {
                if (itemStack.Count != 0)
                {
                    item = itemStack.Dequeue();

                    if (key.Equals(item._pair.Key))
                    {
                        return item._pair;
                    }

                    if (item._right != null)
                    {
                        item = item._right;
                    }
                    else
                    {
                        item = null;
                    }
                }
                while (item != null)
                {
                    itemStack.Enqueue(item);
                    item = item._left;
                }
            }
            throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// find end change value in pair
        /// </summary>
        /// <param name="d"></param>
        public void SetElem(Tkey key, TVal val)
        {
            TreeItem item = _root;
            Queue<TreeItem> itemStack = new Queue<TreeItem>();
            while (item != null || itemStack.Count != 0)
            {
                if (itemStack.Count != 0)
                {
                    item = itemStack.Dequeue();

                    if (key.Equals(item._pair.Key))
                    {
                        item._pair = new KeyValuePair<Tkey,TVal>(key, val);
                    }

                    if (item._right != null)
                    {
                        item = item._right;
                    }
                    else
                    {
                        item = null;
                    }
                }
                while (item != null)
                {
                    itemStack.Enqueue(item);
                    item = item._left;
                }
            }
        }

        /// <summary>
        /// return all keys 
        /// </summary>
        public ICollection<Tkey> Keys
        {
            get
            {
                List<Tkey> myKeys = new List<Tkey>();
                ForEachLayers(pair => myKeys.Add(pair.Key));
                return myKeys;
            }
        }

        public ICollection<TVal> Values
        {
            get
            {
                List<TVal> myValues = new List<TVal>();
                ForEachLayers(pair => myValues.Add(pair.Value));
                return myValues;
            }
        }
        public int Count { get; set; } = 0;

        public bool IsReadOnly { get => false; } 



        /// <summary>
        /// index method get/set value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TVal this[Tkey key] {
            get
            {
                var elem = ReturnElem(key);
                return elem.Value;
            }
            set
            {
                SetElem(key, value);
            }
        }


        public bool ContainsKey(Tkey key) // return tru or false   key present in list
        {
            bool ok = false;
            ForEachLayers(pair => {
                if (key.Equals(pair.Key))
                {
                    ok = true;
                }
            });
            return ok;
        }

        public bool Remove(Tkey key)  // remove elem from dictionare by key name
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// return true  if value present 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(Tkey key, out TVal value)
        {
            var elem = ReturnElem(key);
            value = elem.Value;
            return true; 
        }

        public void Add(KeyValuePair<Tkey, TVal> item) //add 2
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// remove all elem in dictionary
        /// </summary>
        public void Clear() 
        {
            this._root = null;
            Count = 0;
        }
        /// <summary>
        /// key val find item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<Tkey, TVal> item)
        {
            if (ReturnElem(item.Key).Value.Equals(item.Value)) return true;
            return false;
        }

        public void CopyTo(KeyValuePair<Tkey, TVal>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// remove elem from tree
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<Tkey, TVal> item) // del
        {
            throw new NotImplementedException();
        }
        
        private void RemoveItem(TreeItem item, TreeItem parent)
        {
            --Count;

            if (item._left == null && item._right == null)
            {
                RemoveItemWithoutChildren(item, parent);
            }
            else if (item._left != null && item._right != null)
            {
                RemoveItemWithBothChildren(item, parent);
            }
            else
            {
                RemoveItemWithOneChild(item, parent);
            }

        }

        private void RemoveItemWithoutChildren(TreeItem item, TreeItem parent)
        {
            if (item == _root)
            {
                _root = null;
                return;
            }
            if (parent._left == item)
            {
                parent._left = null;
            }
            else
            {
                parent._right = null;
            }
        }
        private void RemoveItemWithOneChild(TreeItem item, TreeItem parent)
        {
            throw new NotImplementedException();
        }
        private void RemoveItemWithBothChildren(TreeItem item, TreeItem parent)
        {
            //Find successor Node
            TreeItem success = item._right;
            TreeItem successParent = item;
            while (success._left != null)
            {
                successParent = success;
                success = success._left;
            }

            //replace value deleted node and successor
            item._pair = success._pair;

            //delete successor
            successParent._left = success._right;
        }
    






    public IEnumerator<KeyValuePair<Tkey, TVal>> GetEnumerator()
        {
            using (IEnumerator<TreeItem> e = GetTreeItemEnumerator(_root))
            {
                while (e.MoveNext())
                {
                    yield return e.Current._pair;
                }
            }
        }
        private IEnumerator<TreeItem> GetTreeItemEnumerator(TreeItem item)
        {
            Stack<TreeItem> itemStack = new Stack<TreeItem>();

            while (item != null || itemStack.Count != 0)
            {
                if (itemStack.Count != 0)
                {
                    item = itemStack.Pop();

                    //this is my action
                    yield return item;

                    if (item._right != null)
                    {
                        item = item._right;
                    }
                    else
                    {
                        item = null;
                    }
                }
                while (item != null)
                {
                    itemStack.Push(item);
                    item = item._left;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
