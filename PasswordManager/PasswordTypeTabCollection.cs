using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PasswordManager
{
    internal class PasswordTypeTabCollection : IList<PasswordTypeTab>
    {
        private readonly TabControl.TabPageCollection _tabCollection;
        private readonly List<PasswordTypeTab> _tabs; 

        public PasswordTypeTabCollection(TabControl.TabPageCollection tabCollection)
        {
            _tabCollection = tabCollection;
            _tabs = new List<PasswordTypeTab>(tabCollection.Cast<PasswordTypeTab>());
        }
        
        #region Implementation of IEnumerable

        public IEnumerator<PasswordTypeTab> GetEnumerator()
        {
            return _tabs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<PasswordTypeTab>

        public void Add(PasswordTypeTab item)
        {
            _tabCollection.Add(item);
            _tabs.Add(item);
        }

        public void Clear()
        {
            _tabCollection.Clear();
            _tabs.Clear();
        }

        public bool Contains(PasswordTypeTab item)
        {
            return _tabs.Contains(item);
        }

        public void CopyTo(PasswordTypeTab[] array, int arrayIndex)
        {
            _tabs.CopyTo(array, arrayIndex);
        }

        public bool Remove(PasswordTypeTab item)
        {
            if (!Contains(item))
                return false;

            if (_tabCollection.Contains(item))
                _tabCollection.Remove(item);
            _tabs.Remove(item);
            
            return true;
        }

        public int Count
        {
            get
            {
                return _tabs.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _tabCollection.IsReadOnly;
            }
        }

        #endregion

        #region Implementation of IList<PasswordTypeTab>

        public int IndexOf(PasswordTypeTab item)
        {
            return _tabs.IndexOf(item);
        }

        public void Insert(int index, PasswordTypeTab item)
        {
            _tabCollection.Insert(index, item);
            _tabs.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            var tab = _tabs[index];

            _tabCollection.Remove(tab);
            _tabs.Remove(tab);
        }

        public PasswordTypeTab this[int index]
        {
            get
            {
                return _tabs[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        #endregion
    }
}