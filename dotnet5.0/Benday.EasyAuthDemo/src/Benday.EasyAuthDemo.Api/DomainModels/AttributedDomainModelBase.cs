using Benday.EfCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.DomainModels
{
    public partial class AttributedDomainModelBase<T> : CoreFieldsDomainModelBase, IAttributedDomainModel
        where T : CoreFieldsDomainModelBase, IDomainModelAttribute, new()
    {
        private List<T> _Attributes;
        public List<T> Attributes
        {
            get
            {
                if (_Attributes == null)
                {
                    _Attributes = new List<T>();
                }
                
                return _Attributes;
            }
            set
            {
                _Attributes = value;
            }
        }
        
        public List<DomainModelBase> GetAttributes()
        {
            return new List<DomainModelBase>(Attributes);
        }
        
        public string GetAttributeValue(string key)
        {
            var match = (from temp in Attributes
            where temp.AttributeKey == key
            select temp).FirstOrDefault();
            
            if (match == null)
            {
                return null;
            }
            else
            {
                return match.AttributeValue;
            }
        }
        
        public void SetAttributeValue(string key, string value,
            string status = ApiConstants.DefaultAttributeStatus)
        {
            var match = (from temp in Attributes
            where temp.AttributeKey == key
            select temp).FirstOrDefault();
            
            if (match == null)
            {
                match = new T();
                
                match.AttributeKey = key;
                match.AttributeValue = value;
                
                Attributes.Add(match);
            }
            else
            {
                match.AttributeValue = value;
            }
            
            match.Status = status;
        }
    }
}
