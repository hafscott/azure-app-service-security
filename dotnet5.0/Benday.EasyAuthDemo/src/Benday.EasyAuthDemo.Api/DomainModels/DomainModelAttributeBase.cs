using System;
using Benday.Common;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public class DomainModelAttributeBase : CoreFieldsDomainModelBase, IDomainModelAttribute
    {
        private DomainModelField<string> _AttributeKey = new DomainModelField<string>(default(string));
        public string AttributeKey
        {
            get
            {
                return _AttributeKey.Value;
            }
            set
            {
                _AttributeKey.Value = value;
            }
        }
        
        private DomainModelField<string> _AttributeValue = new DomainModelField<string>(default(string));
        public string AttributeValue
        {
            get
            {
                return _AttributeValue.Value;
            }
            set
            {
                _AttributeValue.Value = value;
            }
        }
        
        public override bool HasChanges()
        {
            if (base.HasChanges() == true)
            {
                return true;
            }
            
            if (_AttributeKey.HasChanges() == true)
            {
                return true;
            }
            if (_AttributeValue.HasChanges() == true)
            {
                return true;
            }
            
            
            return false;
        }
        
        public override void AcceptChanges()
        {
            base.AcceptChanges();
            
            _AttributeKey.AcceptChanges();
            _AttributeValue.AcceptChanges();
            
        }
        
        public override void UndoChanges()
        {
            base.UndoChanges();
            
            _AttributeKey.UndoChanges();
            _AttributeValue.UndoChanges();
            
        }
        
    }
}
