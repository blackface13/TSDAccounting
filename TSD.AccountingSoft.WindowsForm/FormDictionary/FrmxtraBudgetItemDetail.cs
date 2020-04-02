/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// Class FrmxtraBudgetItemDetail.
    /// </summary>
    public partial class FrmxtraBudgetItemDetail : FrmXtraBaseTreeDetail, IBudgetItemView, IBudgetItemsView
    {
        #region Variables

        private readonly BudgetItemPresenter _budgetItemPresenter;

        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        #endregion

        #region Form event
        public FrmxtraBudgetItemDetail()
        {
            InitializeComponent();
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetItemPresenter = new BudgetItemPresenter(this);
        }

        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _budgetItemPresenter.Display(KeyValue);
            }
            else
            {
                if (CurrentNode != null)
                {
                    txtBudgetItemCode.Text = ((BudgetItemModel)CurrentNode).BudgetItemCode;
                    txtBudgetItemName.Text = ((BudgetItemModel)CurrentNode).BudgetItemName;
                }
            }
            _budgetItemsPresenter.Display();
        }

        protected override void InitControls()
        {
            if ((ActionMode == ActionModeEnum.Edit) && HasChildren)
                grdLookUpParentID.Properties.Enabled = false;
            else
                grdLookUpParentID.Properties.Enabled = true;
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BudgetItemCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetItemCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetItemName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetItemName.Focus();
                return false;
            }
            if (BudgetItemCode == grdLookUpParentID.Text)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCodeSameAsParentError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpParentID.Focus();
                return false;
            }
            if (cboBudgetItemType.EditValue == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyBudgetGroup"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpParentID.Focus();
                return false;
            }
            return true;
        }

        protected override int SaveData()
        {
            return _budgetItemPresenter.Save();
        }

        #endregion

        #region Members
        public int BudgetItemId { get; set; }

        public string BudgetItemCode
        {
            get
            {
                return txtBudgetItemCode.Text;
            }
            set
            {
                txtBudgetItemCode.Text = value;
            }
        }

        public string BudgetItemName
        {
            get
            {
                return txtBudgetItemName.Text;
            }
            set
            {
                txtBudgetItemName.Text = value;
            }
        }

        public string ForeignName
        {
            get
            {
                return txtForeignName.Text;
            }
            set
            {
                txtForeignName.Text = value;
            }
        }

        public int? BudgetGroupId
        {
            get
            {
                if (grdLookUpBudgetGroupID.EditValue == null)
                    return null;
                return (int?)grdLookUpBudgetGroupID.EditValue;
            }
            set
            {
                grdLookUpBudgetGroupID.EditValue = value;
            }
        }

        public int? ParentId
        {
            get
            {
                if (grdLookUpParentID.EditValue == null)
                    return null;
                return (int?)grdLookUpParentID.EditValue;
            }
            set
            {
                grdLookUpParentID.EditValue = value;
            }
        }

        public bool IsParent { get; set; }

        public bool IsFixedItem
        {
            get
            {
                return chkIsFixedItem.Checked;
            }
            set
            {
                chkIsFixedItem.Checked = value;
            }
        }

        public bool IsExpandItem
        {
            get
            {
                return chkIsExpandItem.Checked;
            }
            set
            {
                chkIsExpandItem.Checked = value;
            }
        }

        public bool IsNoAllocate
        {
            get
            {
                return chkIsNoAllocate.Checked;
            }
            set
            {
                chkIsNoAllocate.Checked = value;
            }
        }

        public bool IsOrganItem
        {
            get
            {
                return chkIsOrganItem.Checked;
            }
            set
            {
                chkIsOrganItem.Checked = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return chkIsActive.Checked;
            }
            set
            {
                chkIsActive.Checked = value;
            }
        }

        public int BudgetItemType
        {
            get
            {
                return cboBudgetItemType.SelectedIndex + 1;
            }
            set
            {
                cboBudgetItemType.SelectedIndex = value - 1;
            }
        }

        public bool IsReceipt
        {
            get
            {
                return radIsReceipt.SelectedIndex == 0;
            }
            set
            {
                radIsReceipt.SelectedIndex = value ? 0 : 1;
            }
        }

        public decimal Rate
        {
            get { return Convert.ToDecimal(txtRate.EditValue); }
            set { txtRate.EditValue = value; }
        }

        public bool IsShowOnVoucher
        {
            get { return chkIsShowOnVoucher.Checked; }
            set { chkIsShowOnVoucher.Checked = value; }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                GridLookUpItem.BudgetItem(value ?? new List<BudgetItemModel>(), grdLookUpParentID, grdLookUpParentIDView, "BudgetItemCode", KeyFieldName);
                GridLookUpItem.BudgetItem(value == null ? new List<BudgetItemModel>() : value.Where(c => (c.BudgetItemType == 1 || c.BudgetItemType == 2)).ToList(), grdLookUpBudgetGroupID, grdLookUpBudgetGroupIDView, "BudgetItemCode", KeyFieldName);
            }
        }

        #endregion

        #region Control event

        private void grdLookUpParentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpParentID.SelectionLength == grdLookUpParentID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpParentID.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpBudgetGroupID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpBudgetGroupID.SelectionLength == grdLookUpBudgetGroupID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpBudgetGroupID.EditValue = null;
                e.Handled = true;
            }
        }

        private void cboBudgetItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboBudgetItemType.SelectedIndex==2)
            {
                chkIsShowOnVoucher.Visible = true;
            }
            else
            {
                chkIsShowOnVoucher.Visible = false;
            }
        }

        #endregion
    }
}

