using RhumbixAPIConnector.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;

namespace RhumbixAPIConnector.ViewModels
{
    public class ImportedVm
    {
        public Timekeeping Timekeeping { get; set; }
        public ShiftExtra ShiftExtra { get; set; }
        public Turner Turner { get; set; }
        public OtCalculator OtCalculator { get; set; }
        public ObservableCollection<OtCalculator> OtCalculators { get; set; }
        public ObservableCollection<Timekeeping> TimeList { get; set; }
        public ObservableCollection<ShiftExtra> ShiftExtraList { get; set; }
        public ImportedVm()
        {
            Timekeeping = new Timekeeping();
            ShiftExtra = new ShiftExtra();
            Turner = new Turner();
            OtCalculator = new OtCalculator();
            TimeList = new ObservableCollection<Timekeeping>();
            ShiftExtraList = new ObservableCollection<ShiftExtra>();
            OtCalculators = new ObservableCollection<OtCalculator>();

            GetTimeKeepingList();
            GetShiftExtraList();
        }
        public void GetTimeKeepingList()
        {
            try
            {
                using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    var timeList = conn.Table<Timekeeping>().ToList();
                    TimeList.Clear();
                    foreach (var item in timeList)
                    {
                        TimeList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void GetShiftExtraList()
        {
            try
            {
                using (var conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    var shiftExtraList = conn.Table<ShiftExtra>().ToList();
                    ShiftExtraList.Clear();
                    foreach (var item in shiftExtraList)
                    {
                        ShiftExtraList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void TransformTurnerData()
        {






        }
    }
}
