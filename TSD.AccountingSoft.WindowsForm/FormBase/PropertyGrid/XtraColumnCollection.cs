/***********************************************************************
 * <copyright file="XtraColumnCollection.cs" company="BUCA JSC">
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

using System.Collections;


namespace TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid
{
    public class XtraColumnCollection : CollectionBase
    {
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public XtraColumn this[int index]
        {
            get { return (XtraColumn)List[index]; }
        }

        /// <summary>
        /// Adds the specified xtra column.
        /// </summary>
        /// <param name="xtraColumn">The xtra column.</param>
        public void Add(XtraColumn xtraColumn)
        {
            List.Add(xtraColumn);
        }

        /// <summary>
        /// Removes the specified xtra column.
        /// </summary>
        /// <param name="xtraColumn">The xtra column.</param>
        public void Remove(XtraColumn xtraColumn)
        {
            List.Remove(xtraColumn);
        }
    }
}
