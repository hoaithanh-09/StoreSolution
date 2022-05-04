using System;
using System.Reflection;

namespace Store.Services.Utilities
{
	public static class ObjectUtilities
	{
		public static bool IsAnyNullOrEmpty(object obj)
        {
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(obj);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

