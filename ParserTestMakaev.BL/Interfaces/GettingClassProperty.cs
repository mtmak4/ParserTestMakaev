using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParserTestMakaev.BL.Interfaces
{
    public  class IGettingClassProperty
    {
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(User);
                PropertyInfo propInfo = myType.GetProperty(propertyName);
                if (propInfo.GetType()==typeof(DateTime))
                {
                    return (DateTime)propInfo.GetValue(this, null);
                }
                if (propInfo.GetType() == typeof(string))
                {
                    return (string)propInfo.GetValue(this, null);
                }
                return propInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(User);
                PropertyInfo propInfo = myType.GetProperty(propertyName);
                propInfo.SetValue(this, value, null);
            }
        }
    }
}
