using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Password.Classes.Core
{
    public abstract class CustomTable<TOwner, TRow> : IEnumerable<TRow> where TOwner : class where TRow : CustomTableRow
    {
        public class RowEventArgs : EventArgs
        {
            public RowEventArgs(TRow row)
            {
                Row = row;
            }

            public TRow Row
            {
                get;
                set;
            }
        }

        public class RowMoveEventArgs : EventArgs
        {
            public RowMoveEventArgs(TRow row, int fromRow, int toRow)
            {
                Row = row;
                FromRow = fromRow;
                ToRow = toRow;
            }

            public TRow Row
            {
                get;
                set;
            }

            public int FromRow
            {
                get;
                set;
            }

            public int ToRow
            {
                get;
                set;
            }
        }

        private readonly List<TRow> _rows;

        protected abstract string GetElementName();

        protected abstract TRow NewRow();

        protected void OnRowAdded(TRow row)
        {
            if (RowAdded != null)
                RowAdded(this, new RowEventArgs(row));
        }

        protected void OnRowRemoved(TRow row)
        {
            if (RowRemoved != null)
                RowRemoved(this, new RowEventArgs(row));
        }

        protected void OnRowMoved(TRow row, int fromRow, int toRow)
        {
            if (RowMoved != null)
                RowMoved(this, new RowMoveEventArgs(row, fromRow, toRow));
        }

        protected void Add(TRow row)
        {
            _rows.Add(row);

            OnRowAdded(row);
        }

        protected CustomTable(TOwner owner)
        {
            Owner = owner;

            _rows = new List<TRow>();
        }

        public void Clear()
        {
            _rows.ForEach(OnRowRemoved);
            _rows.Clear();
        }

        public bool HasRow(TRow row)
        {
            return _rows.Any(x => x.ID == row.ID);
        }

        public TRow Add()
        {
            var row = NewRow();
            Add(row);

            return row;
        }

        public virtual bool CanRemove(TRow row)
        {
            return true;
        }

        public virtual void Remove(TRow row)
        {
            row = _rows.Single(r => r.ID == row.ID);
            
            _rows.Remove(row);
            OnRowRemoved(row);
        }

        public void Move(int from, int to)
        {
            var row = _rows[from];

            _rows.RemoveAt(from);
            _rows.Insert(to, row);

            OnRowMoved(row, from, to);
        }

        public void Sync(TRow[] rows)
        {
            var visited = this.ToDictionary(x => x, y => false);

            foreach (var row in rows)
            {
                var item = this.SingleOrDefault(r => r.Equals(row));
                if (item == null)
                    Add(row);
                else
                    visited[item] = true;
            }

            var items = visited.Where(v => !v.Value).Select(v => v.Key).ToArray();
            foreach (var item in items)
                Remove(item);

            int count = 0;
            items = this.ToArray();
            for (int i = 0; i < rows.Length; i++)
                if (rows[i].Equals(items[i]))
                    count++;

            if (rows.Length == count)
                return;

            // TODO: реализовать сортировку
            int k = 0;
            var r0 = items.ToDictionary(x => x, y => k++);
            for (int i = 0; i < rows.Length; i++)
            {
                var r1 = rows[i];
                var i1 = r0[r1];

                OnRowMoved(r1, i, i1);
            }
        }

        public virtual void Load(XElement node)
        {
            Clear();

            var elements = node.Elements();
            foreach (var element in elements)
            {
                var row = NewRow();
                row.Load(element);

                Add(row);
            }
        }

        public virtual void Save(XElement node)
        {
            var elementName = GetElementName();

            foreach (var row in _rows)
            {
                var element = new XElement(elementName);
                row.Save(element);

                node.Add(element);
            }
        }
        
        public IEnumerator<TRow> GetEnumerator()
        {
            return _rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TOwner Owner
        {
            get;
            private set;
        }

        public int Count
        {
            get
            {
                return _rows.Count;
            }
        }

        public TRow this[int index]
        {
            get
            {
                return _rows[index];
            }
        }

        public TRow this[Guid index]
        {
            get
            {
                return _rows.Single(row => row.ID == index);
            }
        }

        public event EventHandler<RowEventArgs> RowAdded;
        public event EventHandler<RowEventArgs> RowRemoved;
        public event EventHandler<RowMoveEventArgs> RowMoved;
    }
}