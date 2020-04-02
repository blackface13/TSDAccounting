/***********************************************************************
 * <copyright file="EstimateDetailStatementPartBEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:     tudt@buca.vn
 * Website:
 * Create Date: 23 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessEntities.Report.Estimate
{
    /// <summary>
    /// class EstimateDetailStatementPartBEntity 
    /// </summary>
    public class EstimateDetailStatementPartBEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailStatementPartBEntity"/> class.
        /// </summary>
        public EstimateDetailStatementPartBEntity()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailStatementPartBEntity"/> class.
        /// </summary>
        /// <param name="estimateDetailStatementPartBId">The estimate detail statement part b identifier.</param>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="description">The description.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="note">The note.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public EstimateDetailStatementPartBEntity(int estimateDetailStatementPartBId, short orderNumber, string description,
            decimal amount, string note, bool isActive)
            : this()
        {
            EstimateDetailStatementPartBId = estimateDetailStatementPartBId;
            OrderNumber = orderNumber;
            Description = description;
            Amount = amount;
            Note = note;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the estimate detail statement part b identifier.
        /// </summary>
        /// <value>
        /// The estimate detail statement part b identifier.
        /// </value>
        public int EstimateDetailStatementPartBId { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public short OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
