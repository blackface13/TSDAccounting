using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
  public  class B14QEntity
    {
        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
        public string InventoryItemName { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the quantity opening.
        /// </summary>
        /// <value>
        /// The quantity opening.
        /// </value>
        public int QuantityOpening { get; set; }
        /// <summary>
        /// Gets or sets the quantity inward stock.
        /// </summary>
        /// <value>
        /// The quantity inward stock.
        /// </value>
        public int QuantityInwardStock { get; set; }
        /// <summary>
        /// Gets or sets the quantity outward stock.
        /// </summary>
        /// <value>
        /// The quantity outward stock.
        /// </value>
        public int QuantityOutwardStock { get; set; }
        /// <summary>
        /// Gets or sets the quantity closing.
        /// </summary>
        /// <value>
        /// The quantity closing.
        /// </value>
        public int QuantityClosing { get; set; }

        /// <summary>
        /// Gets or sets the org price opening.
        /// </summary>
        /// <value>
        /// The org price opening.
        /// </value>
        public decimal OrgPriceOpening { get; set; }

        /// <summary>
        /// Gets or sets the org price inward stock.
        /// </summary>
        /// <value>
        /// The org price inward stock.
        /// </value>
        public decimal OrgPriceInwardStock { get; set; }

        /// <summary>
        /// Gets or sets the org price outward stock.
        /// </summary>
        /// <value>
        /// The org price outward stock.
        /// </value>
        public decimal OrgPriceOutwardStock { get; set; }

        /// <summary>
        /// Gets or sets the org price closing.
        /// </summary>
        /// <value>
        /// The org price closing.
        /// </value>
        public decimal OrgPriceClosing { get; set; }
        public int FreeQuantity { get; set; }
        public int CancelQuantity { get; set; }
        public int TotalQuantity { get; set; } 


    }
}
