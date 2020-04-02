/***********************************************************************
 * <copyright file="FrmWaitForm.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, August 27, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using DevExpress.XtraWaitForm;

namespace TSD.AccountingSoft.WindowsForm
{
    public partial class FrmWaitForm : WaitForm
    {
        public FrmWaitForm()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void FrmWaitForm_Load(object sender, System.EventArgs e)
        {
            SetCaption("Chương trình đang sao lưu dữ liệu");
            SetDescription("Vui lòng đợi ...");
        }
    }
}