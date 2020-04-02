/***********************************************************************
 * <copyright file="DBOptionHelper.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.DBOption;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.WindowsForm.Resources
{
    public class DBOptionHelper : IDBOptionsView
    {
        private readonly DBOptionsPresenter _dbOptionsPresenter;

        public IList<DBOptionModel> DBOptions
        {
            set
            {
                if (value == null) return;
                CurrencySymbol = (from dbOption in value where dbOption.OptionId == "CurrencySymbol" select dbOption.OptionValue).First();
                CurrencyDecimalSeparator = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalSeparator" select dbOption.OptionValue).First();
                CurrencyGroupSeparator = (from dbOption in value where dbOption.OptionId == "CurrencyGroupSeparator" select dbOption.OptionValue).First();
                CurrencyDecimalDigits = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalDigits" select dbOption.OptionValue).First();
                PostedDate = (from dbOption in value where dbOption.OptionId == "PostedDate" select dbOption.OptionValue).First();
                CurrencyAccounting = (from dbOption in value where dbOption.OptionId == "CurrencyAccounting" select dbOption.OptionValue).First();
                BaseOfSalary = decimal.Parse((from dbOption in value where dbOption.OptionId == "BaseOfSalary" select dbOption.OptionValue).First());
                CurrencyCodeOfSalary = (from dbOption in value where dbOption.OptionId == "CurrencyCodeOfSalary" select dbOption.OptionValue).First();
                StartedDate = (from dbOption in value where dbOption.OptionId == "StartedDate" select dbOption.OptionValue).First();
                SystemDate = (from dbOption in value where dbOption.OptionId == "SystemDate" select dbOption.OptionValue).First();
                DisplayVourcherMode =int.Parse((from dbOption in value where dbOption.OptionId == "DisplayVourcherMode" select dbOption.OptionValue).First());
                IsPostToParentAccount = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPostToParentAccount" select dbOption.OptionValue).First());
            }
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>
        /// The currency symbol.
        /// </value>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal separator.
        /// </summary>
        /// <value>
        /// The currency decimal separator.
        /// </value>
        public string CurrencyDecimalSeparator { get; set; }

        /// <summary>
        /// Gets or sets the currency group separator.
        /// </summary>
        /// <value>
        /// The currency group separator.
        /// </value>
        public string CurrencyGroupSeparator { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal digits.
        /// </summary>
        /// <value>
        /// The currency decimal digits.
        /// </value>
        public string CurrencyDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the started date.
        /// </summary>
        /// <value>
        /// The started date.
        /// </value>
        public string StartedDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the system date.
        /// </summary>
        /// <value>
        /// The system date.
        /// </value>
        public string SystemDate { get; set; }

        /// <summary>
        /// Gets or sets the currency accounting.
        /// </summary>
        /// <value>
        /// The currency accounting.
        /// </value>
        public string CurrencyAccounting { get; set; }

        /// <summary>
        /// Gets or sets the base of salary.
        /// </summary>
        /// <value>
        /// The base of salary.
        /// </value>
        public string CurrencyCodeOfSalary { get; set; }

        /// <summary>
        /// Gets or sets the base of salary.
        /// </summary>
        /// <value>
        /// The base of salary.
        /// </value>
        public decimal BaseOfSalary { get; set; }

        /// <summary>
        /// Gets or sets the display vourcher mode.
        /// </summary>
        /// <value>
        /// The display vourcher mode.
        /// </value>
        public int DisplayVourcherMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is post to parent account.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is post to parent account; otherwise, <c>false</c>.
        /// </value>
        public bool IsPostToParentAccount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBOptionHelper"/> class.
        /// </summary>
        public DBOptionHelper()
        {
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            _dbOptionsPresenter.Display();
        }
    }
}
