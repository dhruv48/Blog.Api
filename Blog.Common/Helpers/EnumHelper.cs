using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.Helpers
{
    public class EnumHelper
    {

        //public static T GetValueFromDescription<T>(string description) where T : Enum
        //{
        //    foreach (var field in typeof(T).GetFields())
        //    {
        //        if (Attribute.GetCustomAttribute(field,
        //        typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        //        {
        //            if (attribute.Description == description)
        //                return (T)field.GetValue(null);
        //        }
        //        else
        //        {
        //            if (field.Name == description)
        //                return (T)field.GetValue(null);
        //        }
        //    }
        //    return default;
        //    //throw new ArgumentException("Not found.", nameof(description));
        //    // Or return default(T);
        //}
        //public static string GetDescription(Enum @enum)
        //{
        //    if (@enum == null || @enum.ToString() == "0")
        //        return string.Empty;

        //    string description = @enum.ToString();

        //    try
        //    {
        //        FieldInfo fi = @enum.GetType().GetField(@enum.ToString());

        //        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        //        if (attributes.Length > 0)
        //            description = attributes[0].Description;
        //    }
        //    catch
        //    {
        //    }

        //    return description;
        //}
    }
}
