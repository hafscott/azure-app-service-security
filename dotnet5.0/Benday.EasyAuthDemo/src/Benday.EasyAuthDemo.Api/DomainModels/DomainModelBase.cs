using System;
using Benday.Common;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public abstract class DomainModelBase : IInt32Identity
    {
        private DomainModelField<int> _Id = new DomainModelField<int>(default(int));
        public int Id
        {
            get
            {
                return _Id.Value;
            }
            set
            {
                _Id.Value = value;
            }
        }
        
        public virtual bool HasChanges()
        {
            if (_Id.HasChanges() == true)
            {
                return true;
            }
            
            return false;
        }
        
        public virtual void AcceptChanges()
        {
            _Id.AcceptChanges();
        }
        
        public virtual void UndoChanges()
        {
            _Id.UndoChanges();
        }
    }
}
