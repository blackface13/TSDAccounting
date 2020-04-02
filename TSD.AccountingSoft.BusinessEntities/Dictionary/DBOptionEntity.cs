/***********************************************************************
 * <copyright file="DBOptionEntity.cs" company="BUCA JSC">
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
    /// DBOptionEntity
    /// </summary>
    public class DBOptionEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBOptionEntity"/> class.
        /// </summary>
        public DBOptionEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBOptionEntity"/> class.
        /// </summary>
        /// <param name="optionId">The option identifier.</param>
        /// <param name="optionValue">The option value.</param>
        /// <param name="valueType">Type of the value.</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="description">The description.</param>
        public DBOptionEntity(string optionId, string optionValue, int valueType, bool isSystem, string description)
            : this()
        {
            OptionId = optionId;
            OptionValue = optionValue;
            ValueType = valueType;
            IsSystem = isSystem;
            Description = description;
        }

        /// <summary>
        /// Gets or sets the option identifier.
        /// </summary>
        /// <value>
        /// The option identifier.
        /// </value>
        public string OptionId { get; set; }

        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        /// <value>
        /// The option value.
        /// </value>
        public string OptionValue { get; set; }

        /// <summary>
        /// Gets or sets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        public int ValueType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }
    }
}