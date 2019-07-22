using RhumbixAPIConnector.Models;
using System;
using System.Collections.ObjectModel;

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
        public ObservableCollection<Transform> TransformedList { get; set; }
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
            TransformedList = new ObservableCollection<Transform>();

            GetTimeKeepingList();
            GetShiftExtraList();
            GetAbsencesList();
            GetCostCodesList();
            GetProjectsList();
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

        // TODO: Implement transformation method for Turner
        public void TransformTurnerData()
        {






        }
    }
}
