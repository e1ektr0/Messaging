using System;
using System.ComponentModel;
using System.Linq;

namespace Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                return "";
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            var description = attribute == null ? GetValue(value) : attribute.Description;
            return description;
        }

        public static string GetValue(Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            if (attribute != null)
            {
                return attribute.Description;
            }
            return value.ToString().Replace('_', ' ');
        }
    }
}