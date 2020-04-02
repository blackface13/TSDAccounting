/***********************************************************************
 * <copyright file="AutoNumberPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.AutoNumber
{

    /// <summary>
    /// Class AutoNumberPresenter.
    /// </summary>
    public class AutoNumberPresenter : Presenter<IAutoNumberView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoNumberPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AutoNumberPresenter(IAutoNumberView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the type of the by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        public void DisplayByRefType(int refType)
        {
            if (refType == 0) return;

            var autoId = Model.GetAutoNumberByRefType(refType);
            if (autoId == null) return;
            View.Prefix = autoId.Prefix;
            View.Value = autoId.Value;
            View.ValueLocalCurency = autoId.ValueLocalCurency;
            View.LengthOfValue = autoId.LengthOfValue;
            View.Suffix = autoId.Suffix;
        }
    }
}
