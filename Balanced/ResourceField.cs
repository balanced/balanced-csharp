using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ResourceField : Attribute
    {
        string _field;
        bool _serialize = true;
        bool _link = false;

        public string field
        {
            get { return _field; }
            set { _field = value; }
        }

        public bool serialize
        {
            get { return _serialize; }
            set { _serialize = value; }
        }

        public bool link
        {
            get { return _link; }
            set { _link = value; }
        }

        public ResourceField() { }
    }
}
