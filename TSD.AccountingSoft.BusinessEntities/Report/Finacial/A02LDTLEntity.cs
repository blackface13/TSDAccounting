/***********************************************************************
 * <copyright file="A02LDTLEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Friday, December 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    public class A02LDTLEntity : BusinessEntities
    {

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public int OrderNumber { get; set; }

        public string EmployeeName { get; set; }

        public string JobCandidateName { get; set; }

        public decimal NumberSHP { get; set; }

        public decimal SHP { get; set; }

        public decimal PCVS { get; set; }

        public decimal PCKiemNhiem { get; set; }

        public decimal TroCapCT { get; set; }

        public decimal TongCong { get; set; }
        
        public decimal QuiDoi { get; set; }

        public decimal ExchangeRate { get; set; }

        public string CurrencyCode { get; set; }

        public DateTime CalcDate { get; set; }

        public decimal BaseOfSalary { get; set; }

        public int  WorkDay{ get; set; }
        
    }
}
