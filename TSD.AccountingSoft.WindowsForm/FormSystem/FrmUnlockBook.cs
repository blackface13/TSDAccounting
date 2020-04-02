using System;
using System.Drawing;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.System.Lock;
using TSD.AccountingSoft.View.System;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    public partial class FrmUnlockBook : XtraForm,ILockView
    {
        private LockPresenter lockPresenter;

        public FrmUnlockBook()
        {
            InitializeComponent();
            lockPresenter=new LockPresenter(this);
        }

        public string Content { get; set; }

        public DateTime LockDate
        {
            get { return dtExcuteDate.DateTime; }
            set { dtExcuteDate.DateTime = value; }
        }

        public bool IsLock { get; set; }

        private void FrmUnlockBook_Load(object sender, EventArgs e)
        {
            lockPresenter.Display();
            RefeshForm();
            btn.BackColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            IsLock = true;
            lockPresenter.Save();
            RefeshForm();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            IsLock = false;
            lockPresenter.Save();
            RefeshForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void RefeshForm()
        {
            lockPresenter.Display();
            lblNotice.Text = Content;
        }

    }
}