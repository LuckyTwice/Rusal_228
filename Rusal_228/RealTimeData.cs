using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal_228
{
    internal class RealTimeData : INotifyPropertyChanged
    {
        private string _realTimeData;
        public string RealTime
        {
            get { return _realTimeData; }
            set
            {
                if (_realTimeData != value)
                {
                    _realTimeData = value;
                    OnPropertyChanged("RealTimeData");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
