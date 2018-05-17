using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using RTM.Classes;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
namespace RTM
{
    public partial class StartPage
    {
        public DateTime Date { set; get; }
        public StartPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserNameTextBlock.Text = UserData.CurrentUser.Name + " " + UserData.CurrentUser.Family;
            PostTextBlock.Text = UserData.CurrentPoistion.PositionTitle + "\n" + UserData.OrganizationalPosition.Title;
            if (UserData.CurrentUser.LastLogin != null)
                LastEnteranceTextBlock.Text = "زمان آخرین ورود به سیستم"+DateConverter.ConvertDate((DateTime)UserData.CurrentUser.LastLogin);
            if (UserData.CurrentUser.Picture != null)
            {
                image.Source = OpenFileHandler.RetrieveUserImage(UserData.CurrentUser);
            }
            if (!NavigationHandler.HasAccessToDestinationPage(SubSystem.Tendering))
                TenderingBtn.Visibility = Visibility.Collapsed;
            if (!NavigationHandler.HasAccessToDestinationPage(SubSystem.Contract))
                ContractBtn.Visibility = Visibility.Collapsed;
            if (!NavigationHandler.HasAccessToDestinationPage(SubSystem.Log))
                LogBtn.Visibility = Visibility.Collapsed;
            if (!NavigationHandler.HasAccessToDestinationPage(SubSystem.Regulation))
                RegulationBtn.Visibility = Visibility.Collapsed;
            if (!NavigationHandler.HasAccessToDestinationPage(SubSystem.TenderingArchive))
                TendArchBtn.Visibility = Visibility.Collapsed;
            if (!NavigationHandler.HasAccessToDestinationPage(SubSystem.UserManagement))
                UserMngBtn.Visibility = Visibility.Collapsed;
            if (UserData.CurrentAccessRight.SysAdmin != true)
                BaseDataBtn.Visibility = Visibility.Collapsed;

        }

        private void tileButton_Copy2_Click(object sender, RoutedEventArgs e)
        {

            if (NavigationHandler.HasAccessToDestinationPage(SubSystem.UserManagement))
                NavigationHandler.NavigateToPage(this, "UserManagement/UserMainMenu.xaml");
        }

        private void BaseDataBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new BaseInfo());
        }

        private void RegulationBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new Regulations.RegulationsMainMenu());
        }

        private void TendArchBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new TenderingArchive.TenderingArchiveSearch());
        }

        private void TenderingBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new Tenderingg.TenderingMainMenu());
        }

        private void ContractBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new Contracts.ContractsMainMenu());
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new SystemLog.SystemLogsManagement());
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new UserManagement.NewUser(UserData.CurrentUser,UserData.CurrentAccessRight,true));
        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(@"HelpFile\Help.chm");
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("فایل راهنما یافت نشد");
            }
        }
    }
}
