/***********************************************************************
 * <copyright file="IDBOptionView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IDBOptionView
    {
        /// <summary>
        /// Gets or sets the option identifier.
        /// </summary>
        /// <value>
        /// The option identifier.
        /// </value>
        string OptionId { get; set; }

        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        /// <value>
        /// The option value.
        /// </value>
        string OptionValue { get; set; }

        /// <summary>
        /// Gets or sets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        int ValueType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
        bool IsSystem { get; set; }
    }
}
