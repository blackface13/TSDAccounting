/***********************************************************************
 * <copyright file="AutoNumberModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangNK@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
 public  class AutoNumberListModel
    {
        public string  TableCode { get; set; }

        public string TableName { get; set; }

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public int Value { get; set; }

        public int LengthOfValue { get; set; }

    }
}
