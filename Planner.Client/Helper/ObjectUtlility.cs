using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Client.Helper
{
    class ObjectUtlility
    {
        public static string PrintProperties(object obj)
        {
            if (obj == null)
            {
                
                return ("The object is null."); ;
            }

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            string _objectProperties = "";

            foreach (var prop in properties)
            {
                string name = prop.Name;
                object? value = prop.GetValue(obj);

                _objectProperties += ($"{name} : {value ?? "null"}") + "\n";
            }

            return _objectProperties;
        }
    }
}
