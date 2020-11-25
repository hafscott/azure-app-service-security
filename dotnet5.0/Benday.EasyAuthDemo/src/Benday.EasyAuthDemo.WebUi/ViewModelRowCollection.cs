using System;
using System.Collections;
using System.Collections.Generic;

namespace Benday.EasyAuthDemo.WebUi
{
    public class ViewModelRowCollection<T> : IList<T> where T : new()
    {
        private List<T> _List;
        private T _TemplateItem;
        public const int TEMPLATE_ROW_INDEX = Int32.MaxValue;
        
        public ViewModelRowCollection()
        {
            _List = new List<T>();
        }
        
        public Action<T> OnNewTemplateItem;
        
        public T TemplateItem
        {
            get
            {
                if (_TemplateItem == null)
                {
                    _TemplateItem = new T();
                    
                    if (OnNewTemplateItem != null)
                    {
                        OnNewTemplateItem(_TemplateItem);
                    }
                }
                
                return _TemplateItem;
            }
            set
            {
                _TemplateItem = value;
            }
        }
        
        public T this[int index]
        {
            get
            {
                if (index == TEMPLATE_ROW_INDEX)
                {
                    return TemplateItem;
                }
                else
                {
                    return _List[index];
                }
            }
            set
            {
                _List[index] = value;
            }
        }
        
        public int Count
        {
            get
            {
                return _List.Count;
            }
        }
        
        public bool IsReadOnly
        {
            get
            {
                return ((IList<T>)_List).IsReadOnly;
            }
        }
        
        public void Add(T item)
        {
            _List.Add(item);
        }
        
        public void Clear()
        {
            _List.Clear();
        }
        
        public bool Contains(T item)
        {
            return _List.Contains(item);
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            _List.CopyTo(array, arrayIndex);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return _List.GetEnumerator();
        }
        
        public int IndexOf(T item)
        {
            return _List.IndexOf(item);
        }
        
        public void Insert(int index, T item)
        {
            _List.Insert(index, item);
        }
        
        public bool Remove(T item)
        {
            return _List.Remove(item);
        }
        
        public void RemoveAt(int index)
        {
            _List.RemoveAt(index);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
