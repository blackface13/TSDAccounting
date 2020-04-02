/***********************************************************************
 * <copyright file="FrmXtraBaseParameter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, August 25, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace TSD.AccountingSoft.Report.BaseParameterForm
{
    public partial class FrmXtraBaseParameter : DevExpress.XtraEditors.XtraForm
    {
        public FrmXtraBaseParameter()
        {
            InitializeComponent();
        }

        protected virtual bool ValidData()
        {
            return true;
        }

        protected virtual void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!ValidData())
            {
                btnOk.DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }

        protected virtual void gridLookUpEdit_Enter(object sender, EventArgs e)
        {
            GridLookUpEdit lookUp = sender as GridLookUpEdit;
            BeginInvoke(new Action(() => { lookUp.ShowPopup(); }));
        }
    }
}