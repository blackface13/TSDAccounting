﻿/***********************************************************************
 * <copyright file="VendorResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// VendorResponse class
    /// </summary>
    public class VendorResponse: ResponseBase
    {
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int VendorId { get; set; }

        /// <summary>
        /// The vendor
        /// </summary>
        public VendorEntity Vendor;

        /// <summary>
        /// The vendors
        /// </summary>
        public List<VendorEntity> Vendors;
    }
}
