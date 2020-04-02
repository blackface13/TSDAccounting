namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraGetBudgetItemList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSourceList = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnSellectAll = new DevExpress.XtraEditors.SimpleButton();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(379, 347);
            this.btnSave.Text = "No";
            this.btnSave.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(455, 347);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 347);
            // 
            // groupboxMain
            // 
            this.groupboxMain.Location = new System.Drawing.Point(392, 256);
            this.groupboxMain.Size = new System.Drawing.Size(130, 54);
            this.groupboxMain.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(374, 347);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(9, 316);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 25);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "Chọn tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnSellectAll
            // 
            this.btnUnSellectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnSellectAll.Location = new System.Drawing.Point(90, 316);
            this.btnUnSellectAll.Name = "btnUnSellectAll";
            this.btnUnSellectAll.Size = new System.Drawing.Size(96, 25);
            this.btnUnSellectAll.TabIndex = 5;
            this.btnUnSellectAll.Text = "Bỏ chọn tất cả";
            this.btnUnSellectAll.Click += new System.EventHandler(this.btnUnSellectAll_Click);
            // 
            // treeList
            // 
            this.treeList.DataSource = this.bindingSourceList;
            this.treeList.Location = new System.Drawing.Point(9, 9);
            this.treeList.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeList.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.Size = new System.Drawing.Size(516, 301);
            this.treeList.TabIndex = 6;
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList_NodeCellStyle_1);
            this.treeList.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList_CustomDrawNodeCell_1);
            // 
            // FrmXtraGetBudgetItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 381);
            this.ComponentName = "Chỉ tiêu";
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.btnUnSellectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnOK);
            this.EventTime = new System.DateTime(2019, 11, 7, 9, 49, 30, 901);
            this.FormCaption = "chỉ tiêu";
            this.Name = "FrmXtraGetBudgetItemList";
            this.Reference = "THÊM CHỈ TIÊU - ID ";
            this.Text = "FrmXtraGetBudgetItemList";
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.Controls.SetChildIndex(this.btnUnSellectAll, 0);
            this.Controls.SetChildIndex(this.treeList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceList;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnSellectAll;
        private DevExpress.XtraTreeList.TreeList treeList;

    }
}