using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    public class PlanReceiptTempateItemEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanReceiptTempateItemEntity"/> class.
        /// </summary>
        public PlanReceiptTempateItemEntity()
        {
            AddRule(new ValidateRequired("ItemName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanReceiptTempateItemEntity"/> class.
        /// </summary>
        /// <param name="planReceiptTempateItemEntityId">The plan receipt tempate item entity identifier.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="numberOrder">The number order.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <param name="budgetItemCodeList">The budget item code list.</param>
        public PlanReceiptTempateItemEntity(int planReceiptTempateItemEntityId, string itemName, string numberOrder,
                                            string fontStyle, string budgetItemCodeList)
        {
            PlanReceiptTempateItemEntityId = planReceiptTempateItemEntityId;
            ItemName = itemName;
            NumberOrder = numberOrder;
            FontStyle = fontStyle;
            BudgetItemCodeList = budgetItemCodeList;
        }

        /// <summary>
        /// Gets or sets the plan receipt tempate item entity identifier.
        /// </summary>
        /// <value>
        /// The plan receipt tempate item entity identifier.
        /// </value>
        public int PlanReceiptTempateItemEntityId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the number order.
        /// </summary>
        /// <value>
        /// The number order.
        /// </value>
        public string NumberOrder { get; set; }

        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        /// <value>
        /// The font style.
        /// </value>
        public string FontStyle { get; set; }

        /// <summary>
        /// Gets or sets the budget item code list.
        /// </summary>
        /// <value>
        /// The budget item code list.
        /// </value>
        public string BudgetItemCodeList { get; set; }
    }
}
