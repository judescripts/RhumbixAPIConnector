using RhumbixAPIConnector.Annotations;
using System.ComponentModel;

namespace RhumbixAPIConnector.Models
{
    /// <summary>
    /// Client specific transform model
    /// </summary>
    public class Transform : INotifyPropertyChanged
    {
        // Applicable for all three timekeeping, shift extra, absences type
        // Transformed from timekeeping table

        private string _personnelNo;
        public string PersonnelNo
        {
            get => _personnelNo;
            set
            {
                _personnelNo = value;
                OnPropertyChanged("PersonnelNo");
            }
        }

        private string _date;

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        private string _projectNumber;

        public string ProjectNumber
        {
            get => _projectNumber;
            set
            {
                _projectNumber = value;
                OnPropertyChanged("ProjectNumber");
            }
        }

        private string _costCode;

        public string CostCode
        {
            get => _costCode;
            set
            {
                _costCode = value;
                OnPropertyChanged("CostCode");
            }
        }

        private string _activityType;

        public string ActivityType
        {
            get => _activityType;
            set
            {
                _activityType = value;
                OnPropertyChanged("ActivityType");
            }
        }
        private string _attendanceType;

        public string AttendanceType
        {
            get => _attendanceType;
            set
            {
                _attendanceType = value;
                OnPropertyChanged("AttendanceType");
            }
        }

        private string _companyCode;
        public string CompanyCode
        {
            get => _companyCode;
            set
            {
                _companyCode = value;
                OnPropertyChanged("CompanyCode");
            }
        }

        private double _hours;

        public double Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged("Hours");
            }
        }


        // Transformed from employees table
        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _employeeName;

        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                _employeeName = value;
                OnPropertyChanged("EmployeeName");
            }
        }

        private string _trade;

        public string Trade
        {
            get => _trade;
            set
            {
                _trade = value;
                OnPropertyChanged("Trade");
            }
        }

        private string _classification;

        public string Classification
        {
            get => _classification;
            set
            {
                _classification = value;
                OnPropertyChanged("Classification");
            }
        }

        // Transformed from project table (Absences not applicable)
        private string _projectName;

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                _projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }

        // Transformed from cost code table (Absences not applicable)
        private string _costCodeDescription;

        public string CostCodeDescription
        {
            get { return _costCodeDescription; }
            set
            {
                _costCodeDescription = value;
                OnPropertyChanged("CostCodeDescription");
            }
        }


        // Transformed from history table 
        private string _approvalStatus;
        public string ApprovalStatus
        {
            get => _approvalStatus;
            set
            {
                _approvalStatus = value;
                OnPropertyChanged("ApprovalStatus");
            }
        }

        private string _approverFirstName;

        public string ApproverFirstName
        {
            get { return _approverFirstName; }
            set
            {
                _approverFirstName = value;
                OnPropertyChanged("ApproverFirstName");
            }
        }
        private string _approverLastName;

        public string ApproverLastName
        {
            get => _approverLastName;
            set
            {
                _approverLastName = value;
                OnPropertyChanged("ApproverLastName");
            }
        }

        private string _approverName;

        public string ApproverName
        {
            get { return _approverName; }
            set
            {
                _approverName = value;
                OnPropertyChanged("ApproverName");
            }
        }
        private string _dateApproved;

        public string DateApproved
        {
            get => _dateApproved;
            set
            {
                _dateApproved = value;
                OnPropertyChanged("DateApproved");
            }
        }
        private string _timeApproved;

        public string TimeApproved
        {
            get => _timeApproved;
            set
            {
                _timeApproved = value;
                OnPropertyChanged("TimeApproved");
            }
        }

        // Only applicable for absences type
        // Transformed from absences table 
        private string _absenceType;

        public string AbsenceType
        {
            get => _absenceType;
            set
            {
                _absenceType = value;
                OnPropertyChanged("AbsenceType");
            }
        }

        private string _absenceDescription;

        public string AbsenceDescription
        {
            get => _absenceDescription;
            set
            {
                _absenceDescription = value;
                OnPropertyChanged("AbsenceDescription");
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
