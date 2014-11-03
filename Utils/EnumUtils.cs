using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Common.Lib.Utils
{
  public static class EnumUtils
  {
    public static string GetDescription<T>(this object enumerationValue) where T : struct
    {
      Type type = enumerationValue.GetType();
      if (!type.IsEnum)
      {
        throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
      }

      //Tries to find a DescriptionAttribute for a potential friendly name
      //for the enum
      MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
      if (memberInfo != null && memberInfo.Length > 0)
      {
        object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attrs != null && attrs.Length > 0 &&
            attrs.Where(t => t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault() != null)
        {
          //Pull out the description value
          var firstOrDefault = (DescriptionAttribute)attrs.Where(t => t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault();
          if (
              firstOrDefault != null)
            return firstOrDefault.Description;
        }
      }
      //If we have no description attribute, just return the ToString of the enum
      return enumerationValue.ToString();
    }


    public static T GetValueFromDescription<T>(string description)
    {
      var type = typeof(T);
      if (!type.IsEnum) throw new InvalidOperationException();
      foreach (var field in type.GetFields())
      {
        var attribute = Attribute.GetCustomAttribute(field,
            typeof(DescriptionAttribute)) as DescriptionAttribute;
        if (attribute != null)
        {
          if (attribute.Description == description)
            return (T)field.GetValue(null);
        }
        else
        {
          if (field.Name == description)
            return (T)field.GetValue(null);
        }
      }
      throw new ArgumentException("Not found.", "description");
      // or return default(T);
    }


    public static T ToEnumValue<T>(this string enumerationDescription) where T : struct
    {
      Type type = typeof(T);
      if (!type.IsEnum)
        throw new ArgumentException("ToEnumValue<T>(): Must be of enum type", "T");
      foreach (object val in System.Enum.GetValues(type))
        if (val.GetDescription<T>() == enumerationDescription)
          return (T)val;
      throw new ArgumentException("ToEnumValue<T>(): Invalid description for enum " + type.Name, "enumerationDescription");
    }

  }
}
