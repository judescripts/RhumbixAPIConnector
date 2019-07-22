using RhumbixAPIConnector.Annotations;
using SQLite;
using System.ComponentModel;

namespace RhumbixAPIConnector.Models
{
    public class Tokens : INotifyPropertyChanged
    {
        [PrimaryKey]
        public int Id { get; set; }

        private string _apiToken;
        public string ApiToken
        {
            get => _apiToken;
            set
            {
                _apiToken = value;
                OnPropertyChanged(("ApiToken"));
            }
        }

        private string _secretPin;

        public string SecretPin
        {
            get => _secretPin;
            set
            {
                _secretPin = value;
                OnPropertyChanged("SecretPin");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
