namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public class DomainModelField<T>
    {
        public DomainModelField(T value)
        {
            _CurrentValue = value;
            AcceptChanges();
        }
        
        public bool HasChanges()
        {
            if (_CurrentValue == null && _OriginalValue != null)
            {
                return true;
            }
            else if (_CurrentValue != null && _OriginalValue == null)
            {
                return true;
            }
            else if (_CurrentValue == null && _OriginalValue == null)
            {
                return false;
            }
            else if (_CurrentValue.Equals(_OriginalValue) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void AcceptChanges()
        {
            _OriginalValue = _CurrentValue;
        }
        
        public void UndoChanges()
        {
            _CurrentValue = _OriginalValue;
        }
        
        private T _OriginalValue;
        private T _CurrentValue;
        
        public T Value
        {
            get
            {
                return _CurrentValue;
            }
            set
            {
                _CurrentValue = value;
            }
        }
    }
}
