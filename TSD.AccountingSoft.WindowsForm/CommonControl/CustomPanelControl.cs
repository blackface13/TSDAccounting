/***********************************************************************
 * <copyright file="CustomPanelControl.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, September 29, 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Painter;

namespace TSD.AccountingSoft.WindowsForm.CommonControl
{
    public class CustomPanelControl: PanelControl
    {
        protected override BorderStyles DefaultBorderStyle
        {
            get
            {
                return BorderStyles.NoBorder;
            }
        }

        protected override ObjectPainter CreatePainter()
        {
            if (LookAndFeel.ActiveStyle == ActiveLookAndFeelStyle.Skin)
                return new CustomPanelControlPainter(this, LookAndFeel.ActiveLookAndFeel);
            return base.CreatePainter();
        }
    }

    public class CustomPanelControlPainter : SkinGroupObjectPainter
    {
        readonly SkinBorderPainter _fBorderPainter;
        public CustomPanelControlPainter(CustomPanelControl owner, ISkinProvider provider)
            : base(owner, provider)
        {
            _fBorderPainter = new TreeListSkinBorderPainter(provider);
        }

        public new CustomPanelControl Owner
        {
            get { return base.Owner as CustomPanelControl; }
        }

        protected override void DrawBorder(GroupObjectInfoArgs info)
        {
            if (Owner.BorderStyle == BorderStyles.NoBorder)
            {
                Rectangle border = GetBorderBounds(info);
                _fBorderPainter.DrawObject(new BorderObjectInfoArgs(info.Cache, info.Appearance, border));
            }
            else
                base.DrawBorder(info);
        }
    }
}
