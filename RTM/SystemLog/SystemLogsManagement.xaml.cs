using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RTM.Classes;

namespace RTM.SystemLog
{
    /// <summary>
    /// Interaction logic for SystemLogsManagement.xaml
    /// </summary>
    public partial class SystemLogsManagement : Page
    {
        public SystemLogsManagement()
        {
            InitializeComponent();
        }

        private void SystemLogManagement_Loaded(object sender, RoutedEventArgs e)
        {
            UserCom.ItemsSource = from items in DataManagement.SearchUsers(null, null, null, null)
                                  select new
                                  {
                                      Family = items.Family + " " + items.Name,
                                      UserId = items.UserId
                                  };

        }
        private bool hasAccess()
        {
            if (SubsystemCom.Text == "مناقصات")
            {
                return UserData.CurrentAccessRight.TenderingLog;
            }
            else if (SubsystemCom.Text == "قرارداد ها")
            {
                return UserData.CurrentAccessRight.ContractLog;
            }
            else if (SubsystemCom.Text == "آیین نامه ها")
            {
                return UserData.CurrentAccessRight.RegulationLog;
            }
            else if (SubsystemCom.Text == "مدیریت کاربران")
            {
                return UserData.CurrentAccessRight.CreatingUser;
            }
            return false;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SubSystem x = new SubSystem();

            if (!hasAccess())
            {
                ErrorHandler.NotifyUser(Errors.OperationNotAllowed);
                return;
            }

            if (SubsystemCom.Text == "مناقصات")
                x = SubSystem.Tendering;
            else if (SubsystemCom.Text == "قرارداد ها")
                x = SubSystem.Contract;
            else if (SubsystemCom.Text == "آیین نامه ها")
                x = SubSystem.Regulation;
            else if (SubsystemCom.Text == "مدیریت کاربران")
                x = SubSystem.UserManagement;
            else
                x = SubSystem.TenderingArchive;

            datagrid.ItemsSource = DataManagement.SearchLogs(x, Date1DP.SelectedDate, Date2DP.SelectedDate,(int?)UserCom.SelectedValue);
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            hasAccess();
            SubSystem x = new SubSystem();
            if (datagrid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            if (SubsystemCom.Text == "مناقصات")
                x = SubSystem.Tendering;
            else if (SubsystemCom.Text == "قرارداد ها")
                x = SubSystem.Contract;
            else if (SubsystemCom.Text == "آیین نامه ها")
                x = SubSystem.Regulation;
            else if (SubsystemCom.Text == "مدیریت کاربران")
                x = SubSystem.UserManagement;
            else
                x = SubSystem.TenderingArchive;

            string y = ((int)x).ToString();
            NavigationService.Navigate(new RTM.Report.GenralRep.Log_Viewer(Date1DP.SelectedDate, Date2DP.SelectedDate, y));
        }
    }
}
