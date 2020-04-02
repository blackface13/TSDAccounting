using System;
using System.Collections.Generic;
using System.Linq;

namespace TSD.AccountingSoft.DataHelpers.DynamicLinq.cs
{
    /// <summary>
    /// 
    /// </summary>
    internal class Signature : IEquatable<Signature>
    {
        /// <summary>
        /// The properties
        /// </summary>
        public DynamicProperty[] Properties;
        public readonly int HashCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Signature"/> class.
        /// </summary>
        /// <param name="properties">The properties.</param>
        public Signature(IEnumerable<DynamicProperty> properties)
        {
            var dynamicProperties = properties as DynamicProperty[] ?? properties.ToArray();
            Properties = dynamicProperties.ToArray();
            HashCode = 0;
            foreach (var p in dynamicProperties)
            {
                HashCode ^= p.Name.GetHashCode() ^ p.Type.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance. />
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Signature && Equals((Signature)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Signature other)
        {
            if (Properties.Length != other.Properties.Length) return false;
            return !Properties.Where((t, i) => t.Name != other.Properties[i].Name || t.Type != other.Properties[i].Type).Any();
        }
    }
}
