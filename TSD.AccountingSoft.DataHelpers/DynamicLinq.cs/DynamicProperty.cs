using System;

namespace TSD.AccountingSoft.DataHelpers.DynamicLinq.cs
{
    /// <summary>
    /// 
    /// </summary>
    public class DynamicProperty
    {
        readonly string _name;
        readonly Type _type;
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicProperty"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentNullException">
        /// name
        /// or
        /// type
        /// </exception>
        public DynamicProperty(string name, Type type)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (type == null) throw new ArgumentNullException("type");
            this._name = name;
            this._type = type;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type
        {
            get { return _type; }
        }
    }
}
