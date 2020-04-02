/***********************************************************************
 * <copyright file="PropertyChangedDetech.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, March 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System.ComponentModel;

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    public class PropertyChangedDetect : INotifyPropertyChanged
    {
        private string _imageFullPath;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public string ImageFullPath
        {
            get { return _imageFullPath; }
            set
            {
                if (value != _imageFullPath)
                {
                    _imageFullPath = value;
                    OnPropertyChanged("ImageFullPath");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
