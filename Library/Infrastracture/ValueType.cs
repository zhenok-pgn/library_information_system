using System;
using System.Collections.Generic;
using System.Reflection;

namespace Library.Infrastructure
{
    public class ValueType<T> : IDisplayable
        where T : class
    {
        public static List<PropertyInfo> Properties { private set; get; }
        private static Type type;

        public ValueType()
        {
            Properties = new List<PropertyInfo>();
            type = typeof(T);
            var prop = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in prop)
                Properties.Add(p);
        }

        public static List<PropertyInfo> GetProperties()
        {
            return Properties;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public bool Equals(T obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            else
            {
                foreach (var p in Properties)
                {
                    var thisValue = type.GetProperty(p.Name).GetValue(this);
                    var thatValue = type.GetProperty(p.Name).GetValue(obj);
                    if (thisValue == null && thatValue == null) continue;
                    if (thisValue == null && thatValue != null || !thisValue.Equals(thatValue))
                        return false;
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                for (int i = 0; i < Properties.Count; i++)
                {
                    var value = type.GetProperty(Properties[i].Name).GetValue(this);
                    hash = hash * 23 + (value == null ? 0 : value.GetHashCode());
                }
                return hash;
            }
        }
    }

    public interface IDisplayable
    {

    }
}
