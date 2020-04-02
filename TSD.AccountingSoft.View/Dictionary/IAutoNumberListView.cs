/***********************************************************************
 * <copyright file="IStocksView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
   public class IAutoNumberListView
    {

      public  string TableCode { get; set; }
      public  string TableName { get; set; }
      public  string Prefix { get; set; }
      public  string Suffix { get; set; }
      public int Value { get; set; }
      public int LengthOfValue { get; set; }
    }
}
