using System;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// AudittingLogEntity
    /// </summary>
    public class AudittingLogEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudittingLogEntity"/> class.
        /// </summary>
        public AudittingLogEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudittingLogEntity"/> class.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="loginName">Name of the login.</param>
        /// <param name="computerName">Name of the computer.</param>
        /// <param name="eventTime">The event time.</param>
        /// <param name="componentName">Name of the component.</param>
        /// <param name="eventAction">The event action.</param>
        /// <param name="reference">The reference.</param>
        /// <param name="amount">The amount.</param>
        public AudittingLogEntity(int eventId, string loginName, string computerName, DateTime eventTime, string componentName, int eventAction, string reference, 
            decimal amount)
            : this()
        {
            EventId = eventId;
            LoginName = loginName;
            ComputerName = computerName;
            EventTime = eventTime;
            ComponentName = componentName;
            EventAction = eventAction;
            Reference = reference;
            Amount = amount;
        }

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName { get; set; }

        /// <summary>
        /// Gets or sets the name of the computer.
        /// </summary>
        /// <value>
        /// The name of the computer.
        /// </value>
        public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        /// <value>
        /// The name of the component.
        /// </value>
        public string ComponentName { get; set; }

        /// <summary>
        /// Gets or sets the event action.
        /// </summary>
        /// <value>
        /// The event action.
        /// </value>
        public int EventAction { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference { get; set; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
    }
}
