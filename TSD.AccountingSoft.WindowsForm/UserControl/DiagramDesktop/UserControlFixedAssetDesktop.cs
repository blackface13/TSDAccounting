using System;

namespace TSD.AccountingSoft.WindowsForm.UserControl.DiagramDesktop
{

    public partial class UserControlFixedAssetDesktop : DevExpress.XtraEditors.XtraUserControl
    {
        public int RefTypeVoucher { get; set; }
        public UserControlFixedAssetDesktop()
        {
            InitializeComponent();
            //simpleButton3.Click += simpleButton3_Click;
        }
        // khai báo 1 hàm delegate
        public delegate void GetRefTypeFixedAsset(int RefTypeFixedAsset);
        // khai báo 1 kiểu hàm delegate
        public GetRefTypeFixedAsset GetRefFixedAsset;

        private void btnFixedAssetDic_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(50);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(702);
        }

        private void btnFixedAssetIncrement_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(500);
        }

        private void btnFixedAssetAdjustment_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(502);
        }

        private void btnFixedAssetDecrement_Click(object sender, EventArgs e)
        {
            GetRefFixedAsset(502);
        }

        
    }
}
