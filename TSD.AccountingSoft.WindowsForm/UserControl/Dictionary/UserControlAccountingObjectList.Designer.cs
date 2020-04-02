namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    partial class UserControlAccountingObjectList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UserControlAccountingObjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormCaption = "Danh mục đối tượng khác";
            this.FormDetail = "FrmXtraAccountingObjectDetail";
            this.Name = "UserControlAccountingObjectList";
            this.NamespaceForm = "TSD.AccountingSoft.WindowsForm.FormDictionary";
            this.TablePrimaryKey = "AccountingObjectId";
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
