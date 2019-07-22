using RhumbixAPIConnector.Models;
using RhumbixAPIConnector.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RhumbixAPIConnector.ViewModels
{
    public class ImportedVm
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public Timekeeping Timekeeping { get; set; }
        public ShiftExtra ShiftExtra { get; set; }
        public Transform Transform { get; set; }
        public ObservableCollection<Timekeeping> TimeList { get; set; }
        public ObservableCollection<ShiftExtra> ShiftExtraList { get; set; }
        public ObservableCollection<Absences> AbsencesList { get; set; }
        public ObservableCollection<CostCodes> CostCodesList { get; set; }
        public ObservableCollection<Project> ProjectsList { get; set; }
        public ObservableCollection<Employee> EmployeesList { get; set; }
        public ObservableCollection<TimekeepingHistory> TimeHistoryList { get; set; }
        public ObservableCollection<ShiftExtraHistory> ShiftHistoryList { get; set; }
        public ObservableCollection<AbsencesHistory> AbsencesHistoryList { get; set; }
        public ObservableCollection<Transform> TransformedList { get; set; }
        public TransformCommand TransformCommand { get; set; }
        public ImportedVm()
        {
            Timekeeping = new Timekeeping();
            ShiftExtra = new ShiftExtra();
            Transform = new Transform();
            TimeList = new ObservableCollection<Timekeeping>();
            ShiftExtraList = new ObservableCollection<ShiftExtra>();
            AbsencesList = new ObservableCollection<Absences>();
            CostCodesList = new ObservableCollection<CostCodes>();
            ProjectsList = new ObservableCollection<Project>();
            EmployeesList = new ObservableCollection<Employee>();
            TimeHistoryList = new ObservableCollection<TimekeepingHistory>();
            ShiftHistoryList = new ObservableCollection<ShiftExtraHistory>();
            AbsencesHistoryList = new ObservableCollection<AbsencesHistory>();
            TransformedList = new ObservableCollection<Transform>();

            TransformCommand = new TransformCommand(this);

            GetTimeKeepingList();
            GetShiftExtraList();
            GetAbsencesList();
            GetCostCodesList();
            GetProjectsList();
            GetEmployeesList();
            GetTimeHistoryList();
            GetShiftHistoryList();
            GetAbsencesHistoryList();
            GetTransformedList();
        }

        /// <summary>
        /// Eager load data from database
        /// </summary>
        public void GetTimeKeepingList()
        {
            try
            {
                Logger.Info("GetTimeKeepingList Method");
                var timeList = DatabaseHelper.GetList<Timekeeping>();
                TimeList.Clear();
                foreach (var item in timeList)
                {
                    TimeList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting timekeeping list");
            }
        }
        public void GetShiftExtraList()
        {
            try
            {
                Logger.Info("GetShiftExtraList Method");
                var shiftExtraList = DatabaseHelper.GetList<ShiftExtra>();
                ShiftExtraList.Clear();
                foreach (var item in shiftExtraList)
                {
                    ShiftExtraList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting shift extra list");
            }
        }
        public void GetAbsencesList()
        {
            try
            {
                Logger.Info("GetAbsencesList Method");
                var absencesList = DatabaseHelper.GetList<Absences>();
                AbsencesList.Clear();
                foreach (var item in absencesList)
                {
                    AbsencesList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting absences list");
            }
        }
        public void GetCostCodesList()
        {
            try
            {
                Logger.Info("GetCostCodesList Method");
                var costCodesList = DatabaseHelper.GetList<CostCodes>();
                CostCodesList.Clear();
                foreach (var item in costCodesList)
                {
                    CostCodesList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting cost codes list");
            }
        }
        public void GetProjectsList()
        {
            try
            {
                Logger.Info("GetProjectsList Method");
                var projectsList = DatabaseHelper.GetList<Project>();
                ProjectsList.Clear();
                foreach (var item in projectsList)
                {
                    ProjectsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting projects list");
            }
        }
        public void GetEmployeesList()
        {
            try
            {
                Logger.Info("GetEmployeesList Method");
                var employeesList = DatabaseHelper.GetList<Employee>();
                EmployeesList.Clear();
                foreach (var item in employeesList)
                {
                    employeesList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting employees list");
            }
        }
        public void GetTimeHistoryList()
        {
            try
            {
                Logger.Info("GetTimeHistoryList Method");
                var timeHistoryList = DatabaseHelper.GetList<TimekeepingHistory>();
                TimeHistoryList.Clear();
                foreach (var item in timeHistoryList)
                {
                    timeHistoryList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting timekeeping history list");
            }
        }
        public void GetShiftHistoryList()
        {
            try
            {
                Logger.Info("GetShiftListHistory Method");
                var shiftHistoryList = DatabaseHelper.GetList<ShiftExtraHistory>();
                ShiftHistoryList.Clear();
                foreach (var item in shiftHistoryList)
                {
                    ShiftHistoryList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting projects list");
            }
        }
        public void GetAbsencesHistoryList()
        {
            try
            {
                Logger.Info("GetAbsencesHistoryList Method");
                var absencesHistoryList = DatabaseHelper.GetList<AbsencesHistory>();
                AbsencesHistoryList.Clear();
                foreach (var item in absencesHistoryList)
                {
                    AbsencesHistoryList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting projects list");
            }
        }
        public void GetTransformedList()
        {
            try
            {
                Logger.Info("GetAbsencesHistoryList Method");
                var transformedList = DatabaseHelper.GetList<Transform>();
                TransformedList.Clear();
                foreach (var item in transformedList)
                {
                    TransformedList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured from getting projects list");
            }
        }
        public async void TransformTurnerData()
        {
            var employeesList = DatabaseHelper.GetList<Employee>();
            var projectsList = DatabaseHelper.GetList<Project>();
            var costCodesList = DatabaseHelper.GetList<CostCodes>();
            var timeList = DatabaseHelper.GetList<Timekeeping>();
            var absencesList = DatabaseHelper.GetList<Absences>();
            var timeHistoryList = DatabaseHelper.GetList<TimekeepingHistory>();
            var absencesHistoryList = DatabaseHelper.GetList<AbsencesHistory>();

            var turnerList = new List<Transform>();

            // Transform timekeeping data
            if (timeList != null)
            {
                foreach (var item in timeList)
                {
                    // Employee query
                    var employeeQuery = employeesList
                        .Where(x => x.CompanySuppliedId == item.Employee)
                        .Select(x => new { x.FirstName, x.LastName, x.Trade, x.Classification })
                        .First();
                    var firstName = employeeQuery.FirstName;
                    var lastName = employeeQuery.LastName;
                    var trade = employeeQuery.Trade;
                    var classification = employeeQuery.Trade;

                    // Project query
                    var projectName = projectsList
                        .Where(x => x.JobNumber == item.JobNumber)
                        .Select(x => x.Name)
                        .First();

                    // Cost code query
                    var costCodeDescription = costCodesList
                        .Where(x => x.Code == item.CostCode)
                        .Select(x => x.Description)
                        .First();

                    // Approval query
                    var approverQuery = timeHistoryList
                        .Where(x => { return x.Id == item.Id && x.Status == "SUPERVISOR_APPROVED"; })
                        .Select(x => new { x.ModifiedBy, x.HistoryDate })
                        .First();

                    var approverDetails = employeesList
                        .Where(x => x.CompanySuppliedId == approverQuery.ModifiedBy)
                        .Select(x => new { x.FirstName, x.LastName })
                        .First();

                    var approvalStatus = "Pending";
                    var approverFirstName = "";
                    var approverLastName = "";
                    var approverName = "";
                    var dateApproved = "";
                    var timeApproved = "";

                    if (approverQuery != null)
                    {
                        approvalStatus = "Approved";
                        approverFirstName = approverDetails.FirstName;
                        approverLastName = approverDetails.LastName;
                        approverName = $"{approverFirstName} {approverLastName}";
                        dateApproved = Convert.ToDateTime(approverQuery.HistoryDate).Date.ToString();
                        timeApproved =
                            $"{Convert.ToDateTime(approverQuery.HistoryDate).Hour}:{Convert.ToDateTime(approverQuery.HistoryDate).Minute}";
                    }

                    if (item.StandardTimeMinutes > 0)
                    {
                        turnerList.Add(
                            new Transform()
                            {
                                PersonnelNo = item.Id,
                                Date = item.ShiftDate,
                                ProjectNumber = item.JobNumber,
                                CostCode = item.CostCode,
                                ActivityType = "1000",
                                AttendanceType = "800",
                                CompanyCode = "3000",
                                Hours = (double)item.StandardTimeMinutes / 60,

                                FirstName = firstName,
                                LastName = lastName,
                                EmployeeName = $"{firstName} {lastName}",
                                Trade = trade,
                                Classification = classification,
                                ProjectName = projectName,
                                CostCodeDescription = costCodeDescription,
                                ApprovalStatus = approvalStatus,
                                ApproverFirstName = approverFirstName,
                                ApproverLastName = approverLastName,
                                ApproverName = approverName,
                                DateApproved = dateApproved,
                                TimeApproved = timeApproved
                            }
                            );
                    }
                    if (item.OverTimeMinutes > 0)
                    {
                        turnerList.Add(
                            new Transform()
                            {
                                PersonnelNo = item.Id,
                                Date = item.ShiftDate,
                                ProjectNumber = item.JobNumber,
                                CostCode = item.CostCode,
                                ActivityType = "1015",
                                AttendanceType = "815",
                                CompanyCode = "3000",
                                Hours = (double)item.OverTimeMinutes / 60,
                                FirstName = firstName,
                                LastName = lastName,
                                EmployeeName = $"{firstName} {lastName}",
                                Trade = trade,
                                Classification = classification,
                                ProjectName = projectName,
                                CostCodeDescription = costCodeDescription,
                                ApprovalStatus = approvalStatus,
                                ApproverFirstName = approverFirstName,
                                ApproverLastName = approverLastName,
                                ApproverName = approverName,
                                DateApproved = dateApproved,
                                TimeApproved = timeApproved
                            }
                            );
                    }
                    if (item.DoubleTimeMinutes > 0)
                    {
                        turnerList.Add(
                            new Transform()
                            {
                                PersonnelNo = item.Id,
                                Date = item.ShiftDate,
                                ProjectNumber = item.JobNumber,
                                CostCode = item.CostCode,
                                ActivityType = "1020",
                                AttendanceType = "820",
                                CompanyCode = "3000",
                                Hours = (double)item.DoubleTimeMinutes / 60,
                                FirstName = firstName,
                                LastName = lastName,
                                EmployeeName = $"{firstName} {lastName}",
                                Trade = trade,
                                Classification = classification,
                                ProjectName = projectName,
                                CostCodeDescription = costCodeDescription,
                                ApprovalStatus = approvalStatus,
                                ApproverFirstName = approverFirstName,
                                ApproverLastName = approverLastName,
                                ApproverName = approverName,
                                DateApproved = dateApproved,
                                TimeApproved = timeApproved
                            }
                            );
                    }
                }
            }
            // Transform absences data
            if (absencesList != null)
            {
                foreach (var item in absencesList)
                {
                    // Employee query
                    var employeeQuery = employeesList
                        .Where(x => x.CompanySuppliedId == item.Employee)
                        .Select(x => new { x.FirstName, x.LastName, x.Trade, x.Classification })
                        .First();
                    var firstName = employeeQuery.FirstName;
                    var lastName = employeeQuery.LastName;
                    var trade = employeeQuery.Trade;
                    var classification = employeeQuery.Trade;

                    // Approval query
                    var approverQuery = timeHistoryList
                        .Where(x => { return x.Id == item.Id && x.Status == "SUPERVISOR_APPROVED"; })
                        .Select(x => new { x.ModifiedBy, x.HistoryDate })
                        .First();

                    var approverDetails = employeesList
                        .Where(x => x.CompanySuppliedId == approverQuery.ModifiedBy)
                        .Select(x => new { x.FirstName, x.LastName })
                        .First();

                    var approvalStatus = "Pending";
                    var approverFirstName = "";
                    var approverLastName = "";
                    var approverName = "";
                    var dateApproved = "";
                    var timeApproved = "";

                    if (approverQuery != null)
                    {
                        approvalStatus = "Approved";
                        approverFirstName = approverDetails.FirstName;
                        approverLastName = approverDetails.LastName;
                        approverName = $"{approverFirstName} {approverLastName}";
                        dateApproved = Convert.ToDateTime(approverQuery.HistoryDate).Date.ToString();
                        timeApproved =
                            $"{Convert.ToDateTime(approverQuery.HistoryDate).Hour}:{Convert.ToDateTime(approverQuery.HistoryDate).Minute}";
                    }

                    if (item.Type == "Holiday")
                    {
                        turnerList.Add(
                            new Transform()
                            {
                                PersonnelNo = item.Id,
                                Date = item.ShiftDate,
                                ActivityType = "1000",
                                AbsenceType = "110",
                                AbsenceDescription = item.Type,
                                CompanyCode = "3000",
                                FirstName = firstName,
                                LastName = lastName,
                                EmployeeName = $"{firstName} {lastName}",
                                Trade = trade,
                                Classification = classification,
                                ApprovalStatus = approvalStatus,
                                ApproverFirstName = approverFirstName,
                                ApproverLastName = approverLastName,
                                ApproverName = approverName,
                                DateApproved = dateApproved,
                                TimeApproved = timeApproved
                            }
                        );
                    }
                    else if (item.Type == "Vacation")
                    {
                        turnerList.Add(
                            new Transform()
                            {
                                PersonnelNo = item.Id,
                                Date = item.ShiftDate,
                                ActivityType = "1000",
                                AbsenceType = "100",
                                AbsenceDescription = item.Type,
                                CompanyCode = "3000",
                                FirstName = firstName,
                                LastName = lastName,
                                EmployeeName = $"{firstName} {lastName}",
                                Trade = trade,
                                Classification = classification,
                                ApprovalStatus = approvalStatus,
                                ApproverFirstName = approverFirstName,
                                ApproverLastName = approverLastName,
                                ApproverName = approverName,
                                DateApproved = dateApproved,
                                TimeApproved = timeApproved
                            }
                        );
                    }
                    else if (item.Type == "Sick")
                    {

                        turnerList.Add(
                            new Transform()
                            {
                                PersonnelNo = item.Id,
                                Date = item.ShiftDate,
                                ActivityType = "1000",
                                AbsenceType = "300",
                                AbsenceDescription = item.Type,
                                CompanyCode = "3000",
                                FirstName = firstName,
                                LastName = lastName,
                                EmployeeName = $"{firstName} {lastName}",
                                Trade = trade,
                                Classification = classification,
                                ApprovalStatus = approvalStatus,
                                ApproverFirstName = approverFirstName,
                                ApproverLastName = approverLastName,
                                ApproverName = approverName,
                                DateApproved = dateApproved,
                                TimeApproved = timeApproved
                            }
                        );
                    }
                    else
                    {
                        turnerList.Add(
                            new Transform()
                            {
                                PersonnelNo = item.Id,
                                Date = item.ShiftDate,
                                ActivityType = "Error - Check Value",
                                AbsenceType = "Error - Check Value",
                                AbsenceDescription = item.Type,
                                CompanyCode = "3000",
                                FirstName = firstName,
                                LastName = lastName,
                                EmployeeName = $"{firstName} {lastName}",
                                Trade = trade,
                                Classification = classification,
                                ApprovalStatus = approvalStatus,
                                ApproverFirstName = approverFirstName,
                                ApproverLastName = approverLastName,
                                ApproverName = approverName,
                                DateApproved = dateApproved,
                                TimeApproved = timeApproved
                            }
                        );
                    }

                }
            }
            // Transform shift extra data
            if (ShiftExtraList != null)
            {
                // Implementation to be determined. Not applicable for Turner transformation
            }

            GetTransformedList();
            var numOfRows = await DatabaseHelper.InsertManyAsync<Transform>(turnerList, true);
            FileSystemsHelpers.WriteToFile($"Number of transformed records: {numOfRows}");
            MessageBox.Show("Data transformation complete!", "Rhumbix Macro", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
