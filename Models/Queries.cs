using System.ComponentModel;
using System.Windows.Controls;

namespace RhumbixAPIConnector.Models
{
    public class Queries : INotifyPropertyChanged
    {
        private string _startDate;
        public string StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private string _endDate;
        public string EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private ComboBoxItem _queryType;
        public ComboBoxItem QueryType
        {
            get => _queryType;
            set
            {
                _queryType = value;
                OnPropertyChanged("QueryType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
