using System.ComponentModel;

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

        private string _pin;

        public string Pin
        {
            get => _pin;
            set
            {
                _pin = value;
                OnPropertyChanged("Pin");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
