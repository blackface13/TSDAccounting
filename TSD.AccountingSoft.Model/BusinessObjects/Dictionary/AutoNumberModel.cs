/***********************************************************************
 * <copyright file="AutoNumberModel.cs" company="BUCA JSC">
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
 * LinhMC: bổ sung thêm trường lấy số tự động cho loại tiền ĐP ValueLocalCurency
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// AutoNumberModel
    /// </summary>
    public class AutoNumberModel
    {
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
