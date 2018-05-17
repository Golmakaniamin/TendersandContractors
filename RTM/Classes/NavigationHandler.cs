using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace RTM.Classes
{
    public enum SubSystem
    {
        UserManagement = 0,
        Tendering = 1,
        Contract = 2,
        Regulation = 3,
        TenderingArchive = 4,
        Log = 5
    }
    public enum NavigationMethod
    {
        NewMode = 0,
        EditMode = 1,
        ViewMode = 2
    }
    class NavigationHandler
    {
        /// <summary>
        /// Navigate from currentPage to destination
        /// </summary>
        /// <param name="currentPage">The page you are currently in, usually accessible through 'this' keyword</param>
        /// <param name="destination">This is the page you are going to</param>
        /// <param name="keepCurrentAlive">If it's necessary to keep the page in memory and do not dispose of it keep it as is</param>
        public static void NavigateToPage(Page currentPage, Page destination, bool keepCurrentAlive = false)
        {
            currentPage.KeepAlive = keepCurrentAlive;
            try
            {
                currentPage.NavigationService.Navigate(destination);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("System encountered problem during navigation\n" + ex.Message);
            }

        }
        public static void NavigateToPageThreadSafe(Page currentPage, Page destination, bool keepCurrentAlive = false)
        {
            currentPage.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
            {
                currentPage.KeepAlive = true;
                currentPage.NavigationService.Navigate(destination);
            });

        }
        /// <summary>
        /// Navigate from currentPage to destination
        /// </summary>
        /// <param name="currentPage">The page you are currently in, usually accessible through 'this' keyword</param>
        /// <param name="destination">This is the page you are going to parameter type is string relative to MainWindow location</param>
        /// <param name="keepCurrentAlive">If it's necessary to keep the page in memory and do not dispose of it keep it as is</param>
        public static void NavigateToPage(Page currentPage, string destination, bool keepCurrentAlive = false)
        {
            currentPage.KeepAlive = keepCurrentAlive;
            try
            {
                currentPage.NavigationService.Navigate(new Uri(destination, UriKind.Relative));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("System encountered problem during navigation\n" + ex.Message);
            }
        }

        public static void NavigateToPageWithMode(Page currentPage, Page destination, NavigationMethod mode, SubSystem subSystem, bool keepCurrentAlive = false)
        {
            currentPage.KeepAlive = keepCurrentAlive;
            if (!HasAccessToDestinationPage(subSystem,mode))
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به این صفحه امکان پذیر نیست");
                return;
            }
            try
            {
                switch (mode)
                {
                    case NavigationMethod.ViewMode:
                        destination.Loaded += new RoutedEventHandler(destination_Loaded_View);
                        break;
                    case NavigationMethod.EditMode:
                        destination.Loaded += new RoutedEventHandler(destination_Loaded_Edit);
                        break;
                    case NavigationMethod.NewMode:
                        destination.Loaded += new RoutedEventHandler(destination_Loaded_New);
                        break;
                }
                currentPage.Dispatcher.BeginInvoke((Action)delegate
                {
                    currentPage.NavigationService.Navigate(destination);
                }, DispatcherPriority.Normal);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("System encountered problem during navigation\n" + ex.Message);
            }
        }

        static void destination_Loaded_New(object sender, RoutedEventArgs e)
        {
            ForceNewMode(sender as Page);
            var page = sender as Page;
            page.Loaded -= new RoutedEventHandler(destination_Loaded_New);
        }

        static void destination_Loaded_Edit(object sender, RoutedEventArgs e)
        {
            ForceEditMode(sender as Page);
            var page = sender as Page;
            page.Loaded -= new RoutedEventHandler(destination_Loaded_Edit);
        }

        static void destination_Loaded_View(object sender, RoutedEventArgs e)
        {
            ForceViewMode(sender as Page);
            var destination = sender as Page;
            destination.Loaded -= new RoutedEventHandler(destination_Loaded_View);
        }
        public static void ForceViewMode(DependencyObject destination)
        {
            int counter = VisualTreeHelper.GetChildrenCount(destination);
            for (int i = 0; i < counter; i++)
            {
                var child = VisualTreeHelper.GetChild(destination, i);
                if (child is Button)
                {
                    var button = child as Button;
                    if (button.Name == "NextBtn" || button.Name.Contains("OpenFileBtn") || button.Name == "DocsBtn"  || button.Name == "AdBtn")
                    {
                        continue;
                    }
                    button.IsEnabled = false;
                }
                else if (child is TextBox)
                {
                    var tx = child as TextBox;
                    tx.IsEnabled = false;
                }
                else if (child is CheckBox)
                {
                    var check = child as CheckBox;
                    check.IsEnabled = false;
                }
                else if (child is ComboBox)
                {
                    var combo = child as ComboBox;
                    if (combo.Name == "DocType" || combo.Name == "ChooseCom" || combo.Name=="MC")
                        continue;
                    combo.IsEnabled = false;
                }
                else if (child is DataGrid)
                {
                    var grid = child as DataGrid;
                    grid.IsReadOnly = true;
                }
                else if (child is RadioButton)
                {
                    (child as RadioButton).IsEnabled = false;
                }
                else
                {
                    ForceViewMode(child);
                }

            }
        }
        public static void ForceEditMode(DependencyObject destination)
        {
            int counter = VisualTreeHelper.GetChildrenCount(destination);
            for (int i = 0; i < counter; i++)
            {
                var child = VisualTreeHelper.GetChild(destination, i);
                if (child is Button)
                {
                    var button = child as Button;
                    if (button.Name == "SaveBtn")
                        button.IsEnabled = false;
                }
                else
                {
                    ForceEditMode(child);
                }

            }
        }
        public static void ForceNewMode(DependencyObject destination)
        {
            int counter = VisualTreeHelper.GetChildrenCount(destination);
            for (int i = 0; i < counter; i++)
            {
                var child = VisualTreeHelper.GetChild(destination, i);
                if (child is Button)
                {
                    var button = child as Button;
                    if (button.Name == "DeleteBtn")
                        button.IsEnabled = false;
                    else if (button.Name == "EditBtn")
                        button.IsEnabled = false;
                    else if (button.Name == "ConfirmBtn")
                        button.IsEnabled = false;
                    else if (button.Name == "NextBtn")
                        button.IsEnabled = false;
                }
                else
                {
                    ForceNewMode(child);
                }

            }
        }
        public static void DisableButton(DependencyObject destination, List<string> names)
        {
            int counter = VisualTreeHelper.GetChildrenCount(destination);
            for (int i = 0; i < counter; i++)
            {
                var child = VisualTreeHelper.GetChild(destination, i);
                if (child is Button)
                {
                    var button = child as Button;
                    foreach (var name in names)
                    {
                        if (button.Name == name)
                            button.IsEnabled = false;
                    }

                }
                else
                {
                    DisableButton(child,names);
                }

            }
        }
        public static void NavigateToPageThreadSafe(Page currentPage, string destination, bool keepCurrentAlive = false)
        {
            currentPage.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
            {
                currentPage.KeepAlive = true;
                currentPage.NavigationService.Navigate(new Uri(destination, UriKind.Relative));
            });

        }
        /// <summary>
        /// Forcing user access rights to current page and preventing users from entering inappropriate pages
        /// </summary>
        /// <param name="source">The page you want to check access rights on (the page should be fully loaded)</param>
        /// <param name="subsystem">What subsystem priveleges should be checked for current page </param>
        /// <param name="log">True if you are accessing log page for the current subsystem </param>
        public static void ForceAccessRights(DependencyObject source, SubSystem subsystem, bool log = false)
        {

            var access = UserData.CurrentAccessRight;
            bool canRead = false, canEdit = false, canDelete = false, canConfirm = false, canLog = false;
            switch (subsystem)
            {
                case SubSystem.Contract:
                    //canRead = (bool)access.ContractRead;
                    //canEdit = (bool)access.ContractWrite;
                    //canDelete = (bool)access.ContractDelete;
                    //canConfirm = (bool)access.ContractPermanentWrite;
                    canRead = ((bool)(UserData.CurrentUser.ManagingPaymentDraft) || (bool)(UserData.CurrentUser.PaymentDraftCommittee));
                    canLog = (bool)access.ContractLog;
                    break;
                case SubSystem.Regulation:
                    canRead = (bool)access.RegulationRead;
                    canEdit = (bool)access.RegulationWrite;
                    canDelete = (bool)access.RegulationDelete;
                    canConfirm = (bool)access.RegulationPermanentWrite;
                    canLog = (bool)access.RegulationLog;
                    break;
                case SubSystem.Tendering:
                    canRead = (bool)access.TenderingRead;
                    canEdit = (bool)access.TenderingWrite;
                    canDelete = (bool)access.TenderingDelete;
                    canConfirm = (bool)access.TenderingPermanentWrite;
                    canLog = (bool)access.TenderingLog;
                    break;
                case SubSystem.TenderingArchive:
                    canRead = (bool)access.TenderingArchiveRead;
                    canEdit = (bool)access.TenderingArchiveWrite;
                    canDelete = (bool)access.TenderingArchiveDelete;
                    canLog = (bool)access.TenderingArchiveLog;
                    break;
            }

            if (subsystem == SubSystem.UserManagement)
            {
                if (UserData.CurrentAccessRight.CreatingUser == true)
                    return;
                else
                {
                    var page = source as Page;
                    if (page.NavigationService.CanGoBack)
                    {
                        MessageBox.Show("در حال حاضر دسترسی به این صفحه امکان پذیر نیست");
                        page.NavigationService.GoBack();
                    }
                }
            }
            if (log && canLog)
            {
                return;
            }
            else if (log)
            {
                var page = source as Page;
                if (page.NavigationService.CanGoBack)
                {
                    MessageBox.Show("در حال حاضر دسترسی به این صفحه امکان پذیر نیست");
                    page.NavigationService.GoBack();
                }
            }
            if (!(canRead || canEdit || canDelete || canConfirm))
            {
                var page = source as Page;
                if (page.NavigationService.CanGoBack)
                {
                    MessageBox.Show("در حال حاضر دسترسی به این صفحه امکان پذیر نیست");
                    page.NavigationService.GoBack();
                }
                return;
            }
            ///
            //ForceAccessRightsOnPageElements(source, canRead, canEdit, canDelete, canConfirm);

        }

        private static void ForceAccessRightsOnPageElements(DependencyObject source, bool canRead, bool canEdit, bool canDelete, bool canConfirm)
        {
            int counter = VisualTreeHelper.GetChildrenCount(source);
            for (int i = 0; i < counter; i++)
            {
                var child = VisualTreeHelper.GetChild(source, i);
                if (child is Button)
                {
                    var button = child as Button;
                    switch (button.Name)
                    {
                        case "PrintBtn":
                            if (!canRead)
                                button.Visibility = Visibility.Hidden;
                            break;
                        case "SaveBtn":
                            if (!canEdit)
                                button.Visibility = Visibility.Hidden;
                            break;
                        case "DeleteBtn":
                            if (!canDelete)
                                button.Visibility = Visibility.Hidden;
                            break;
                        case "ConfirmBtn":
                            if (!canConfirm)
                                button.Visibility = Visibility.Hidden;
                            break;
                    }
                }
                else
                {
                    ForceAccessRightsOnPageElements(child, canRead, canEdit, canDelete, canConfirm);
                }

            }
        }
        /// <summary>
        /// Active user permission to visit the requested page
        /// </summary>
        /// <param name="source">Destination page</param>
        /// <param name="subsystem">Subsytem of the destination page</param>
        /// <param name="log">Is he visiting the log of the destination page</param>
        /// <returns>true if user can visit the page </returns>
        public static bool HasAccessToDestinationPage(SubSystem subsystem, bool log = false)
        {
            var access = UserData.CurrentAccessRight;
            bool canRead = false, canEdit = false, canDelete = false, canConfirm = false, canLog = false;
            switch (subsystem)
            {
                case SubSystem.Contract:
                    //canRead = (bool)access.ContractRead || (bool)UserData.CurrentUser.ManagingContractAccess || ;
                    //canEdit = (bool)access.ContractWrite;
                    //canDelete = (bool)access.ContractDelete;
                    //canConfirm = (bool)access.ContractPermanentWrite;
                    canRead = ((bool)(UserData.CurrentUser.ManagingPaymentDraft) || (bool)(UserData.CurrentUser.PaymentDraftCommittee)||(bool)access.ContractRead || (bool)(UserData.CurrentUser.ManagingContractAccess));
                    canLog = (bool)access.ContractLog;

                    break;
                case SubSystem.Regulation:
                    canRead = (bool)access.RegulationRead;
                    canEdit = (bool)access.RegulationWrite;
                    canDelete = (bool)access.RegulationDelete;
                    canConfirm = (bool)access.RegulationPermanentWrite;
                    canLog = (bool)access.RegulationLog;
                    break;
                case SubSystem.Tendering:
                    canRead = (bool)access.TenderingRead;
                    canEdit = (bool)access.TenderingWrite;
                    canDelete = (bool)access.TenderingDelete;
                    canConfirm = (bool)access.TenderingPermanentWrite;
                    canLog = (bool)access.TenderingLog;
                    break;
                case SubSystem.TenderingArchive:
                    canRead = (bool)access.TenderingArchiveRead;
                    canEdit = (bool)access.TenderingArchiveWrite;
                    canDelete = (bool)access.TenderingArchiveDelete;
                    canLog = (bool)access.TenderingArchiveLog;
                    break;
            }
            if (subsystem == SubSystem.Log)
            {
                if ((bool)access.TenderingArchiveLog || (bool)access.TenderingLog || (bool)access.RegulationLog || (bool)access.ContractLog)
                    return true;
                else
                    return false;
            }
            if (subsystem == SubSystem.UserManagement)
            {
                if (UserData.CurrentAccessRight.CreatingUser == true)
                    return true;
                else
                {
                    return false;
                }
            }
            if (log && canLog)
            {
                return true;
            }
            else if (log)
            {
                return false;
            }
            if (!(canRead || canEdit || canDelete || canConfirm))
            {
                return false;
            }
            return true;
        }
        public static bool HasAccessToDestinationPage(SubSystem subsystem,NavigationMethod mode)
        {
            var access = UserData.CurrentAccessRight;
            bool canRead = false, canEdit = false, canDelete = false, canConfirm = false, canLog = false;
            switch (subsystem)
            {
                case SubSystem.Contract:
                    canRead = true;//(bool)UserData.CurrentUser.ManagingPaymentDraft || (bool)access.ContractPermanentWrite || (bool)access.ContractRead || (bool)UserData.CurrentUser.PaymentDraftCommittee ;
                    canEdit =  true;//(bool)access.ContractWrite || (bool)UserData.CurrentUser.ManagingPaymentDraft;
                    canDelete = true;//(bool)access.ContractDelete;
                    canConfirm = true;//(bool)access.ContractPermanentWrite;
                    canLog = (bool)access.ContractLog;
                    break;
                case SubSystem.Regulation:
                    canRead = (bool)access.RegulationRead;
                    canEdit = (bool)access.RegulationWrite;
                    canDelete = (bool)access.RegulationDelete;
                    canConfirm = (bool)access.RegulationPermanentWrite;
                    canLog = (bool)access.RegulationLog;
                    break;
                case SubSystem.Tendering:
                    canRead = (bool)access.TenderingRead;
                    canEdit = (bool)access.TenderingWrite;
                    canDelete = (bool)access.TenderingDelete;
                    canConfirm = (bool)access.TenderingPermanentWrite;
                    canLog = (bool)access.TenderingLog;
                    break;
                case SubSystem.TenderingArchive:
                    canRead = (bool)access.TenderingArchiveRead;
                    canEdit = (bool)access.TenderingArchiveWrite;
                    canDelete = (bool)access.TenderingArchiveDelete;
                    canLog = (bool)access.TenderingArchiveLog;
                    break;
            }

            if (subsystem == SubSystem.UserManagement)
            {
                if (UserData.CurrentAccessRight.CreatingUser == true)
                    return true;
                else
                {
                    return false;
                }
            }
            if (mode == NavigationMethod.NewMode || mode == NavigationMethod.EditMode)
            {
                return canEdit;
            }
            if (mode == NavigationMethod.ViewMode)
                return canRead;
            return true;
        }

        public static void ForceAccessToDestinationPageWithEditMode(Page currentPage, bool isPermanent, SubSystem subsystem)
        {
            var access = UserData.CurrentAccessRight;
            bool canRead = false, canEdit = false, canDelete = false, canConfirm = false, canLog = false;
            DisableButton(currentPage, new List<string>() { "SaveBtn" });
            if (UserData.CurrentAccessRight.SysAdmin == true)
            {
                return;
            }

            switch (subsystem)
            {
                case SubSystem.Contract:
                    canRead = (bool)access.ContractRead;
                    canEdit = (bool)access.ContractWrite;
                    canDelete = (bool)access.ContractDelete;
                    canConfirm = (bool)access.ContractPermanentWrite;
                    canLog = (bool)access.ContractLog;
                    break;
                case SubSystem.Regulation:
                    canRead = (bool)access.RegulationRead;
                    canEdit = (bool)access.RegulationWrite;
                    canDelete = (bool)access.RegulationDelete;
                    canConfirm = (bool)access.RegulationPermanentWrite;
                    canLog = (bool)access.RegulationLog;
                    break;
                case SubSystem.Tendering:
                    canRead = (bool)access.TenderingRead;
                    canEdit = (bool)access.TenderingWrite;
                    canDelete = (bool)access.TenderingDelete;
                    canConfirm = (bool)access.TenderingPermanentWrite;
                    canLog = (bool)access.TenderingLog;
                    break;
                case SubSystem.TenderingArchive:
                    canRead = (bool)access.TenderingArchiveRead;
                    canEdit = (bool)access.TenderingArchiveWrite;
                    canDelete = (bool)access.TenderingArchiveDelete;
                    canLog = (bool)access.TenderingArchiveLog;
                    break;
            }
            if (isPermanent)
            {
                DisableButton(currentPage, new List<string>() { "DeleteBtn", "EditBtn", "ConfirmBtn" });
            }
            else
            {
                List<string> buttons = new List<string>();
                if (!canDelete)
                    buttons.Add("DeleteBtn");
                if (!canConfirm)
                    buttons.Add("ConfirmBtn");
                if (!canEdit)
                    buttons.Add("EditBtn");
                if (buttons.Count > 0)
                    DisableButton(currentPage, buttons);
            }
        }

    }
}

