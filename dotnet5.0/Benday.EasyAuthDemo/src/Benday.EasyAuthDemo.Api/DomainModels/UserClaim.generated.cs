using Benday.EfCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benday.Common;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public partial class UserClaim :
        CoreFieldsDomainModelBase
    {
        private DomainModelField<string> _Username = new DomainModelField<string>(default(string));
        [Display(Name = "username")]
        public string Username
        {
            get
            {
                return _Username.Value;
            }
            set
            {
                _Username.Value = value;
            }
        }
        
        private DomainModelField<string> _ClaimName = new DomainModelField<string>(default(string));
        [Display(Name = "claim name")]
        public string ClaimName
        {
            get
            {
                return _ClaimName.Value;
            }
            set
            {
                _ClaimName.Value = value;
            }
        }
        
        private DomainModelField<string> _ClaimValue = new DomainModelField<string>(default(string));
        [Display(Name = "claim value")]
        public string ClaimValue
        {
            get
            {
                return _ClaimValue.Value;
            }
            set
            {
                _ClaimValue.Value = value;
            }
        }
        
        private DomainModelField<int> _UserId = new DomainModelField<int>(default(int));
        [Display(Name = "UserId")]
        public int UserId
        {
            get
            {
                return _UserId.Value;
            }
            set
            {
                _UserId.Value = value;
            }
        }
        
        private User _User;
        [Display(Name = "User")]
        public User User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
            }
        }
        private DomainModelField<string> _ClaimLogicType = new DomainModelField<string>(default(string));
        [Display(Name = "claim type (normal / date)")]
        public string ClaimLogicType
        {
            get
            {
                return _ClaimLogicType.Value;
            }
            set
            {
                _ClaimLogicType.Value = value;
            }
        }
        
        private DomainModelField<DateTime> _StartDate = new DomainModelField<DateTime>(default(DateTime));
        [Display(Name = "claim start date")]
        public DateTime StartDate
        {
            get
            {
                return _StartDate.Value;
            }
            set
            {
                _StartDate.Value = value;
            }
        }
        
        private DomainModelField<DateTime> _EndDate = new DomainModelField<DateTime>(default(DateTime));
        [Display(Name = "claim end date")]
        public DateTime EndDate
        {
            get
            {
                return _EndDate.Value;
            }
            set
            {
                _EndDate.Value = value;
            }
        }
        
        
        
        
        public override bool HasChanges()
        {
            if (base.HasChanges() == true)
            {
                return true;
            }
            
            if (_Username.HasChanges() == true)
            {
                return true;
            }
            
            if (_ClaimName.HasChanges() == true)
            {
                return true;
            }
            
            if (_ClaimValue.HasChanges() == true)
            {
                return true;
            }
            
            if (_UserId.HasChanges() == true)
            {
                return true;
            }
            
            if (_ClaimLogicType.HasChanges() == true)
            {
                return true;
            }
            
            if (_StartDate.HasChanges() == true)
            {
                return true;
            }
            
            if (_EndDate.HasChanges() == true)
            {
                return true;
            }
            
            
            
            return false;
        }
        
        public override void AcceptChanges()
        {
            base.AcceptChanges();
            
            _Username.AcceptChanges();
            
            _ClaimName.AcceptChanges();
            
            _ClaimValue.AcceptChanges();
            
            _UserId.AcceptChanges();
            
            _ClaimLogicType.AcceptChanges();
            
            _StartDate.AcceptChanges();
            
            _EndDate.AcceptChanges();
            
            
        }
        
        public override void UndoChanges()
        {
            base.UndoChanges();
            
            _Username.UndoChanges();
            
            _ClaimName.UndoChanges();
            
            _ClaimValue.UndoChanges();
            
            _UserId.UndoChanges();
            
            _ClaimLogicType.UndoChanges();
            
            _StartDate.UndoChanges();
            
            _EndDate.UndoChanges();
            
            
        }
    }
}

