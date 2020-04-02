/***********************************************************************
 * <copyright file="VoucherTypeEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// class VoucherTypeEntity
    /// </summary>
    public class VoucherTypeEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherTypeEntity"/> class.
        /// </summary>
        public VoucherTypeEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherTypeEntity"/> class.
        /// </summary>
        /// <param name="voucherTypeId">The voucher type identifier.</param>
        /// <param name="voucherTypeName">Name of the voucher type.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public VoucherTypeEntity(int voucherTypeId, string voucherTypeName, bool isActive)
            : this()
        {
            VoucherTypeId = voucherTypeId;
            VoucherTypeName = voucherTypeName;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the voucher type identifier.
        /// </summary>
        /// <value>
        /// The voucher type identifier.
        /// </value>
        public int VoucherTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the voucher type.
        /// </summary>
        /// <value>
        /// The name of the voucher type.
        /// </value>
        public string VoucherTypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
