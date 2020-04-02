using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TSD.AccountingSoft.WindowsForm.CommonControl
{
    public sealed partial class MainPanelControl : PanelControl
    {
        public  LabelControl FeatureCaption = new LabelControl();
        public CustomPanelControl MainPanel;

        public MainPanelControl()
        {
            InitializeComponent();

            var panelHeader = new PanelControl();
            var panelHeadderRightControl = new PanelControl();
            var panelHeaderLeftControl = new PanelControl();
            MainPanel = new CustomPanelControl();

            
            BorderStyle = BorderStyles.NoBorder;
            Controls.Add(MainPanel);
            Controls.Add(panelHeader);
            Dock = DockStyle.Fill;
            Location = new Point(149, 146);
            Size = new Size(873, 456);
            TabIndex = 4;
            // 
            // panelMain
            // 
            MainPanel.BorderStyle = BorderStyles.NoBorder;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 30);
            MainPanel.Padding = new Padding(1,1,0,0);
            MainPanel.Size = new Size(873, 426);
            MainPanel.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.BorderStyle = BorderStyles.NoBorder;
            panelHeader.Controls.Add(panelHeadderRightControl);
            panelHeader.Controls.Add(panelHeaderLeftControl);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Size = new Size(873, 30);
            panelHeader.TabIndex = 0;
            // 
            // panelHeadderRightControl
            // 
            panelHeadderRightControl.BorderStyle = BorderStyles.NoBorder;
            panelHeadderRightControl.Controls.Add(FeatureCaption);
            panelHeadderRightControl.Dock = DockStyle.Fill;
            panelHeadderRightControl.Location = new Point(1, 0);
            panelHeadderRightControl.Size = new Size(872, 30);
            panelHeadderRightControl.TabIndex = 1;
            // 
            // FeatureCaption
            // 
            FeatureCaption.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            FeatureCaption.Name="FeatureCaption";
            FeatureCaption.AutoSizeMode = LabelAutoSizeMode.None;
            FeatureCaption.Dock = DockStyle.Fill;
            FeatureCaption.Location = new Point(0, 0);
            FeatureCaption.Padding = new Padding(4, 0, 0, 0);
            FeatureCaption.Size = new Size(872, 30);
            FeatureCaption.TabIndex = 2;
            // 
            // panelHeaderLeftControl
            // 
            panelHeaderLeftControl.BorderStyle = BorderStyles.Default;
            panelHeaderLeftControl.Dock = DockStyle.Left;
            panelHeaderLeftControl.Location = new Point(0, 0);
            panelHeaderLeftControl.Margin = new Padding(0);
            panelHeaderLeftControl.Size = new Size(1, 30);
            panelHeaderLeftControl.TabIndex = 0;
        }
    }
}
