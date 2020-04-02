/***********************************************************************
 * <copyright file="InventoryItemModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class InventoryItemModel.
    /// </summary>
    public class InventoryItemReportModel 
    {

        /// <summary>
        /// Gets or sets the InventoryItemId identifier.
        /// </summary>
        /// <value>The InventoryItemId.</value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
      //  public string InventoryItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The InventoryItem Name .</value>
        public string InventoryItemName { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>The account code.</value>
    //    public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the cost method.
        /// </summary>
        /// <value>The cost method.</value>
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public decimal AmountOc { get; set; } 

      
    }
}
