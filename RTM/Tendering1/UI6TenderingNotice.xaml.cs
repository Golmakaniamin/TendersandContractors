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

namespace RTM.Tendering1
{
    /// <summary>
    /// Interaction logic for UI6CallInfoRegister.xaml
    /// </summary>
    public partial class UI6TenderingNotice : Page
    {
        public Notice CurrentNotice { set; get; }
        public Tendering CurrentTendering { set; get; }
        public UI6TenderingNotice(Tendering t)
        {
            CurrentTendering = t;
            CurrentNotice = DataManagement.SearchOrCreateNotice(CurrentTendering);
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CallNomTxt.Text == "" || CallMakeDateDP.SelectedDate==null || PresentationLocationTxt.Text=="" || OffersOpeningLocTxt.Text=="" || RecieveLocationTxt.Text=="" )
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }

            if (CurrentTendering.IsDocForSale==true)
                if ( BankName.Text=="" || AccountOwnerName.Text=="" || BranchTxt.Text=="" || AccountOwnerName.Text=="" || DocsSellPriceTxt.Text=="")
                {
                    ErrorHandler.NotifyUser("اسناد این مناقصه فروشی است لذا اطلاعات مربوط به فروش اسناد را تکمیل نمایید");
                    return;
                }

            try
            {
                DataManagement.UpdateNotice(CurrentNotice);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Notice);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void SaveAddInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveBtn.IsEnabled == true)
                NavigationHandler.NavigateToPage(this, new UI7RegisterAds(CurrentNotice,CurrentTendering));
            else
                NavigationHandler.NavigateToPageWithMode(this, new UI7RegisterAds(CurrentNotice,CurrentTendering), NavigationMethod.ViewMode, SubSystem.Tendering);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.IsDocForSale == true)
            {
                BankName.IsEnabled = true;
                BranchTxt.IsEnabled = true;
                AccountOwnerName.IsEnabled = true;
                AcountNomTxt.IsEnabled = true;
            }
            else
            {
                BankName.IsEnabled = false;
                BranchTxt.IsEnabled = false;
                AccountOwnerName.IsEnabled = false;
                AcountNomTxt.IsEnabled = false;
            }

        }


       

       
       
       
       
    }
}
