using System.Linq.Expressions;

namespace TSD.AccountingSoft.DataHelpers.DynamicLinq.cs
{
    /// <summary>
    /// 
    /// </summary>
    internal class DynamicOrdering
    {
        /// <summary>
        /// The selector
        /// </summary>
        public Expression Selector;
        /// <summary>
        /// The ascending
        /// </summary>
        public bool Ascending;
    }
}
