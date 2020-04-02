/***********************************************************************
 * <copyright file="AutoNumberEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// AutoNumberEntity
    /// </summary>
    public class AutoNumberEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoNumberEntity"/> class.
        /// </summary>
        public AutoNumberEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoNumberEntity" /> class.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        /// <param name="value">The value.</param>
        /// <param name="valueLocal">The value local.</param>
        /// <param name="lengthOfValue">The length of value.</param>
        public AutoNumberEntity(int refTypeId, string prefix, string suffix, int value, int valueLocal, int lengthOfValue)
            : this()
        {
            RefTypeId = refTypeId;
            Prefix = prefix;
            Suffix = suffix;
            Value = value;
            ValueLocalCurency = valueLocal;
            LengthOfValue = lengthOfValue;
        }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>
        /// The suffix.
        /// </value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the value local curency.
        /// </summary>
        /// <value>
        /// The value local curency.
        /// </value>
        public int ValueLocalCurency { get; set; }

        /// <summary>
        /// Gets or sets the length of value.
        /// </summary>
        /// <value>
        /// The length of value.
        /// </value>
        public int LengthOfValue { get; set; }
    }
}
