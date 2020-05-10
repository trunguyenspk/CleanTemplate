using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Domain.Enumerations
{
    public abstract class Enumeration : IComparable
    {
        public int Id { get; private set; }
        public string Value { get; private set; }

        protected Enumeration(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override string ToString() => Value;
        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

    }
}
