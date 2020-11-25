using System;
using Benday.Common;
using System.ComponentModel.DataAnnotations;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public abstract class CoreFieldsDomainModelBase : DomainModelBase
    {
        private DomainModelField<string> _Status = new DomainModelField<string>(default(string));
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Status
        {
            get
            {
                return _Status.Value;
            }
            set
            {
                _Status.Value = value;
            }
        }
        
        private DomainModelField<string> _CreatedBy = new DomainModelField<string>(default(string));
        public string CreatedBy
        {
            get
            {
                return _CreatedBy.Value;
            }
            set
            {
                _CreatedBy.Value = value;
            }
        }
        
        private DomainModelField<DateTime> _CreatedDate = new DomainModelField<DateTime>(default(DateTime));
        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate.Value;
            }
            set
            {
                _CreatedDate.Value = value;
            }
        }
        
        private DomainModelField<string> _LastModifiedBy = new DomainModelField<string>(default(string));
        public string LastModifiedBy
        {
            get
            {
                return _LastModifiedBy.Value;
            }
            set
            {
                _LastModifiedBy.Value = value;
            }
        }
        
        private DomainModelField<DateTime> _LastModifiedDate = new DomainModelField<DateTime>(default(DateTime));
        public DateTime LastModifiedDate
        {
            get
            {
                return _LastModifiedDate.Value;
            }
            set
            {
                _LastModifiedDate.Value = value;
            }
        }
        
        private DomainModelField<byte[]> _Timestamp = new DomainModelField<byte[]>(default(byte[]));
        public byte[] Timestamp
        {
            get
            {
                return _Timestamp.Value;
            }
            set
            {
                _Timestamp.Value = value;
            }
        }
        
        public override bool HasChanges()
        {
            if (base.HasChanges() == true)
            {
                return true;
            }
            
            if (_Status.HasChanges() == true)
            {
                return true;
            }
            
            if (_CreatedBy.HasChanges() == true)
            {
                return true;
            }
            
            if (_CreatedDate.HasChanges() == true)
            {
                return true;
            }
            
            if (_LastModifiedBy.HasChanges() == true)
            {
                return true;
            }
            
            if (_LastModifiedDate.HasChanges() == true)
            {
                return true;
            }
            
            if (_Timestamp.HasChanges() == true)
            {
                return true;
            }
            
            return false;
        }
        
        public override void AcceptChanges()
        {
            _Status.AcceptChanges();
            _CreatedBy.AcceptChanges();
            _CreatedDate.AcceptChanges();
            _LastModifiedBy.AcceptChanges();
            _LastModifiedDate.AcceptChanges();
            _Timestamp.AcceptChanges();
            base.AcceptChanges();
        }
        
        public override void UndoChanges()
        {
            _Status.UndoChanges();
            _CreatedBy.UndoChanges();
            _CreatedDate.UndoChanges();
            _LastModifiedBy.UndoChanges();
            _LastModifiedDate.UndoChanges();
            _Timestamp.UndoChanges();
            base.UndoChanges();
        }
    }
}
