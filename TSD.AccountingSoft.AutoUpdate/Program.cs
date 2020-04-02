using System;
using System.Windows.Forms;

namespace TSD.AccountingSoft.AutoUpdate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] agurments)
        {
            string version = "";
            if (agurments.Length > 0)
            {
                version = agurments[0];
            }

            if (string.IsNullOrEmpty(version))
            {
                MessageBox.Show(
                    @"Thiếu tham số để chạy chương trình. Bạn không thể chạy chương trình này bằng cách trực tiếp được.",
                    @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new FrmAutoUpdate(version));
        }
    }
}
