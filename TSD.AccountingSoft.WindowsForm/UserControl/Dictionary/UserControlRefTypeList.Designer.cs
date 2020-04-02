namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    partial class UserControlRefTypeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlRefTypeList));
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // imageToobarCollection
            // 
            this.imageToobarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToobarCollection.ImageStream")));
            this.imageToobarCollection.Images.SetKeyName(0, "list-add.png");
            this.imageToobarCollection.Images.SetKeyName(1, "list-delete.png");
            this.imageToobarCollection.Images.SetKeyName(2, "list-edit.png");
            this.imageToobarCollection.Images.SetKeyName(3, "list-search.png");
            this.imageToobarCollection.Images.SetKeyName(4, "document-update.png");
            this.imageToobarCollection.Images.SetKeyName(5, "help2.png");
            this.imageToobarCollection.Images.SetKeyName(6, "print.png");
            this.imageToobarCollection.Images.SetKeyName(7, "document_refresh.png");
            // 
            // UserControlRefTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ComponentName = "Tài khoản ngầm định";
            this.EventAction = 4;
            this.EventTime = new System.DateTime(2019, 11, 15, 9, 34, 55, 652);
            this.FormCaption = "Tài khoản ngầm định";
            this.FormDetail = "FrmXtraRefTypeListDetail";
            this.Name = "UserControlRefTypeList";
            this.NamespaceForm = "TSD.AccountingSoft.WindowsForm.FormDictionary";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "TÀI KHOẢN NGẦM ĐỊNH - ID ";
            this.TablePrimaryKey = "RefTypeId";
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
