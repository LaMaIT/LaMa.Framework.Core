using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LaMa.Framework.Core.Web.Helpers
{
    /// <summary>
    /// Translate anonymous objects to objects
    /// </summary>
    public class TypeTranslaterHelper
    {
        public static TDictionary TranslateObjectToDictionary<TDictionary>(object value, TDictionary instance) where TDictionary :  IDictionary<string, object>
         {
             if (instance==null)
                throw new ArgumentNullException("instance",string.Format("You need to pass an instance of a dictionary"));

             var valueType = value.GetType();

             //Get all the public properties that can be read.
             //Also ignore the indexed properties (this[index])
             var properties = valueType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                         .Where(x=>x.GetMethod!=null && x.GetIndexParameters().Length==0);
             
             foreach (PropertyInfo property in properties)
             {
                 instance[property.Name] = GetValueFromPropertyInfo<object>(property,value);

             }
             return instance;
        }

        private static T GetValueFromPropertyInfo<T>(PropertyInfo property,object o)
        {
           //Todo find a way to make this work faster
            return (T)property.GetValue(o);
            
        }
       
    }
     
}