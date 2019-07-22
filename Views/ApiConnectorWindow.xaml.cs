using RhumbixAPIConnector.ViewModels;
using RhumbixAPIConnector.ViewModels.Apis;
using System.Diagnostics;
using System.Windows;

namespace RhumbixAPIConnector.Views
{
    /// <summary>
    /// Interaction logic for ApiConnectorWindow.xaml
    /// </summary>
    public partial class ApiConnectorWindow : Window
    {
        public ApiConnectorWindow()
        {
            InitializeComponent();
            //TestMethod();
            //TestMethodAsync();
        }

        public void TestMethod()
        {
            var result = ApiConnectorVm.GetIdArrays(RhumbixApi.QueryType.TimekeepingEntries);
            Debug.WriteLine(result);
        }

        public async void TestMethodAsync()
        {


        }
    }
}
