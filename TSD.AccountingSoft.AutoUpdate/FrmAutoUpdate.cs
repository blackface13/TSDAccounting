using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BigTimeUpdate;

namespace TSD.AccountingSoft.AutoUpdate
{
    public partial class FrmAutoUpdate : Form, IBigTimeUpdatable
    {
        private readonly BigTimeUpdater _updater;
        private readonly string _version;

        public FrmAutoUpdate(string version)
        {
            InitializeComponent();
            _version = version;
            lblVersion.Text = @"R" + version; 
            _updater = new BigTimeUpdater(this);
        }

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            _updater.DoUpdate();
        }

        #region SharpUpdate
        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public string ApplicationID
        {
            get { return "A-BIGTIME"; }

        }

        public Icon ApplicationIcon
        {
            get { return Icon; }
        }

        public string ApplicationName
        {
            get { return "A-BIGTIME"; }
        }

        public Form Context
        {
            get { return this; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("http://123.30.239.197:8099/aBNG/update.xml"); }
        }
        #endregion


        public Version Version
        {
            get { return new Version(_version); }
        }
    }
}
