using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LocalResourceField : Attribute
    {
        public LocalResourceField() { }
    }
}
